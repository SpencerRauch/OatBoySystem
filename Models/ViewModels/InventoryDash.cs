#pragma warning disable CS8618
namespace OatBoySystem.Models.ViewModels;
public class InventoryDash
{
    public List<Product> AllProducts { get;set; } = new();
    public List<BakingMaterial> AllBakingMaterials { get;set; } = new();
    public List<ShippingMaterial> AllShippingMaterials { get;set; } = new();
}