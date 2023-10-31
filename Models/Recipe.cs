#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class Recipe
{
    [Key]
    public int RecipeId { get;set; }

    [Required]
    public string Name { get;set; }

    public string Description { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<Product> Products { get;set; } = new();
    public List<RecipeBakingMaterialAssociation> BakingMaterialAssociations { get;set; } = new();
    public List<Batch> Batches { get;set; } = new();

}