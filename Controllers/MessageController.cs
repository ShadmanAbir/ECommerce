using ECommerce.Core.Interfaces;
using ECommerce.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public IActionResult Post(MessageViewModel messageVM)
        {
            return Ok(_messageService.SendMessage(messageVM));
        }

        [HttpPut]
        public IActionResult Put(int messageID,string messageBody)
        {
            return Ok(_messageService.EditMessage(messageID,messageBody));
        }
        [HttpGet]
        public IActionResult Get(string UserName)
        {
            return Ok(_messageService.GetMessagesBetweenUser(User.Identity.Name, UserName));
        }

        [HttpGet("{MessageID}")]
        public IActionResult GetByID(int MessageID)
        {
            return Ok(_messageService.GetMessageByID(MessageID));
        }
    }
}
