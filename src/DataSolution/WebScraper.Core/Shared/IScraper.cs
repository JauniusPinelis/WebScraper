using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;

namespace WebScraper.Core.Shared
{
    public interface IScraper
    {
        IEnumerable<JobUrl> ScrapePageUrls();

        IEnumerable<JobInfo> ScrapeJobHtmls(IEnumerable<JobUrl> urls);

        JobUrl ScrapeJobUrlInfo(string html);
    }
}
