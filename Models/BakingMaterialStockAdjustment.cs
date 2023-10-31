#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class BakingMaterialStockAdjustment
{
    [Key]
    public int BakingMaterialStockAdjustmentId { get;set; }
    
    [Required]
    public int Quantity { get;set; }

    [Required]
    public int ReasonCode { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public int BakingMaterialStockId { get;set; }
    public BakingMaterialStock? BakingMaterialStock { get;set; }


}