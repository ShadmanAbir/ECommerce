using ECommerce.API.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ECommerce.API.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }

        // JSON column for dynamic attributes
        public JsonDocument Attributes { get; set; } = JsonDocument.Parse("{}");

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property (optional)
        public CategoryViewModel? Category { get; set; }
        public string CategoryName { get; set; }
    }
}
