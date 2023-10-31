#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class BakingMaterial
{
    [Key]
    public int BakingMaterialId { get;set; }

    [Required]
    public string Name { get;set; }

    [Required]
    public string UnitOfMeasure { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    // stock items of this type
    public List<BakingMaterialStock> Stock { get;set; } = new();
    // associatons to recipes
    public List<RecipeBakingMaterial> RecipeAssociations { get;set; } = new();
}