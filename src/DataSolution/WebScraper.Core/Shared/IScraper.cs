using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;

namespace WebScraper.Core.Shared
{
    public interface IScraper
    { 
        JobUrl ScrapeJobUrlInfo(string html);

        IEnumerable<JobUrl> ExtractPageUrls(string html);

        string ScrapeJobPortalInfo(string html);
    }
}
