using System;
using System.Collections.Generic;
using System.Text;
using Core.CvBankas;
using Core.CvLt;
using Core.CvOnline;
using Core.Enums;
using Core.Shared;

namespace Core.Factories
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

        public IAnalyser BuildAnalyser(JobPortals website)
        {
            switch (website)
            {
                case JobPortals.CvOnline:
                    return new BaseAnalyser();
                case JobPortals.CvBankas:
                    return new BaseAnalyser();
                case JobPortals.CvLt:
                    return new BaseAnalyser();
                default:
                    throw new Exception("There is no Analyser for this website");
            }
        }
    }
}
