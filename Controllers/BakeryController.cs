using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using OatBoySystem.Models;
using OatBoySystem.Models.ViewModels;

namespace OatBoySystem.Controllers;

[Route("bakery")]
public class BakeryController : Controller
{
    private readonly ILogger<BakeryController> _logger;

    private OatBoyContext _context;

    public BakeryController(ILogger<BakeryController> logger, OatBoyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("recipes")]
    public ViewResult Recipes()
    {
        List<Recipe> AllRecipes = _context.Recipes.Include(r=>r.Batches).ToList();
        return View("Recipes",AllRecipes);
    }

    [HttpPost("recipes/create")]
    public IActionResult RecipeCreate(Recipe newRecipe)
    {
        if (!ModelState.IsValid)
        {
            return Recipes();
        }
        _context.Add(newRecipe);
        _context.SaveChanges();
        return RedirectToAction("RecipeView",new{rId=newRecipe.RecipeId});
    }

    [HttpGet("recipes/{rId}")]
    public ViewResult RecipeView(int rId)
    {
        Recipe Recipe = _context.Recipes
                            .Include(r=>r.BakingMaterialAssociations)
                            .ThenInclude(bma => bma.BakingMaterial)
                            .FirstOrDefault(r => r.RecipeId == rId);
        List<BakingMaterial> AllBakingMaterials = _context.BakingMaterials.ToList();
        RecipeEdit ViewModel = new(){Recipe = Recipe,AllBakingMaterials = AllBakingMaterials};
        return View("RecipeView", ViewModel);
    }

    [HttpPost("recipes/{rId}/add_ingredient")]
    public IActionResult RecipeAddIngredient(int rId, RecipeAddIngredient formModel)
    {
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage));
            Console.WriteLine(message);

            return RecipeView(rId);
        }
        RecipeBakingMaterialAssociation newAss = new()
        {
            RecipeId = rId,
            BakingMaterialId = formModel.BakingMaterialId,
            Quantity = formModel.Quantity
        };
        _context.Add(newAss);
        _context.SaveChanges();
        return RedirectToAction("RecipeView", new{rId });

    }

    [HttpPost("recipes/{rId}/{bmId}/update")]
    public IActionResult RecipeUpdateIngredient(int rId, int bmId, RecipeBakingMaterialAssociation rbma)
    {
        if (!ModelState.IsValid)
        {
            return RecipeView(rId);
        }
        RecipeBakingMaterialAssociation toUpdate = _context.RecipeBakingMaterialAssociations
                                                        .FirstOrDefault(rbma => rbma.RecipeId == rId && rbma.BakingMaterialId == bmId);
        toUpdate.Quantity = rbma.Quantity;
        _context.SaveChanges();
        return RedirectToAction("RecipeView", new{rId });

    }

    [HttpPost("recipes/{rId}/{bmId}/remove")]
    public IActionResult RecipeRemoveIngredient(int rId, int bmId)
    {
        RecipeBakingMaterialAssociation toBeRemoved = _context.RecipeBakingMaterialAssociations
                                                            .FirstOrDefault(rbma => rbma.RecipeId == rId && rbma.BakingMaterialId == bmId);
        _context.Remove(toBeRemoved);
        _context.SaveChanges();
        return RedirectToAction("RecipeView", new{rId });

    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
