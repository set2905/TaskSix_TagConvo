﻿using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Message>> GetFiltered(int skip, int take, Guid[] tagIds)
        {
            IOrderedQueryable<Message> query;
            if (tagIds.Length > 0)
            {
                query = context.Messages.Where(m => !context.MessageTagRelations.Select(x => x.MessageId).Contains(m.Id)||context.MessageTagRelations.Any(r => tagIds.Contains(r.TagId) && r.MessageId==m.Id))
                                        .OrderBy(x => x.SentDate);
            }
            else query=context.Messages.OrderBy(x => x.SentDate);

            return await query.Skip(skip).Take(take).ToListAsync();

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

