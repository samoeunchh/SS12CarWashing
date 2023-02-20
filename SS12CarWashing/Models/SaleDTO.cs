using System.ComponentModel.DataAnnotations;

namespace SS12CarWashing.Models;
public class SaleDTO
{
    [Key]
    public Guid SaleId { get; set; }
    [Display(Name = "Customer Name")]
    public string CustomerName { get; set; }
    [Display(Name = "Issue Date")]
    [DataType(DataType.Date)]
    public DateTime IssueDate { get; set; }
    [MaxLength(20)]
    public string InvoiceNumber { get; set; }
    public double Total { get; set; }
    public int Discount { get; set; }
    public double GrandTotal { get; set; }
    public Customer Customer { get; set; }
    public List<SaleDetailDTO> SaleDetails { get; set; }
}
