using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Core.Entities
{
    public class AuditableEntity
    {
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

    }
}
