using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class JobPortal : Entity
    {
        public string Name { get; set; }
        public ICollection<JobUrl> JobUrls { get; set; }
    }
}
