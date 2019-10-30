using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Core.Entities
{
    public class JobInfo
    {
        public int Id { get; set; }
        public string HtmlCode { get; set; }
        public JobUrl JobUrl { get; set; }
    }
}
