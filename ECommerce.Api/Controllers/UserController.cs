using ECommerce.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [Authorize]
        [HttpPost("BlockUser")]
        public IActionResult BlockUser(string userToBlock)
        {
            return Ok(_userService.BlockUser(userToBlock, User.Identity.Name));
        }
        [Authorize]
        [HttpPost("UnblockUser")]
        public IActionResult UnBlockUser(string userToUnblock)
        {
            return Ok(_userService.UnblockUser(userToUnblock, User.Identity.Name));
        }
        [Authorize]
        [HttpGet("BlockListOfUser")]
        public IActionResult Get()
        {
            return Ok(_userService.GetBlockListOfUser(User.Identity.Name));
        }
        
        [HttpGet("UserList")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.Users());
        }
    }
}
