using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Server.Services.Interfaces
{
    public interface IMessageService
    {
        public Task<Message?> AddMessage(string message, string[] tagNames);
        public Task<List<Message>> GetMessages(int skip, int take, Guid[] tagIds);
        public Task<List<Tag>> GetAllTags();



    }
}
