#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class ShippingMaterialStockAdjustment
{
    [Key]
    public int ShippingMaterialStockAdjustmentId { get;set; }
    [Required]
    public int Quantity { get;set; }
    [Required]
    public int ReasonCode { get;set; }

    public int ShippingMaterialStockId { get;set; }
    public ShippingMaterialStock? ShippingMaterialStock { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

}