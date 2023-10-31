#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class OrderProductStockAssociation
{
    [Key]
    public int OrderProductStockAssociationId { get;set; }

    [Required]
    public int Quantity { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public int ProductStockId { get;set; }
    public ProductStock? ProductStock { get;set; }

    public int OrderProductId { get;set; }
    public OrderProduct OrderProduct { get;set; }



}