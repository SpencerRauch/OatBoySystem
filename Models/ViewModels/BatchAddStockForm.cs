#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using OatBoySystem.Models;
namespace OatBoySystem.Models.ViewModels;
public class BatchAddStockForm
{
    public int BatchId { get;set; }
    public int BakingMaterialStockId { get;set; }
    public List<BakingMaterialStock> RelatedStock { get;set; } = new();
    [BakingMaterialInstock]
    public int Quantity { get;set; }
    public int Needed { get;set; }
}

public class BakingMaterialInstockAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Quantity is required");
        }
        OatBoyContext _context = (OatBoyContext)validationContext.GetService(typeof(OatBoyContext));
        BatchAddStockForm data = (BatchAddStockForm)validationContext.ObjectInstance;
        BakingMaterialStock BMStock = _context.BakingMaterialStock.FirstOrDefault(bms => bms.BakingMaterialStockId == data.BakingMaterialStockId);
        if (BMStock == null)
        {
            return new ValidationResult("Baking material not found");
        }
        if (BMStock.Quantity < data.Quantity)
        {
            return new ValidationResult("Stock too low");
        }
        if (data.Needed < data.Quantity)
        {
            return new ValidationResult("Quantity more than needed");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}