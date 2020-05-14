using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Application.CvOnline;
using Application.Shared;
using Core.CvOnline;
using Core.Entities;
using Core.Enums;
using Core.Factories;
using Core.Shared;
using Infrastructure.Db;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class CvOnlineDataService : IDataService
    {
        private readonly IParser _parser;

        private UnitOfWork _unitOfWork;
        private IAnalyser _analyser;
        private IScraper _scraper;
        private IUrlFilter _filter;
        private HttpClient _httpClient;
        private ScrapeClient _scrapeClient;

        public CvOnlineDataService(IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory, UnitOfWork unitOfWork) 
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
