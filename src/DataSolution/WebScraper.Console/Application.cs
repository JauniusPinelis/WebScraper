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
