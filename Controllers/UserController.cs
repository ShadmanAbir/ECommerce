using ECommerce.Core.Interfaces;
using ECommerce.Core.ViewModels;
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
        [HttpGet]
        public ActionResult<IEnumerable<UserViewModel>> Get()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<UserViewModel> Get(int id)
        {
            return Ok(_userService.GetByID(id));
        }

        [HttpPost]
        public ActionResult<bool> Post(UserViewModel userVM)
        {
            return Ok(_userService.InsertUser(userVM));
        }

        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, UserViewModel userVM)
        {
            return Ok(_userService.InsertUser(userVM));
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            throw new NotImplementedException();
            //return Ok(_userService.Ge(userVM));
        }
    }
}
