using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaskSix_TagConvo.Server.Models;
using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<MessageTagRelation> MessageTagRelations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
