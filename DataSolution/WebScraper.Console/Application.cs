using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core;
using WebScraper.Core.Filters;

namespace WebScraper.Console
{
    public class Application
    {
        public void Run()
        {
            var scraper = new CvOnlineScraper();
            scraper.ScrapePageUrls();

            var cvOnlineFilter = new CvOnlineUrlFilter();
            scraper.ApplyUrlFilter(cvOnlineFilter);

            var result = scraper.UrlData;
        }
    }
}
