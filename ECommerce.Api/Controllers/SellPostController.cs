using ECommerce.Core.Interfaces;
using ECommerce.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SellPostController : ControllerBase
    {
        private readonly ISellPostService _sellPostService;
        public SellPostController(ISellPostService sellPostService)
        {
            _sellPostService = sellPostService;
        }
        [Authorize]
        [HttpPost]
        public IActionResult Post(SellPostViewModel sellpostVM)
        {
            return Ok(_sellPostService.CreateSellPost(sellpostVM));
        }
        [Authorize]
        [HttpPut]
        public IActionResult Put(SellPostViewModel sellpostVM)
        {
            return Ok(_sellPostService.UpdateSellPost(sellpostVM));
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get(string UserName)
        {
            return Ok(_sellPostService.GetAllSellPostsOfUser(UserName));
        }
        [Authorize]
        [HttpGet("{SellPostID}")]
        public IActionResult GetByID(int SellPostID)
        {
            return Ok(_sellPostService.GetSellPostByID(SellPostID));
        }
        [Authorize]
        [HttpGet("SellPostByUserName/{UserName}")]
        public IActionResult GetByUserName(string Username)
        {
            return Ok(_sellPostService.GetAllSellPostsOfUser(Username));
        }
        [Authorize]
        [HttpGet("SellPostByTags")]
        public IActionResult GetByUserName(List<string> Tags)
        {
            return Ok(_sellPostService.GetSellPostsbyTags(Tags));
        }
    }
}
