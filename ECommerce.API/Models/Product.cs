using System.Text.Json;

namespace ECommerce.API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }

        // JSON column for dynamic attributes
        public JsonDocument Attributes { get; set; } = JsonDocument.Parse("{}");

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property (optional)
        public Category? Category { get; set; }

        public static implicit operator Product(Product v)
        {
            throw new NotImplementedException();
        }
    }
}
