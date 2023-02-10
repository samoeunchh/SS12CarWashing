using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SS12CarWashing.Models
{
    public class ItemDTO
    {
        [Key]
        public Guid ItemId { get; set; }
        [ForeignKey("ItemType")]
        [Display(Name = "Item Type")]
        public Guid ItemTypeId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        public double Price { get; set; }
        [Display(Name = "Brand Name")]
        public string BrandId { get; set; }
        [Display(Name = "Model")]
        public string ModelId { get; set; }
        public bool IsStock { get; set; }
        [Display(Name = "Qty Stock")]
        public int QtyOnHand { get; set; }
        [Display(Name = "Oil Type")]
        public string OilTypeId { get; set; }
        public string Size { get; set; }
        public IFormFile Image { get; set; }
        public ItemType ItemType { get; set; }
    }
}
