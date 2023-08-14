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
        [HttpPost]
        [Route("Messages")]
        public async Task<IActionResult> GetMessages(Guid[] tagIds)
        {
            List<Message> messages = await messageService.GetMessages(0, 100, tagIds);
            return new JsonResult(messages);
        }
        [HttpGet]
        [Route("Tags")]
        public async Task<IActionResult> GetAllTags()
        {
            List<Tag> tags = await messageService.GetAllTags();
            return new JsonResult(tags);
        }
    }
}
