using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Serilog;
using Application.CvBankas;
using Application.Shared;
using Core.CvBankas;
using Core.CvLt;
using Core.Entities;
using Core.Enums;
using Core.Factories;
using Core.Shared;
using Infrastructure.Db;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class CvLtScrapeService : IDataService
    {
        private UnitOfWork _unitOfWork;
        private IAnalyser _analyser;
        private IScraper _scraper;
        private HttpClient _httpClient;
        private ScrapeClient _scrapeClient;


        public CvLtScrapeService(IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory, UnitOfWork unitOfWork) 
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
