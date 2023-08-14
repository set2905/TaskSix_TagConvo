using TaskSix_TagConvo.Server.Models;
using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Server.Domain.Repo.Interfaces
{
    public interface IMessageRepo : IRepo<Message>
    {
        public Task<List<Message>> Get(int skip, int take, string[] tagNames);

    }
}
