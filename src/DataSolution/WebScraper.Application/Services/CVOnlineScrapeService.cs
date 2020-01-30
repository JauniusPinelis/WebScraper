using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Serilog;
using WebScraper.Application.Shared;
using WebScraper.Core.CvOnline;
using WebScraper.Core.Entities;
using WebScraper.Core.Enums;
using WebScraper.Core.Factories;
using WebScraper.Core.Shared;
using WebScraper.Infrastructure.Db;
using WebScraper.Infrastructure.Repositories;

namespace WebScraper.Application.Services
{
    public class CvOnlineScrapeService : BaseScrapeService, IScrapeService
    {
        private readonly IParser _parser;

        public CvOnlineScrapeService(IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory, IUnitOfWork unitOfWork) 
            : base(JobPortals.CvOnline, httpClientFactory, scraperFactory, unitOfWork)
        {
            _parser = new CvOnlineParser();
        }

        public void Run()
        {
            //ScrapePageUrls();
            //ScrapePageInfos();
            //ScrapePageTags();
            //ProcessSalaries();
        }

       

        public void ScrapePageUrls()
        {
            var baseUrls = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos?page=";

            var urls = ExtractPageUrls(baseUrls);

            var cvOnlineFilter = _scraperFactory.BuildUrlFilter(JobPortals.CvOnline);
            cvOnlineFilter.Apply(ref urls);
            

            UpdateUrls(urls);
        }

        public void ScrapePageInfos()
        {
            ScrapePageInfos("page-main-content", JobPortals.CvOnline); 
        }
    }
}
