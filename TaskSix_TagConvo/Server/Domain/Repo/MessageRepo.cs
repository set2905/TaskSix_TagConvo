using Microsoft.EntityFrameworkCore;
using TaskSix_TagConvo.Server.Data;
using TaskSix_TagConvo.Server.Domain.Repo.Interfaces;
using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Server.Domain.Repo
{
    public class MessageRepo : IMessageRepo
    {
        private readonly ApplicationDbContext context;

        public MessageRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Message>> Get(int skip, int take, Guid[] tagIds)
        {
            return await context.Messages
            .Where(m => context.MessageTagRelations.Any(r => tagIds.Contains(r.TagId) && r.MessageId==m.Id))
            .OrderBy(x => x.SentDate)
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        }
        /// <inheritdoc />

        public async Task<bool> Delete(Message entity)
        {
            context.Messages.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
        /// <inheritdoc />

        public async Task<List<Message>> GetAll()
        {
            return await context.Messages.ToListAsync();

        }
        /// <inheritdoc />

        public async Task<Message?> GetById(Guid id)
        {
            return await context.Messages.SingleOrDefaultAsync(x => x.Id == id);
        }
        /// <inheritdoc />

        public async Task<Guid> Save(Message entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity.Id;
        }
    }
}

