using System.ComponentModel.DataAnnotations;

namespace ECommerce.Domain.Models
{
    public class SellPost
    {
        [Key]
        public int PostID { get; set; }
        public string Header { get; set; }
        public int ProductID { get; set; }
        public int SellTagID { get; set; }
        public string PostCreator { get; set; }
        public ICollection<Message> Conversation { get; set; }
        public ICollection<SellPostWiseTag> Tags { get; set; }
        public Product Product { get; set; }
    }
}
