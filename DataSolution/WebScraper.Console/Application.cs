using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core;
using WebScraper.Core.Dtos;
using WebScraper.Core.Factories;
using WebScraper.Core.Filters;
using WebScraper.Infrastructure.Db;
using WebScraper.Infrastructure.Entities;
using WebScraper.Infrastructure.Services;

namespace WebScraper.Console
{
    public class Application
    {
        private IUnitOfWork dbService;

        public Application(IUnitOfWork service)
        {
            dbService = service;
        }
        public void Run()
        {
            /*var scraper = ScraperFactory.BuildScraper("CvOnline");
            scraper.ScrapePageUrls();

            var cvOnlineFilter = new CvOnlineUrlFilter();
            scraper.ApplyUrlFilter(cvOnlineFilter);

            var results = scraper.UrlData;

           

            foreach (var result in results)
            {
                var jobPageEntity = new JobUrl()
                {
                    Url = result,
                    CategoryId = 1
                };
                dbService.InsertUrl(jobPageEntity);
            }
            */
            //var scraper = ScraperFactory.BuildScraper("CvOnline");

            //var scraper.ScrapeJobPortalInfo("https://www.cvonline.lt/darbo-skelbimas/baltic-underwriting-agency-ab/draudimo-riziku-vertintojas-a-d4032450.html");

        }
    }
}
