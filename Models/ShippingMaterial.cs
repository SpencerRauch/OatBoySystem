#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class ShippingMaterial
{
    [Key]
    public int ShippingMaterialId { get;set; }
    [Required]
    public string Name { get;set; }
    [Required]
    public string UnitOfMeasure { get;set; }
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    //Nav props needed: list of ProductShippingMaterialUses (prods containing sm)
    public List<ShippingMaterialStock> Stock { get;set; } = new();
    public List<ProductShippingMaterial> ProductAssociations { get;set; } = new();

}