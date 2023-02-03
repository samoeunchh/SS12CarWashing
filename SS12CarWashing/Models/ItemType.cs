using System.ComponentModel.DataAnnotations;

namespace SS12CarWashing.Models;

public class ItemType
{
    [Key]
    public Guid ItemTypeId { get; set; }
    [Required]
    [MaxLength(50)]
    [Display(Name = "Item Type Name")]
    public string ItemTypeName { get; set; }
}
