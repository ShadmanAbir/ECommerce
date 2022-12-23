using System.ComponentModel.DataAnnotations;

namespace ECommerce.Domain.Models
{
    public class UserBlockList
    {
        [Key]
        public int BlockListID { get; set; }
        public string UserName { get; set; }
        public string BlockedUser { get; set; }
        public bool IsDeleted { get; set; }
    }
}
