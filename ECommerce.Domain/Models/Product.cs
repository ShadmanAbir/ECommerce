using System.ComponentModel.DataAnnotations;

namespace ECommerce.Domain.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ICollection<SellPost> SellPosts { get; set; }
    }
}
