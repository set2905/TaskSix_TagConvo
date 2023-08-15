using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Client.Services.Interfaces
{
    public interface IHubMessageService
    {
        public Task Initialize();
        public event MessageRecieved? OnMessageRecieved;
        public Task SendMessageAsync(Message msg, string[] tags);



    }
}
