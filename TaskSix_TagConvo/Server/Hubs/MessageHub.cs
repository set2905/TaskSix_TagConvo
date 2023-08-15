using Microsoft.AspNetCore.SignalR;
using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Server.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(Message msg, string[] tags)
        {
            await Clients.All.SendAsync("ReceiveMessage", msg, tags);
        }
    }
}
