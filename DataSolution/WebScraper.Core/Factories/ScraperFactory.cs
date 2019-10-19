using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Filters;

namespace WebScraper.Core.Factories
{
    public static class ScraperFactory
    {
        public static IScraper BuildScraper(string website)
        {
            switch (website)
            {
                case "cvonline":
                    return new CvOnlineScraper();
                default:
                    throw new Exception("There is not Scraper for this website");
            }
        }

        public static IUrlFilter BuildUrlFilter(string website)
        {
            return null;
        }
    }
}
