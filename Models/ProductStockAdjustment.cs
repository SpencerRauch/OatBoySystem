#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class ProductStockAdjustment
{
    [Key]
    public int ProductStockAdjustmentId { get;set; }
    [Required]
    public int Quantity { get;set; }
    [Required]
    public int ReasonCode { get;set; }

    public int ProductStockId { get;set; }
    public ProductStock? ProductStock { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

}