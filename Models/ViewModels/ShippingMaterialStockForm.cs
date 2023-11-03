#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models.ViewModels;
public class ShippingMaterialStockForm
{
    public ShippingMaterial? ShippingMaterial { get; set; }
    [Required]
    [Range(0,int.MaxValue,ErrorMessage = "Quantity should be positive. Use adjustments for negative")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Brand required. Put unknown if not known")]
    [UniqueBrand]
    public string Brand { get; set; }

}

public class UniqueBrandAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Brand required. Put unknown if not known");
        }
        OatBoyContext _context = (OatBoyContext)validationContext.GetService(typeof(OatBoyContext));
        if (_context.ShippingMaterialStock.Any(sms => sms.Brand.ToUpper() == value.ToString().ToUpper()))
        {
            return new ValidationResult("Brand in system, make adjustment instead");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}