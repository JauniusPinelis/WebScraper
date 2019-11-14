using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;

namespace WebScraper.Core.CvBankas
{
    public class CvBankasScraper : IScraper
    {
        public IEnumerable<JobInfo> ScrapeJobHtmls(IEnumerable<JobUrl> urls)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobUrl> ScrapePageUrls()
        {
            throw new NotImplementedException();
        }
    }
}
