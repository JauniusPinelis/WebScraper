using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;

namespace WebScraper.Core.Shared
{
    public class BaseScraper
    {
        public List<JobUrl> jobUrls { get; set; }

        public BaseScraper()
        {
            jobUrls = new List<JobUrl>();
        }
    }
}
