#pragma warning disable CS8618
namespace OatBoySystem.Models.ViewModels;
public class RecipeEdit
{
    public Recipe Recipe { get;set; }
    public List<BakingMaterial> AllBakingMaterials { get;set; } = new();
}