using Serilog;
using WebScraper.Application.Services;
using WebScraper.Application.Shared;

namespace WebScraper.Console
{
    public class Application
    {
        private IDataService _scrapeService;

        public Application(IDataService scrapeService)
        {
            _scrapeService = scrapeService;
        }
        public void Run()
        {
            _scrapeService.Run();
        }
    }
}
