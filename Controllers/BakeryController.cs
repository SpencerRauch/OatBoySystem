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

    private Dictionary<int, string> BatchStatus = new Dictionary<int, string>()
    {
        {0,"Ordered"},
        {1,"In Process"},
        {2,"Cooling"},
        {3,"Drying"},
        {4,"Ready To Pack"},
        {5,"Processed"},
        {6,"Quarantine"},
        {7,"Recall"},
    };


    public BakeryController(ILogger<BakeryController> logger, OatBoyContext context)
    {
        _logger = logger;
        _context = context;
    }

    //RECIPES
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

    [HttpGet("recipes/{rId}/all_batches")]
    public ViewResult RecipeAllBatch(int rId)
    {
        Recipe RecipeWithBatches = _context.Recipes.Include(r=>r.Batches).FirstOrDefault(r=>r.RecipeId == rId);
        ViewBag.Statuses = BatchStatus;
        return View("RecipeAllBatch",RecipeWithBatches);
    }

    //BATCHES

    [HttpGet("dashboard")]
    public ViewResult BakeryDashboard()
    {
        ViewBag.Statuses = BatchStatus;
        return View("BakeryDashboard", new BakeryDash()
        {
            AllRecipes = _context.Recipes.ToList(),
            AllBatches = _context.Batches.Include(b => b.Recipe).OrderByDescending(b=>b.BatchId).ToList()
        });
    }

    [HttpPost("batches/create")]
    public RedirectToActionResult BatchCreate(int rId)
    {
        Batch newBatch = new(){RecipeId = rId, Status = 0};
        _context.Add(newBatch);
        _context.SaveChanges();
        return RedirectToAction("BatchEdit", new{bId=newBatch.BatchId});
    }

    [HttpGet("batches/{bId}")]
    public ViewResult BatchEdit(int bId)
    {
        Batch toEdit = _context.Batches
                            .Include(b => b.BakingMaterialStockAssociations)
                            .ThenInclude(bmsa => bmsa.BakingMaterialStock)
                            .Include(b => b.Recipe)
                            .ThenInclude(r=>r.BakingMaterialAssociations)
                            .ThenInclude(bma=>bma.BakingMaterial)
                            .FirstOrDefault(b=>b.BatchId==bId);
        
        ViewBag.Statuses = BatchStatus;
        return View("BatchEdit",toEdit);
    }

    [HttpPost("batches/{bId}/status")]
    public RedirectToActionResult BatchStatusUpdate(int bId, int status)
    {
        Batch toUpdate = _context.Batches.FirstOrDefault(b=>b.BatchId==bId);
        toUpdate.Status = status;
        _context.SaveChanges();
        return RedirectToAction("BakeryDashboard");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
