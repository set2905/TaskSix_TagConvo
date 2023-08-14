using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSix_TagConvo.Shared.Model
{
    public class Message
    {
        public Message()
        {   
            Content=string.Empty;
        }

        public int Id { get; set; }
        public string Content { get; set; }
    }
}
