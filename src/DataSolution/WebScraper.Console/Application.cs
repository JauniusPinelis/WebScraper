using Serilog;
using WebScraper.Application.Services;
using WebScraper.Application.Shared;

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
            _scrapeService.Run();
        }
    }
}
