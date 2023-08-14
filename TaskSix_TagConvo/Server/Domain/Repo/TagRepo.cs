using Microsoft.EntityFrameworkCore;
using System;
using TaskSix_TagConvo.Server.Data;
using TaskSix_TagConvo.Server.Domain.Repo.Interfaces;
using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Server.Domain.Repo
{
    public class TagRepo : ITagRepo
    {
        private readonly ApplicationDbContext context;

        public TagRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        /// <inheritdoc />

        public async Task<bool> Delete(Tag entity)
        {
            context.Tags.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
        /// <inheritdoc />

        public async Task<List<Tag>> GetAll()
        {
            return await context.Tags.ToListAsync();

        }
        /// <inheritdoc />

        public async Task<Tag?> GetById(Guid id)
        {
            return await context.Tags.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> GetByName(string name)
        {
            return await context.Tags.SingleOrDefaultAsync(x => x.Name == name);

        }

        /// <inheritdoc />

        public async Task<Guid> Save(Tag entity)
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
