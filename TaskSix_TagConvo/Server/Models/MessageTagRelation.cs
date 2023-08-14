using Microsoft.EntityFrameworkCore;

namespace TaskSix_TagConvo.Server.Models
{
    public class MessageTagRelation
    {
        public Guid Id { get; set; }
        public Guid TagId { get; set; }
        public Guid MessageId { get; set; }
    }
}
