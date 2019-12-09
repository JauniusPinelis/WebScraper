using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using Serilog;
using WebScraper.Core.CvOnline;
using WebScraper.Core.Entities;
using WebScraper.Core.Factories;
using WebScraper.Core.Shared;

namespace WebScraper.Application.Services
{
    public class CvOnlineScrapeService : BaseScrapeService
    {

        public CvOnlineScrapeService(IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory) : base(httpClientFactory)
        {
            _scraper = scraperFactory.BuildScraper("cvonline");
        }

        public void Run()
        {
            
        }

        public IEnumerable<JobUrl> ScrapePageUrls()
        {
            var baseUrl = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos?page=";

            return ScrapePageUrls(baseUrl);

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

                var html = _scraper.ScrapeJobPortalInfo(urls[i].Url);


                results.Add(new JobInfo()
                {
                    JobUrlId = urls[i].Id,
                    HtmlCode = html
                });
            }

            return results;
        }
    }
}
