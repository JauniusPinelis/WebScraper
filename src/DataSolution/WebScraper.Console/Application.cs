using Serilog;
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
            Log.Information("CVOnline: Starting to scrape data");
            _scrapeService.ScrapeCvOnlineData();
            Log.Information("CVBankas: Starting to scrape data");
            _scrapeService.ScrapeCvBankasData();
            Log.Information("CvLt: Starting to scrape data");
            _scrapeService.ScrapeCvLtData();
        }
    }
}
