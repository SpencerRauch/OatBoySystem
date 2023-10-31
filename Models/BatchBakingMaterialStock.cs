#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class BatchBakingMaterialStock
{
    [Key]
    public int BatchBakingMaterialStockId { get;set; }

    [Required]
    public int Quantity { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public int BatchId { get;set; }
    public Batch? Batch { get;set; }

    public int BakingMaterialStockId { get;set; }
    public BakingMaterialStock? BakingMaterialStock { get;set; }
    

}