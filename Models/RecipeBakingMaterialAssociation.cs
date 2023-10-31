#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class RecipeBakingMaterialAssociation
{
    [Key]
    public int RecipeBakingMaterialAssociationId { get;set; }
    [Required]
    public int Quantity { get;set; }

    public int RecipeId { get;set; }
    public Recipe? Recipe { get;set; }

    public int BakingMaterialId { get;set; }
    public BakingMaterial? BakingMaterial { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

}