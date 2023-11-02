#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models.ViewModels;
public class BakingManualAdjust
{
    public List<BakingMaterialStock> CurrentStock { get;set; } = new();
    [Required]
    public int? Quantity { get;set; }
    [Required]
    public int ReasonCode { get;set; }

    public int BakingMaterialId { get;set; }
    public int BakingMaterialStockId { get;set; }
}