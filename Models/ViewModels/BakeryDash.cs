#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models.ViewModels;
public class BakeryDash
{
    public List<Recipe> AllRecipes { get;set; } = new();
    public List<Batch> AllBatches { get;set; } = new();
}