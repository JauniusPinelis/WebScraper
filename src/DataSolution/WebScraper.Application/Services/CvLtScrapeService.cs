using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Serilog;
using WebScraper.Application.Shared;
using WebScraper.Core.CvBankas;
using WebScraper.Core.CvLt;
using WebScraper.Core.Entities;
using WebScraper.Core.Enums;
using WebScraper.Core.Factories;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Application.Services
{
    public class CvLtScrapeService : BaseScrapeService, IScrapeService
    {
        public CvLtScrapeService(IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory, IDataContext context) 
            : base(JobPortals.CvLt, httpClientFactory, scraperFactory, context)
        {
           
        }

        public void ScrapePageUrls()
        {
            var baseUrl = "https://www.cv.lt/employee/announcementsAll.do?regular=true&department=1040&page=";

            var urls = ExtractPageUrls(baseUrl);
            UpdateUrls(urls);
        }

        public void ScrapePageInfos()
        {
            ScrapePageInfos("jobCont", JobPortals.CvLt);
        }

        public void Run()
        {
            ScrapePageUrls();
            ScrapePageInfos();
        }

    }
}
