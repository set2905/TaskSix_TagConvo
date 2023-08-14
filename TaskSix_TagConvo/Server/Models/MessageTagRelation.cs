using Microsoft.EntityFrameworkCore;
using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Server.Models
{
    public class MessageTagRelation
    {
        public Guid Id { get; set; }
        public Tag Tag { get; set; }
        public Message Message { get; set; }
        public Guid TagId { get; set; }
        public Guid MessageId { get; set; }
    }
}
