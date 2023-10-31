#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class Batch
{
    [Key]
    public int BatchId { get;set; }
    [Required]
    public int Status { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public int RecipeId { get;set; }
    public Recipe? Recipe { get;set; }

    public List<BatchBakingMaterialStockAssociation> BakingMaterialStockAssociations { get;set; } = new();
    public List<ProductStock> ProductStock { get;set; } = new();

}