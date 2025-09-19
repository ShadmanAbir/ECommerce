using System.Text.Json;

namespace ECommerce.API.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public int? ParentId { get; set; }

        // JSON column: array of allowed attributes
        public JsonDocument AllowedAttributes { get; set; } = JsonDocument.Parse("[]");
        public DateTime CreatedAt { get; set; }
    }

    public class CategoryAttribute
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = "string"; // string, number, boolean
        public string[]? Options { get; set; }
    }
}
