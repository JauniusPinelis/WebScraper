using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;
using WebScraper.Core.Filters;

namespace WebScraper.Core
{
    public interface IScraper
    {
        IEnumerable<JobUrl> ScrapePageUrls();

        IEnumerable<JobInfo> ScrapeJobHtmls(IEnumerable<JobUrl> urls);
    }
}
