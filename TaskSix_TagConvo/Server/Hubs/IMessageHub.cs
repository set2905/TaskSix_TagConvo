using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Server.Hubs
{
    public interface IMessageHub
    {
        public Task SendToAll(Message? message, string[]? tags);

    }
}
