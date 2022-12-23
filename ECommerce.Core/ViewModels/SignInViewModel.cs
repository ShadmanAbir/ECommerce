using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.ViewModels
{
    public class SignInViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
