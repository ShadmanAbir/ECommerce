using System.ComponentModel.DataAnnotations;

namespace ECommerce.Domain.Models
{
    public class SellPostWiseTag
    {
        [Key]
        public int ID { get; set; }
        public int SellPostID { get; set; }
        public int TagID { get; set; }

    }
}
