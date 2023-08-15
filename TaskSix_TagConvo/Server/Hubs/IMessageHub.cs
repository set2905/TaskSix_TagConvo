using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Server.Hubs
{
    public interface IMessageHub
    {
        public Task SendMessage(Message msg, string[] tags);
    }
}
