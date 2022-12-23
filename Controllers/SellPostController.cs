using ECommerce.Core.Interfaces;
using ECommerce.Core.Services;
using ECommerce.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpPost]
        public IActionResult Post(SellPostViewModel sellpostVM)
        {
            return Ok(_sellPostService.CreateSellPost(sellpostVM));
        }

        [HttpPut]
        public IActionResult Put(SellPostViewModel sellpostVM)
        {
            return Ok(_sellPostService.UpdateSellPost(sellpostVM));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_sellPostService.GetAllSellPosts());
        }

        [HttpGet("{SellPostID}")]
        public IActionResult GetByID(int SellPostID)
        {
            return Ok(_sellPostService.GetSellPostByID(SellPostID));
        }
    }
}
