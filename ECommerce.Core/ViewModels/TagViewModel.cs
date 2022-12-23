using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.ViewModels
{
    public partial class TagViewModel
    {
        [Key]
        public int TagID { get; set; }
        [Required]
        public string TagName { get; set; }
    }
}