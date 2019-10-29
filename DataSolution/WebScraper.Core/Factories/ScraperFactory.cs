using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Filters;
using WebScraper.Core.Parsers;

namespace WebScraper.Core.Factories
{
    public class ScraperFactory : IScraperFactory
    {
        public IScraper BuildScraper(string website)
        {
            switch (website.ToLower())
            {
                case "cvonline":
                    return new CvOnlineScraper();
                default:
                    throw new Exception("There is no Scraper for this website");
            }
        }

        public IUrlFilter BuildUrlFilter(string website)
        {
            switch (website.ToLower())
            {
                case "cvonline":
                    return new CvOnlineUrlFilter();
                default:
                    throw new Exception("There is no Filter for this website");
            }
        }

        public IParser BuildParser(string website)
        {
            switch (website.ToLower())
            {
                case "cvonline":
                    return new CvOnlineParser();
                default:
                    throw new Exception("There is no parser for this website");
            }
        }
    }
}
