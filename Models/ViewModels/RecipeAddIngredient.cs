#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models.ViewModels;
public class RecipeAddIngredient
{
    public List<BakingMaterial> Unassociated { get;set; } = new();
    public int RecipeId { get;set; }
    [Required]
    [Range(1,int.MaxValue)]
    public int Quantity { get;set; }
    public int BakingMaterialId { get;set; }
}