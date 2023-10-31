#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class Product
{
    [Key]
    public int ProductId { get;set; }

    [Required]
    public string Name { get;set; }

    [Required]
    public string UnitOfMeasure { get;set; }

    public string Description { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public int RecipeId { get;set; }
    public Recipe? Recipe { get;set; }

    public List<ProductShippingMaterial> ShippingMaterials { get;set; } = new();
    //todo: finished goods associations
    public List<ProductStock> Stock { get;set; } = new();

}