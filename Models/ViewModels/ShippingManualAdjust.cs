#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models.ViewModels;
public class ShippingManualAdjust
{
    public List<ShippingMaterialStock> CurrentStock { get;set; } = new();
    [Required]
    public int? Quantity { get;set; }
    [Required]
    public int ReasonCode { get;set; }

    public int ShippingMaterialId { get;set; }
    public int ShippingMaterialStockId { get;set; }
}