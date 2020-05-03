using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using HtmlAgilityPack;
using WebScraper.Application.CvBankas;
using WebScraper.Application.Shared;
using WebScraper.Core.Entities;
using WebScraper.Core.Enums;
using WebScraper.Core.Factories;
using WebScraper.Core.Shared;
using WebScraper.Infrastructure.Db;
using WebScraper.Infrastructure.Repositories;

namespace WebScraper.Application.Services
{
    public class CvBankasDataService : BaseScrapeService, IScrapeService
    {

        private IUnitOfWork _unitOfWork;
        private IAnalyser _analyser;
        private IScraper _scraper;
        private HttpClient _httpClient;
        private ScrapeClient _scrapeClient;


        public CvBankasDataService(IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory, IUnitOfWork unitOfWork) 
            : base(JobPortals.CvBankas,httpClientFactory, scraperFactory, unitOfWork)
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

        public IEnumerable<JobInfo> ScrapeJobHtmls(IEnumerable<JobUrl> urlDtos)
        {
            var urls = urlDtos.ToList();
            var results = new List<JobInfo>();

            /* As testing lets do only 20 page htmls for now - dont wanna 
             * overload the page */

            var limit = 10;
            var delay = 1000;

            for (int i = 0; i <= limit; i++)
            {
                Thread.Sleep(delay);

                var html = ScrapeJobHtml(urls[i].Url, "list_a can_visited list_a_has_logo");
             

                results.Add(new JobInfo()
                {
                    JobUrlId = urls[i].Id,
                    HtmlCode = html
                });
            }

            return results;
        }

        public void ScrapePageInfos()
        {
            ScrapePageInfos("jobad_content_main", JobPortals.CvBankas);
        }
    }
}
