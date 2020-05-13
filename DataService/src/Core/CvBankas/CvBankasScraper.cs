using HtmlAgilityPack;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using Core.Entities;
using Core.Shared;

namespace Core.CvBankas
{
    public class CvBankasScraper :  BaseScraper, IScraper
    {

        public override JobUrl ScrapeJobUrlInfo(string html)
        {
            var scrapeInfo = new JobUrlScraperInfoModel()
            {
                Url = "//a[contains(@class, 'list_a can_visited list_a_has_logo')]",
                UrlAttribute = "href",
                Title = "//h3[contains(@class, 'list_h3')]",
                Salary = "//span[contains(@class, 'salary_amount')]",
                Location = "//span[contains(@class, 'list_city')]",
                Company = "//span[contains(@class, 'dib mt5')]",
                Logo = "//img/@src",
                LogoAttribute = "src"

            };
            return ScrapeJobUrlInfo(html, scrapeInfo, 2);
        }

        public override IEnumerable<JobUrl> ExtractPageUrls(string pageHtml)
        {
            return ExtractPageUrls(pageHtml, "//a[contains(@class, 'list_a can_visited list_a_has_logo')]");
        }

        public string ScrapeJobPortalInfo(string html)
        {
            return base.ScrapeJobHtml(html, "page-main-content");
        }

       
    }
}
