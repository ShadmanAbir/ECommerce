using ECommerce.Core.Interfaces;
using ECommerce.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("SignIn")]
        public IActionResult SignIn(SignInViewModel signInVM)
        {
            return Ok(_authService.ValidateCredential(signInVM));
        }
        [HttpPost("CreateUser")]
        public IActionResult CreateUser(SignUpViewModel signUpVM)
        {
            return Ok(_authService.CreateUser(signUpVM));
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(SignUpViewModel signUpVM)
        {
            return Ok(_authService.UpdateUser(signUpVM));
        }

    }
}
