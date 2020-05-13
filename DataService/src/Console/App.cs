using Serilog;
using Application.Services;

namespace Console
{
    public class App
    {
        private IDataService _scrapeService;

        public App(IDataService scrapeService)
        {
            _scrapeService = scrapeService;
        }
        public void Run()
        {
            _scrapeService.Run();
        }
    }
}
