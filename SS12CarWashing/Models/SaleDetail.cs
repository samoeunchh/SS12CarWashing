using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS12CarWashing.Models;

public class SaleDetail
{
    [Key]
    public Guid SaleDetailId { get; set; }
    [ForeignKey("Sale")]
    public Guid SaleId { get; set; }
    [ForeignKey("Item")]
    public Guid ItemId { get; set; }
    public double Price { get; set; }
    public int Qty { get; set; }
    public double Amount { get; set; }

    public Sale Sale { get; set; }
    public Item Item { get; set; }
}
