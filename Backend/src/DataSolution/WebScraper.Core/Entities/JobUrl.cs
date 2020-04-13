using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Core.Entities
{
    public class JobUrl : AuditableEntity
    {
        public string Url { get; set; }

        public string SalaryText { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }

        public string Company { get; set; }


        public JobInfo JobInfo { get; set; }
        public int? JobInfoId { get; set; }

        public JobPortal JobPortal { get; set; }

        public int? JobPortalId { get; set; }

        public Salary Salary { get; set; }

        public int? SalaryId { get; set; }
    }
}
