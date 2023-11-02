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

    private Dictionary<int, string> BakingMaterialStatus = new Dictionary<int, string>()
    {
        {0,"Good"},
        {1,"Expired"},
        {2,"Recall"}
    };


    public InventoryController(ILogger<InventoryController> logger, OatBoyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("inventory")]
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

    // BAKING MATERIALS
    [HttpGet("bakingmaterial/new")]
    public ViewResult BakingMaterialNew()
    {
        return View();
    }

    [HttpPost("bakingmaterial/create")]
    public IActionResult BakingMaterialCreate(BakingMaterial newBM)
    {
        if (!ModelState.IsValid)
        {
            return View("BakingMaterialNew");
        }
        _context.Add(newBM);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [HttpGet("bakingmaterial/{id}")]
    public ViewResult BakingMaterialView(int id)
    {
        BakingMaterial? BMfromDb = _context.BakingMaterials
                                            .Include(bm => bm.Stock)
                                            .FirstOrDefault(bm => bm.BakingMaterialId == id);
        ViewBag.BakingMaterialStatus = BakingMaterialStatus;
        return View("BakingMaterialView", BMfromDb);
    }

    //BAKING MATERIAL STOCK
    [HttpGet("bakingmaterialstock/new/{bmId}")]
    public ViewResult BakingMaterialStockNew(int bmId)
    {
        BakingMaterial bm = _context.BakingMaterials.FirstOrDefault(bm => bm.BakingMaterialId == bmId);
        return View("BakingMaterialStockNew", bm);
    }

    [HttpPost("bakingmaterialstock/create/{bmId}")]
    public IActionResult BakingMaterialStockCreate(BakingMaterialStockForm bmsForm, int bmId)
    {
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
            return BakingMaterialStockNew(bmId);
        }
        BakingMaterialStock newStock = new()
        {
            BakingMaterialId = bmId,
            Quantity = bmsForm.Quantity,
            Brand = bmsForm.Brand,
            Batch = bmsForm.Batch,
            DateOfManufacture = bmsForm.DateOfManufacture,
            Expiration = bmsForm.Expiration,
            Status = 0
        };
        _context.Add(newStock);
        _context.SaveChanges();
        return RedirectToAction("BakingMaterialView", new { id = bmId });
    }

    [HttpPost("bakingmaterialstock/adjust/{returnId}")]
    public IActionResult BakingMaterialStockAdjust(BakingManualAdjust formAdjust, int returnId)
    {
        if (!ModelState.IsValid)
        {
            return BakingMaterialView(returnId);
        }
        BakingMaterialStock? BMSToAdjust = _context.BakingMaterialStock
                                            .FirstOrDefault(bms => bms.BakingMaterialStockId == formAdjust.BakingMaterialStockId);
        if (BMSToAdjust == null)
        {
            ModelState.AddModelError("Quantity", "Error locating batch");
            return BakingMaterialView(returnId);
        }
        BMSToAdjust.Quantity += (int)formAdjust.Quantity;
        BakingMaterialStockAdjustment newAdjust = new()
        {
            Quantity = (int)formAdjust.Quantity,
            ReasonCode = formAdjust.ReasonCode,
            BakingMaterialStockId = formAdjust.BakingMaterialStockId
        };
        _context.Add(newAdjust);
        _context.SaveChanges();
        return RedirectToAction("BakingMaterialView", new { id = returnId });
    }

    [HttpPost("bakingmaterialstock/status/update/{bmsId}")]
    public RedirectToActionResult BakingMaterialStockStatus(int bmsId, int statusCode)
    {
        BakingMaterialStock bms = _context.BakingMaterialStock.FirstOrDefault(bms => bms.BakingMaterialStockId == bmsId);
        bms.Status = statusCode;
        _context.SaveChanges();
        return RedirectToAction("BakingMaterialView",new {id = bms.BakingMaterialId});

    }

    //SHIPPING MATERIALS
    [HttpGet("shippingmaterial/new")]
    public ViewResult ShippingMaterialNew()
    {
        return View();
    }

    [HttpPost("shippingmaterial/create")]
    public IActionResult ShippingMaterialCreate(ShippingMaterial newSM)
    {
        if (!ModelState.IsValid)
        {
            return View("ShippingMaterialNew");
        }
        _context.Add(newSM);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [HttpGet("shippingmaterial/{id}")]
    public ViewResult ShippingMaterialView(int id)
    {
        ShippingMaterial? SMfromDb = _context.ShippingMaterials
                                            .Include(sm => sm.Stock)
                                            .FirstOrDefault(sm => sm.ShippingMaterialId == id);
        return View("ShippingMaterialView", SMfromDb);
    }

    //SHIPPING MATERIALS STOCK
    [HttpGet("shippingmaterialstock/new/{smId}")]
    public ViewResult ShippingMaterialStockNew(int smId)
    {
        ShippingMaterial sm = _context.ShippingMaterials.FirstOrDefault(sm => sm.ShippingMaterialId == smId);
        return View("ShippingMaterialStockNew", sm);
    }

    [HttpPost("shippingmaterialstock/create/{smId}")]
    public IActionResult ShippingMaterialStockCreate(ShippingMaterialStockForm smsForm, int smId)
    {
        if(!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
            return ShippingMaterialStockNew(smId);
        }
        ShippingMaterialStock newStock = new()
        {
            ShippingMaterialId = smId,
            Quantity = smsForm.Quantity,
            Brand = smsForm.Brand
        };
        _context.Add(newStock);
        _context.SaveChanges();
        return RedirectToAction("ShippingMaterialView", new{id = smId});
    }

    [HttpPost("shippingmaterialstock/adjust/{returnId}")]
    public IActionResult ShippingMaterialStockAdjust(ShippingManualAdjust formAdjust, int returnId)
    {
        if (!ModelState.IsValid)
        {
            return ShippingMaterialView(returnId);
        }
        ShippingMaterialStock? SMSToAdjust = _context.ShippingMaterialStock.FirstOrDefault(sms => sms.ShippingMaterialStockId == formAdjust.ShippingMaterialStockId);
        if (SMSToAdjust == null)
        {
            ModelState.AddModelError("Quantity", "Error locating id");
            return BakingMaterialView(returnId);
        }
        SMSToAdjust.Quantity += (int)formAdjust.Quantity;
        ShippingMaterialStockAdjustment newAdjust = new()
        {
            Quantity = (int)formAdjust.Quantity,
            ReasonCode = formAdjust.ReasonCode,
            ShippingMaterialStockId = formAdjust.ShippingMaterialStockId
        };
        _context.Add(newAdjust);
        _context.SaveChanges();
        return RedirectToAction("ShippingMaterialView", new {id = returnId});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
