using Microsoft.EntityFrameworkCore;

namespace TaskSix_TagConvo.Server.Models
{
    [PrimaryKey(nameof(TagId), nameof(MessageId))]
    public class MessageTagRelation
    {
        public Guid TagId { get; set; }
        public Guid MessageId { get; set; }
    }
}
