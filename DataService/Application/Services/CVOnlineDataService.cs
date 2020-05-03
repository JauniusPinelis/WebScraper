using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using WebScraper.Application.CvOnline;
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
    public class CvOnlineDataService : IDataService
    {
        private readonly IParser _parser;

        private IUnitOfWork _unitOfWork;
        private IAnalyser _analyser;
        private IScraper _scraper;
        private IUrlFilter _filter;
        private HttpClient _httpClient;
        private ScrapeClient _scrapeClient;

        public CvOnlineDataService(IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory, IUnitOfWork unitOfWork) 
        {
            _parser = new CvOnlineParser();

            _unitOfWork = unitOfWork;
            _analyser = scraperFactory.BuildAnalyser(JobPortals.CvOnline);
            _scraper = scraperFactory.BuildScraper(JobPortals.CvOnline);
            _filter = scraperFactory.BuildUrlFilter(JobPortals.CvOnline);

            _httpClient = httpClientFactory.CreateClient(JobPortals.CvOnline.GetDescription());

            _scrapeClient = new ScrapeClient(_httpClient, _scraper);
        }

        public void Run()
        {
            new ScrapePageUrls(_unitOfWork,_analyser, _scrapeClient ).Do(JobPortals.CvOnline, _filter);
            new ScrapePageInfos(_unitOfWork, _analyser, _scrapeClient).Do();
            new ProcessSalaries(_unitOfWork, _analyser, _scrapeClient).Do(JobPortals.CvOnline);
        }
    }
}
