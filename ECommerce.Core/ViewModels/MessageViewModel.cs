
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.ViewModels
{
    public partial class MessageViewModel
    {
        [Key]
        public int MessageID { get; set; }
        [Required]
        public string MessageBody { get; set; }
        [Required]
        public string SenderID { get; set; }
        [Required]
        public string ReceiverID { get; set; }
        public int ParentID { get; set; }
        public int SellPostID { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}