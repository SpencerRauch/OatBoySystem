#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class OrderProduct
{
    [Key]
    public int OrderProductId { get;set; }

    [Required]
    public int Quantity { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public int OrderId { get;set; }
    public Order? Order { get;set; }

    public int ProductId { get;set; }
    public Product? Product { get;set; }

    public List<OrderProductStockAssociation> StockAssociations { get;set; } = new();

}