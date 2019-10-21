using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core;
using WebScraper.Core.Dtos;
using WebScraper.Core.Filters;
using WebScraper.Infrastructure.Entities;
using WebScraper.Infrastructure.Services;

namespace WebScraper.Console
{
    public class Application
    {
        public void Run()
        {
            var scraper = new CvOnlineScraper();
            scraper.ScrapePageUrls();

            var cvOnlineFilter = new CvOnlineUrlFilter();
            scraper.ApplyUrlFilter(cvOnlineFilter);

            var results = scraper.UrlData;

            var service = (IFooService)serviceProvider.GetService(typeof(IFooService));

            foreach (var result in results)
            {
                var jobPageEntity = new JobUrl()
                {
                    Url = result,
                    CategoryId = 1
                };
                scraperDbService.InsertUrl(jobPageEntity);
            }
        }
    }
}
