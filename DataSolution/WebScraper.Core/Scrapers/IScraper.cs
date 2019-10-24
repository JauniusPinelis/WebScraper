using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Dtos;
using WebScraper.Core.Filters;

namespace WebScraper.Core
{
    public interface IScraper
    {
        IEnumerable<JobUrlDto> ScrapePageUrls();

        IEnumerable<JobHtmlDto> ScrapeJobHtmls(IEnumerable<JobUrlDto> urls);
    }
}
