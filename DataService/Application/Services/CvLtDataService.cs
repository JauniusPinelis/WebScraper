using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Serilog;
using WebScraper.Application.CvBankas;
using WebScraper.Application.Shared;
using WebScraper.Core.CvBankas;
using WebScraper.Core.CvLt;
using WebScraper.Core.Entities;
using WebScraper.Core.Enums;
using WebScraper.Core.Factories;
using WebScraper.Core.Shared;
using WebScraper.Infrastructure.Db;
using WebScraper.Infrastructure.Repositories;

namespace WebScraper.Application.Services
{
    public class CvLtScrapeService : IDataService
    {
        private IUnitOfWork _unitOfWork;
        private IAnalyser _analyser;
        private IScraper _scraper;
        private HttpClient _httpClient;
        private ScrapeClient _scrapeClient;


        public CvLtScrapeService(IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory, IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
            _analyser = scraperFactory.BuildAnalyser(JobPortals.CvLt);
            _scraper = scraperFactory.BuildScraper(JobPortals.CvLt);
            _httpClient = httpClientFactory.CreateClient(JobPortals.CvLt.GetDescription());

            _scrapeClient = new ScrapeClient(_httpClient, _scraper);
        }

        public void Run()
        {
            new ScrapePageUrls(_unitOfWork, _analyser, _scrapeClient).Do(JobPortals.CvLt);
            new ScrapePageInfos(_unitOfWork, _analyser, _scrapeClient).Do(JobPortals.CvLt);
            new ProcessSalaries(_unitOfWork, _analyser, _scrapeClient).Do(JobPortals.CvLt);
        }

    }
}
