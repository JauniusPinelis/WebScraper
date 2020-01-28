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

namespace WebScraper.Application.Services
{
    public class CvOnlineScrapeService : BaseScrapeService, IScrapeService
    {
        private readonly IParser _parser;
        private readonly CvOnlineAnalyser _analyser;

        public CvOnlineScrapeService(IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory, IDataContext dataContext) : base(httpClientFactory, scraperFactory, dataContext)
        {
            _scraper = scraperFactory.BuildScraper(JobPortals.CvOnline);
            _parser = new CvOnlineParser();
            _analyser = new CvOnlineAnalyser();
        }

        public void Run()
        {
            ScrapePageUrls();
            ScrapePageInfos();
            //ScrapePageTags();
            ProcessSalaries();
        }

        public void ProcessSalaries()
        {
            var jobUrls = _context.JobUrls.Include(j => j.JobInfo)
              .Where(j => j.JobPortalId == (int)JobPortals.CvOnline && !String.IsNullOrEmpty(j.SalaryText)).ToList();

            foreach(var jobUrl in jobUrls)
            {
                var salary = _analyser.GetSalary(jobUrl.SalaryText);
                salary.JObUrlId = jobUrl.Id;
                _context.Salaries.Add(salary);
                _context.SaveChanges();
            }
        }

        public void ScrapePageUrls()
        {
            var baseUrls = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos?page=";

            var urls = ExtractPageUrls(baseUrls);

            var cvOnlineFilter = _scraperFactory.BuildUrlFilter(JobPortals.CvOnline);
            cvOnlineFilter.Apply(ref urls);
            _context.SaveChanges();

            UpdateUrls(urls);
        }

        public void ScrapePageInfos()
        {
            ScrapePageInfos("page-main-content", JobPortals.CvOnline); 
        }

        public void ScrapePageTags()
        {
            var jobUrls = _context.JobUrls.Include(j => j.JobInfo)
                .Where(j => j.JobPortalId == (int) JobPortals.CvOnline);

            var jobInfos = jobUrls.Select(j => j.JobInfo).ToList();

            //foreach (var jobInfo in jobInfos)
            //{
                
            //}
        }

        public void UpdateTags()
        {

        }
    }
}
