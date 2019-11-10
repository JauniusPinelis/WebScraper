using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Core.Entities
{
    public class JobInfo : AuditableEntity
    {
        public int Id { get; set; }
        public string HtmlCode { get; set; }

        public string Title { get; set; }
        public string Salary { get; set; }

        public JobUrl JobUrl { get; set; }
        public int? JobUrlId { get; set; }
    }
}
