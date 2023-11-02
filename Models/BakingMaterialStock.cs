#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class BakingMaterialStock
{
    [Key]
    public int BakingMaterialStockId { get;set; }

    [Required]
    public int Quantity { get;set; }

    [Required]
    public string Brand { get;set; }

    [Required]
    public int Status { get;set; }

    [DataType(DataType.Date)]
    public DateTime? DateOfManufacture { get;set; }

    [Required(ErrorMessage = "Batch required. Enter DOM or EXP as MM/YY if batch unknown.")]
    [UniqueBatch]
    public string Batch { get;set; }

    [DataType(DataType.Date)]
    public DateTime? Expiration { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    
    public int BakingMaterialId { get;set; }
    public BakingMaterial? BakingMaterial { get;set; }
    public List<BatchBakingMaterialStockAssociation> BatchAssociations { get;set; } = new();
    public List<BakingMaterialStockAdjustment> Adjustments { get;set; } = new();

}

public class UniqueBatchAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null)
        {
            return new ValidationResult("Batch required. Enter DOM or EXP as MM/YY if batch unknown.");
        }
        OatBoyContext _context = (OatBoyContext)validationContext.GetService(typeof(OatBoyContext));
    	if(_context.BakingMaterialStock.Any(bms => bms.Batch == value.ToString()))
        {
            return new ValidationResult("Batch in system, make adjustment instead");
        } else {
            return ValidationResult.Success;
        }
    }
}