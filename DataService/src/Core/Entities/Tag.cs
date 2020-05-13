using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Tag : Entity
    {
        public TagCategory TagCategory { get; set; }
        public int TagCategoryId { get; set; }
        public JobInfo JobInfo { get; set; }
        public int JobInfoId { get; set; }
    }
}
