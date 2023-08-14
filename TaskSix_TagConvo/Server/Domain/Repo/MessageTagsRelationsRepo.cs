using Microsoft.EntityFrameworkCore;
using TaskSix_TagConvo.Server.Data;
using TaskSix_TagConvo.Server.Domain.Repo.Interfaces;
using TaskSix_TagConvo.Server.Models;
using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Server.Domain.Repo
{
    public class MessageTagsRelationsRepo : IMessageTagsRelationsRepo
    {
        private readonly ApplicationDbContext context;

        public MessageTagsRelationsRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        /// <inheritdoc />

        public async Task<bool> Delete(MessageTagRelation entity)
        {
            context.MessageTagRelations.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
        /// <inheritdoc />

        public async Task<List<MessageTagRelation>> GetAll()
        {
            return await context.MessageTagRelations.ToListAsync();

        }
        /// <inheritdoc />

        public async Task<MessageTagRelation?> GetById(Guid id)
        {
            return await context.MessageTagRelations.SingleOrDefaultAsync(x => x.Id == id);
        }
        /// <inheritdoc />

        public async Task<Guid> Save(MessageTagRelation entity)
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

