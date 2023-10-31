#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OatBoySystem.Models;

public class Order
{
    [Key]
    public int OrderId { get;set; }

    [Required]
    public int OrderNumber { get;set; }

    [DataType(DataType.DateTime)]
    public DateTime Ordered { get;set; }

    [Required]
    public int Status { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<OrderProduct> OrderProducts { get;set; } = new();

}