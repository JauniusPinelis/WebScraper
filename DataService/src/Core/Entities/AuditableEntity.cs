using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class AuditableEntity : Entity
    {
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }

    }
}
