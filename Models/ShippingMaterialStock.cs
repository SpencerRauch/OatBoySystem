#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class ShippingMaterialStock
{
    [Key]
    public int ShippingMaterialStockId { get;set; }
    [Required]
    public int Quantity { get;set; }

    public int ShippingMaterialId { get;set; }
    public ShippingMaterial? ShippingMaterial { get;set; }

    public List<ShippingMaterialStockAdjustment> Adjustments { get;set; } = new();

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

}