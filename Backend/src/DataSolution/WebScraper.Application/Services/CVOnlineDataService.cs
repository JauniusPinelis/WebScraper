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
    public class CvOnlineDataService : BaseScrapeService, IScrapeService
    {
        private readonly IParser _parser;

        public CvOnlineDataService(IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory, IUnitOfWork unitOfWork) 
            : base(JobPortals.CvOnline, httpClientFactory, scraperFactory, unitOfWork)
        {
            _parser = new CvOnlineParser();
        }

        public void Run()
        {
            ScrapePageUrls();
            ScrapePageInfos();
            ScrapeTags();
            ProcessSalaries();
        }

        public void ScrapeTags()
        {

            var jobUrls = _unitOfWork.JobUrlRepository.GetAll().Where(j => j.JobPortalId == (int) JobPortals.CvOnline).ToList();

           // jobInfos = _unitOfWork.JobInfoRepository.GetAll().Where(j => j.JobUrlId)
        }

        public override void ScrapePageUrls()
        {
            var urls = ExtractPageUrls();

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
