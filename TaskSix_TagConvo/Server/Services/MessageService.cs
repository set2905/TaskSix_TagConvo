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

        public async Task<(bool isSuccesful, string? message)> AddMessage(string message, string[] tagNames)
        {
            Guid messageId;
            try
            {
                messageId = await messageRepo.Save(new() { Content=message });
            }
            catch
            {
                return (false, $"Couldn't save message to the database.");
            }
            foreach (string tagName in tagNames)
            {
                Tag? found;
                try
                {
                    found = await tagRepo.GetByName(tagName);
                }
                catch
                {
                    return (false, $"Error while trying to get tag by name.");
                }
                Guid tagId = found!=null ? found.Id : default;
                try
                {
                    if (found == null || tagId==default)
                        tagId = await tagRepo.Save(new() { Name=tagName });
                }
                catch
                {
                    return (false, $"Couldn't save tag \"{tagName}\" to the database.");
                }
                try
                {
                    await messageTagRelationsRepo.Save(new() { MessageId=messageId, TagId=tagId });
                }
                catch
                {
                    return (false, $"Couldn't tie message with tag \"{tagName}\".");
                }
            }
            return (true, null);
        }

    }
}
