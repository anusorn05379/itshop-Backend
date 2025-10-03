using System.ComponentModel.DataAnnotations;

namespace ITShopAPI.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } // Pending, Confirmed, Cancelled

        [Required]
        [StringLength(50)]
        public string PaymentStatus { get; set; } // Pending, Paid, Failed

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
