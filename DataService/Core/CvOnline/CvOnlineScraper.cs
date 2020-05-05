using System.Collections.Generic;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;

namespace WebScraper.Core.CvOnline
{
    public class CvOnlineScraper : BaseScraper, IScraper
    {
        private const int _jobPortalId = 1;
      
        public override IEnumerable<JobUrl> ExtractPageUrls(string pageHtml)
        {
            return ExtractPageUrls(pageHtml, "//div[contains(@class, 'offer_primary_info')]");
        }

        public override JobUrl ScrapeJobUrlInfo(string html)
        {
            var scrapeInfo = new JobUrlScraperInfoModel()
            {
                Url = "//a[contains(@href, 'job-ad')]",
                UrlAttribute = "href",
                Title = "//a[contains(@href, 'job-ad')]",
                TitleAttribute = "title",
                Salary = "//span[contains(@class, 'salary-blue')]",
                Location = "//a[contains(@itemprop, 'address')]",
                Company = "//a[contains(@itemprop, 'name')]",
                Logo = "//img/@src",
                LogoAttribute = "src"
            };
            return ScrapeJobUrlInfo(html, scrapeInfo, 1);
        }

        public string ScrapeJobPortalInfo(string html)
        {
            return base.ScrapeJobHtml( html , "page-main-content");
        }
    }
}
