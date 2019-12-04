using HtmlAgilityPack;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;

namespace WebScraper.Core.CvBankas
{
    public class CvBankasScraper :  BaseScraper, IScraper
    {
        public IEnumerable<JobInfo> ScrapeJobHtmls(IEnumerable<JobUrl> urlDtos)
        {
            var urls = urlDtos.ToList();
            var results = new List<JobInfo>();
            var webClient = new HttpClient();

            /* As testing lets do only 20 page htmls for now - dont wanna 
             * overload the page */

            var limit = 10;
            var delay = 1000;

            for (int i = 0; i <= limit; i++)
            {
                Thread.Sleep(delay);
                var html = ScrapeJobPortalInfo(urls[i].Url, webClient);

                results.Add(new JobInfo()
                {
                    JobUrlId = urls[i].Id,
                    HtmlCode = html
                });
            }

            return results;
        }

        public IEnumerable<JobUrl> ScrapePageUrls()
        {
            var baseUrl = "https://www.cvbankas.lt/?padalinys%5B0%5D=76&page=";

            return ScrapePageUrls(baseUrl);
        }

        public override JobUrl ScrapeJobUrlInfo(string html)
        {
            var scrapeInfo = new JobUrlScraperInfoModel()
            {
                Url = "//a[contains(@class, 'list_a can_visited list_a_has_logo')]",
                UrlAttribute = "href",
                Title = "//h3[contains(@class, 'list_h3')]",
                Salary = "//span[contains(@class, 'salary_amount')]",
                Location = "//span[contains(@class, 'list_city')]",
                Company = "//span[contains(@class, 'dib mt5')]"
            };
            return ScrapeJobUrlInfo(html, scrapeInfo, 2);
        }

        public override IEnumerable<JobUrl> ExtractPageUrls(string pageHtml)
        {
            return ExtractPageUrls(pageHtml, "//a[contains(@class, 'list_a can_visited list_a_has_logo')]");
        }

        private string ScrapeJobPortalInfo(string html)
        {
            return base.ScrapeJobHtml(html, "page-main-content");
        }

    }
}
