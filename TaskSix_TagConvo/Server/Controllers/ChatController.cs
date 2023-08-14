using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSix_TagConvo.Server.Services.Interfaces;
using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMessageService messageService;

        public ChatController(IMessageService messageService)
        {
            this.messageService=messageService;
        }

        [HttpPost]
        [Route("Send")]
        public async Task<IActionResult> SendMessage(SendMessageModel sendMessageModel)
        {
            await messageService.AddMessage(sendMessageModel.Content, sendMessageModel.Tags);
            return Ok();

        }
        [HttpGet]
        [Route("GetMessages")]
        public async Task<IActionResult> GetMessages()
        {
            List<Message> messages = await messageService.GetMessages(0, 100, null);
            return new JsonResult(messages);

        }
    }
}
