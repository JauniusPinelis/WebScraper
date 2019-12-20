using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.CvBankas;
using WebScraper.Core.CvLt;
using WebScraper.Core.CvOnline;
using WebScraper.Core.Enums;
using WebScraper.Core.Shared;

namespace WebScraper.Core.Factories
{
    public class ScraperFactory : IScraperFactory
    {
        public IScraper BuildScraper(JobPortals website)
        {
            switch (website)
            {
                case JobPortals.CvOnline:
                    return new CvOnlineScraper();
                case JobPortals.CvBankas:
                    return new CvBankasScraper();
                case JobPortals.CvLt:
                    return new CvLtScraper();
                default:
                    throw new Exception("There is no Scraper for this website");
            }
        }

        public IUrlFilter BuildUrlFilter(JobPortals website)
        {
            switch (website)
            {
                case JobPortals.CvOnline:
                    return new CvOnlineUrlFilter();
                default:
                    throw new Exception("There is no Filter for this website");
            }
        }

        public IParser BuildParser(JobPortals website)
        {
            switch (website)
            {
                case JobPortals.CvOnline:
                    return new CvOnlineParser();
                default:
                    throw new Exception("There is no parser for this website");
            }
        }
    }
}
