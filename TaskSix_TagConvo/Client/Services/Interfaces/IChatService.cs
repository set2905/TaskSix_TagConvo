using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Client.Services.Interfaces
{
    public interface IChatService
    {
        public Task<Message?> SendMessage(string message, string[] tags);
        public Task<List<Message>> GetFilteredMessages(Guid[] tagIds);
        public Task<List<Tag>> GetTags();
    }
}
