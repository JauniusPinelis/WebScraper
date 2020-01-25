using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Core.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        public TagCategory TagCategory { get; set; }
        public int TagCategoryId { get; set; }
        public JobInfo JobInfo { get; set; }
        public int JobInfoId { get; set; }

    }
}
