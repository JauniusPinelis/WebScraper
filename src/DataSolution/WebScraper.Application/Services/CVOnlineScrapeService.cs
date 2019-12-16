﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Serilog;
using WebScraper.Application.Shared;
using WebScraper.Core.CvOnline;
using WebScraper.Core.Entities;
using WebScraper.Core.Factories;
using WebScraper.Core.Shared;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Application.Services
{
    public class CvOnlineScrapeService : BaseScrapeService, IScrapeService
    {

        public CvOnlineScrapeService(IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory, IDataContext dataContext) : base(httpClientFactory, scraperFactory, dataContext)
        {
            _scraper = scraperFactory.BuildScraper("cvonline");
        }

        public void Run()
        {
            ScrapePageUrls();
            ScrapePageInfos();
            ScrapePageTags();
        }



        public void ScrapePageUrls()
        {
            var baseUrls = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos?page=";

            var urls = ExtractPageUrls(baseUrls);

            var cvOnlineFilter = _scraperFactory.BuildUrlFilter("CvOnline");
            cvOnlineFilter.Apply(ref urls);
            _context.SaveChanges();

            UpdateUrls(urls);
        }

        public void ScrapePageInfos()
        {
            ScrapePageInfos("page-main-content", 1); 
        }

        public void ScrapePageTags()
        {

        }

        public void UpdateTags()
        {

        }
    }
}
