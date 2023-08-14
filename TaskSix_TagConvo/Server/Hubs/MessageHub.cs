using Microsoft.AspNetCore.SignalR;
using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Server.Hubs
{
    public class MessageHub : Hub, IMessageHub
    {
        public async Task SendToAll(Message? message, string[]? tags)
        {
            await Clients.All.SendAsync("Message", message, tags);
        }
    }
}
