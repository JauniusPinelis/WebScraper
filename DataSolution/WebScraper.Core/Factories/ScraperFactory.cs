using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Filters;

namespace WebScraper.Core.Factories
{
    public class ScraperFactory : IScraperFactory
    {


        public IScraper BuildScraper(string website)
        {
            switch (website)
            {
                case "cvonline":
                    return new CvOnlineScraper();
                default:
                    throw new Exception("There is no Scraper for this website");
            }
        }

        public IUrlFilter BuildUrlFilter(string website)
        {
            switch (website)
            {
                case "cvonline":
                    return new CvOnlineUrlFilter();
                default:
                    throw new Exception("There is no Filter for this website");
            }
        }
    }
}
