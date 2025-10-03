using System.ComponentModel.DataAnnotations;

namespace ITShopAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        // Navigation property
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
