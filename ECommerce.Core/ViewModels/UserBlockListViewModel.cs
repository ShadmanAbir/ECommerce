using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.ViewModels
{
    public partial class UserBlockListViewModel
    {
        [Key]
        public int BlockListID { get; set; }
        public int UserID { get; set; }
        public int BlockedUserID { get; set; }
    }
}