using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Core.Entities
{
    public class JobInfo : AuditableEntity
    {
        public string HtmlCode { get; set; }

        public string Title { get; set; }
        public string SalaryText { get; set; }

        public JobUrl JobUrl { get; set; }
        public int? JobUrlId { get; set; }

        public List<Tag> Tags { get; set; }
        public Salary Salary { get; set; }
        public int? SalaryId { get; set; }

    }
}
