#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class ProductShippingMaterial
{
    [Key]
    public int ProductShippingMaterialId { get;set; }

    [Required]
    public int Quantity { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public int ProductId { get;set; }
    public Product? Product { get;set; }

    public int ShippingMaterialId { get;set; }
    public ShippingMaterial? ShippingMaterial { get;set; }

    

}