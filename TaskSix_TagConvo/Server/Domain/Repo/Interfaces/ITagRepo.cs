using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Server.Domain.Repo.Interfaces
{
    public interface ITagRepo : IRepo<Tag>
    {
        public Task<Tag?> GetByName(string name);
    }
}
