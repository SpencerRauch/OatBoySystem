#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class ProductStock
{
    [Key]
    public int ProductStockId { get;set; }

    [Required]
    public int Quantity { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public int BatchId { get;set; }
    public Batch? Batch { get;set; }

    public int ProductId { get;set; }
    public Product? Product { get;set; }

    public List<ProductStockAdjustment> Adjustments { get;set; } = new();
    public List<OrderProductStockAssociation> OrderAssociations { get;set; } = new();

}