using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using HtmlAgilityPack;
using Application.CvBankas;
using Application.Shared;
using Core.Entities;
using Core.Enums;
using Core.Factories;
using Core.Shared;
using Infrastructure.Db;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class CvBankasDataService : IDataService
    {

        private IUnitOfWork _unitOfWork;
        private IAnalyser _analyser;
        private IScraper _scraper;
        private HttpClient _httpClient;
        private ScrapeClient _scrapeClient;


        public CvBankasDataService(IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory, IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
            _analyser = scraperFactory.BuildAnalyser(JobPortals.CvBankas);
            _scraper = scraperFactory.BuildScraper(JobPortals.CvBankas);
            _httpClient = httpClientFactory.CreateClient(JobPortals.CvBankas.GetDescription());

            _scrapeClient = new ScrapeClient(_httpClient, _scraper);
        }

        public void Run()
        {
           new ScrapePageUrls(_unitOfWork, _analyser, _scrapeClient).Do(JobPortals.CvBankas);
           new ScrapePageInfos(_unitOfWork, _analyser, _scrapeClient).Do(JobPortals.CvBankas);
           new ProcessSalaries(_unitOfWork, _analyser, _scrapeClient).Do(JobPortals.CvBankas);
        }
       
    }
}
