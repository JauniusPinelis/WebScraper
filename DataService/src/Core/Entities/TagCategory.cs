using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class TagCategory : Entity
    {
        public string Name { get; set; }

        public List<Tag> Tags { get; set; }

    }
}
