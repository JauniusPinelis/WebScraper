using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core;
using WebScraper.Core.Dtos;
using WebScraper.Core.Factories;
using WebScraper.Core.Filters;
using WebScraper.Infrastructure.Db;
using WebScraper.Infrastructure.Services;

namespace WebScraper.Console
{
    public class Application
    {
        private IScrapeService _scrapeService;

        public Application(IScrapeService scrapeService)
        {
            _scrapeService = scrapeService;
        }
        public void Run()
        {
            _scrapeService.ImportInitialCvOnlineData();
        }
    }
}
