
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.ViewModels
{

    public partial class SellPostWiseTagViewModel
    {
        [Key]
        public int ID { get; set; }
        public int SellPostID { get; set; }
        public int TagID { get; set; }
    }
}