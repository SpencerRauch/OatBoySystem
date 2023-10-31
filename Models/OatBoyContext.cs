#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace OatBoySystem.Models;

public class OatBoyContext : DbContext 
{   
    public OatBoyContext(DbContextOptions options) : base(options) { }    
    public DbSet<BakingMaterial> BakingMaterials { get;set; }
    public DbSet<BakingMaterialStock> BakingMaterialStock { get;set; }
    public DbSet<BakingMaterialStockAdjustment> BakingMaterialStockAdjustments { get;set; }
    public DbSet<Batch> Batches { get;set; }
    public DbSet<BatchBakingMaterialStockAssociation> BatchBakingMaterialStockAssociations { get;set; }
    public DbSet<Order> Orders { get;set; }
    public DbSet<OrderProduct> OrderProducts { get;set; }
    public DbSet<OrderProductStockAssociation> OrderProductStockAssociations { get;set; }
    public DbSet<Product> Products { get;set; }
    public DbSet<ProductShippingMaterialAssociation> ProductShippingMaterialAssociations { get;set; }
    public DbSet<ProductStock> ProductStock { get;set; }
    public DbSet<ProductStockAdjustment> ProductStockAdjustments { get;set; }
    public DbSet<Recipe> Recipes { get;set; }
    public DbSet<RecipeBakingMaterialAssociation> RecipeBakingMaterialAssociations { get;set; }
    public DbSet<ShippingMaterial> ShippingMaterials { get;set; }
    public DbSet<ShippingMaterialStock> ShippingMaterialStock { get;set; }
    public DbSet<ShippingMaterialStockAdjustment> ShippingMaterialStockAdjustments { get;set; }

    
}