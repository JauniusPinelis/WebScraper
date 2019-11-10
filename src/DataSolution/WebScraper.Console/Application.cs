using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core;
using WebScraper.Core.Entities;
using WebScraper.Core.Factories;
using WebScraper.Core.Filters;
using WebScraper.Infrastructure.Db;
using WebScraper.Application.Services;

namespace WebScraper.Console
{
    public class Application
    {
        private IScrapingService _scrapeService;

        public Application(IScrapingService scrapeService)
        {
            _scrapeService = scrapeService;
        }
        public void Run()
        {
            _scrapeService.ImportInitialCvOnlineData();
        }
    }
}
