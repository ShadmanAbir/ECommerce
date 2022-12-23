using System.ComponentModel.DataAnnotations;

namespace ECommerce.Domain.Models
{
    public class Tag
    {
        [Key]
        public int TagID { get; set; }
        public string TagName { get; set; }
    }
}
