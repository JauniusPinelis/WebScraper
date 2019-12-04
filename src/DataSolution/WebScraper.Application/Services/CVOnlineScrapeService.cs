using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using Serilog;
using WebScraper.Core.CvOnline;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;

namespace WebScraper.Application.Services
{
    public class CvOnlineScrapeService : BaseScrapeService
    {

        public CvOnlineScrapeService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            // this can be done smarter
            _scraper = new CvOnlineScraper();
        }

        public void Run()
        {
            
        }

        public IEnumerable<JobUrl> ScrapePageUrls()
        {
            var baseUrl = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos?page=";

            return ScrapePageUrls(baseUrl);

        }

        public IEnumerable<JobInfo> ScrapePageHtmls()
        {

        }
    }
}
