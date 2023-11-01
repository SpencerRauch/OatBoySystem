using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OatBoySystem.Models;
using OatBoySystem.Models.ViewModels;

namespace OatBoySystem.Controllers;

public class InventoryController : Controller
{
    private readonly ILogger<InventoryController> _logger;

    private OatBoyContext _context;

    public InventoryController(ILogger<InventoryController> logger, OatBoyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Dashboard()
    {
        InventoryDash InventoryDash = new()
        {
            AllBakingMaterials = _context.BakingMaterials.Include(bm => bm.Stock).ToList(),
            AllProducts = _context.Products.Include(p => p.Stock).ToList(),
            AllShippingMaterials = _context.ShippingMaterials.Include(sm => sm.Stock).ToList()
        };
        return View(InventoryDash);
    }

    public ViewResult NewBakingMaterial()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateBakingMaterial(BakingMaterial newBM)
    {
        if (!ModelState.IsValid)
        {
            return View("NewBakingMaterial");
        }
        _context.Add(newBM);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    public ViewResult NewShippingMaterial()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateShippingMaterial(ShippingMaterial newBM)
    {
        if (!ModelState.IsValid)
        {
            return View("NewShippingMaterial");
        }
        _context.Add(newBM);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
