using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;


namespace ECommerce.Core.ViewModels
{
    public partial class SellPostViewModel
    {

        [Key]
        public int PostID { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public int ProductID { get; set; }
        public int SellTagID { get; set; }
        public string PostCreator { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? ProductName { get; set; }

        public List<string> Tags { get; set; }
    }
}