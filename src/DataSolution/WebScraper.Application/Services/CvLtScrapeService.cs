using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Serilog;
using WebScraper.Core.CvBankas;
using WebScraper.Core.CvLt;
using WebScraper.Core.Entities;
using WebScraper.Core.Factories;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Application.Services
{
    public class CvLtScrapeService : BaseScrapeService, IScrapeService
    {
        public CvLtScrapeService(IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory, IDataContext context) : base(httpClientFactory, scraperFactory, context)
        {
            _scraper = scraperFactory.BuildScraper("cvlt");
        }

        public IEnumerable<JobUrl> ScrapePageUrls()
        {
            var baseUrl = "https://www.cv.lt/employee/announcementsAll.do?regular=true&department=1040&page=";

            return ScrapePageUrls(baseUrl);
        }



        public void Run()
        {
            var collectedUrls  = ScrapePageUrls();

            Log.Information("CvLtScraper - saving urls to db");
            UpdateUrls(collectedUrls.ToList());
        }
    }
}
