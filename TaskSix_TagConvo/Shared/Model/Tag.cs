using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSix_TagConvo.Shared.Model
{
    public class Tag
    {
        public Tag()
        {
            Name=string.Empty;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
