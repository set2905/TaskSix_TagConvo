using TaskSix_TagConvo.Server.Domain.Repo.Interfaces;
using TaskSix_TagConvo.Server.Services.Interfaces;
using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Server.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepo messageRepo;
        private readonly ITagRepo tagRepo;
        private readonly IMessageTagsRelationsRepo messageTagRelationsRepo;

        public MessageService(IMessageRepo messageRepo, ITagRepo tagRepo, IMessageTagsRelationsRepo messageTagRelationsRepo)
        {
            this.messageRepo=messageRepo;
            this.tagRepo=tagRepo;
            this.messageTagRelationsRepo=messageTagRelationsRepo;
        }
        public async Task<List<Message>> GetMessages(int skip, int take, Guid[] tagIds)
        {
            return await messageRepo.Get(skip, take, tagIds);
        }

        public async Task<Message?> AddMessage(string message, string[] tagNames)
        {
            Guid messageId;
            messageId = await messageRepo.Save(new() { Content=message, SentDate=DateTime.Now });
            foreach (string tagName in tagNames)
            {
                Tag? found;
                found = await tagRepo.GetByName(tagName);
                Guid tagId = found!=null ? found.Id : default;
                if (found == null || tagId==default)
                    tagId = await tagRepo.Save(new() { Name=tagName });
                await messageTagRelationsRepo.Save(new() { MessageId=messageId, TagId=tagId });
            }
            return await messageRepo.GetById(messageId);
        }

        public async Task<List<Tag>> GetAllTags()
        {
            return await tagRepo.GetAll();
        }
    }
}
