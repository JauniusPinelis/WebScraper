using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebScraper.Core.CvBankas;
using WebScraper.Core.CvLt;
using WebScraper.Core.Entities;

namespace WebScraper.Application.Services
{
    public class CvLtScrapeService : BaseScrapeService, IScrapeService
    {
        public CvLtScrapeService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            // this can be done smarter
            _scraper = new CvLtScraper();
        }

        public IEnumerable<JobUrl> ScrapePageUrls()
        {
            var baseUrl = "https://www.cv.lt/employee/announcementsAll.do?regular=true&department=1040&page=";

            return ScrapePageUrls(baseUrl);
        }



        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
