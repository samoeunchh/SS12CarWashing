using System.ComponentModel.DataAnnotations;

namespace SS12CarWashing.Models;

public class SaleDetailDTO
{
    [Key]
    public Guid SaleDetailId { get; set; }
    public Guid SaleId { get; set; }
    public string ItemName { get; set; }
    public double Price { get; set; }
    public int Qty { get; set; }
    public double Amount { get; set; }

    public Sale Sale { get; set; }
    public Item Item { get; set; }
}
