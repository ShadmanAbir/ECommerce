using ECommerce.API.Models;

namespace ECommerce.API.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; } = "pending"; // pending, paid, shipped, cancelled
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public User? User { get; set; }
        public List<OrderItemViewModel>? Items { get; set; }
    }

    public class OrderItemViewModel
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Navigation properties
        public OrderViewModel? Order { get; set; }
        public ProductViewModel? Product { get; set; }
    }
}
