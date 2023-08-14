using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Server.Services.Interfaces
{
    public interface IMessageService
    {
        public Task AddMessage(string message, string[] tagNames);
        public Task<List<Message>> GetMessages(int skip, int take, string[] tagNames);


    }
}
