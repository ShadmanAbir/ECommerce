using System.Text.Json;

namespace ECommerce.API.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public int? ParentId { get; set; }

        // JSON column: array of allowed attributes
        public JsonDocument AllowedAttributes { get; set; } = JsonDocument.Parse("[]");
    }

    public class CategoryAttributeViewModel
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = "string"; // string, number, boolean
        public string[]? Options { get; set; }
    }
}
