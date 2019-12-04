using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using HtmlAgilityPack;
using WebScraper.Core.CvBankas;
using WebScraper.Core.CvOnline;
using WebScraper.Core.Entities;

namespace WebScraper.Application.Services
{
    public class CvBankasScrapeService : BaseScrapeService, IScrapeService
    {
        public CvBankasScrapeService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            // this can be done smarter
            _scraper = new CvBankasScraper();
        }

        public void Run()
        {

        }

        public IEnumerable<JobInfo> ScrapeJobHtmls(IEnumerable<JobUrl> urlDtos)
        {
            var urls = urlDtos.ToList();
            var results = new List<JobInfo>();

            /* As testing lets do only 20 page htmls for now - dont wanna 
             * overload the page */

            var limit = 10;
            var delay = 1000;

            for (int i = 0; i <= limit; i++)
            {
                Thread.Sleep(delay);

                var html = ScrapeJobHtml(urls[i].Url, "list_a can_visited list_a_has_logo");
             

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


    }
}
