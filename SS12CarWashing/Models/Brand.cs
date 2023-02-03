using System.ComponentModel.DataAnnotations;

namespace SS12CarWashing.Models;

public class Brand
{
    [Key]
    public Guid BrandId { get; set; }
    [Required(ErrorMessage ="Brand Name is required!")]
    [MaxLength(50)]
    [Display(Name ="Brand Name")]
    public string BrandName { get; set; }
}
