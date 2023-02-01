using System.ComponentModel.DataAnnotations;

namespace SS12CarWashing.Models;

public class Customer
{
    [Key]
    public Guid CustomerId { get; set; }
    [MaxLength(50)]
    [Display(Name ="Customer Name")]
    public string CustomerName { get; set; }
    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [StringLength(20)]
    [Phone]
    public string PhoneNumber { get; set; }
    [MaxLength(500)]
    [DataType(DataType.MultilineText)]
    public string Address { get; set; }
}
