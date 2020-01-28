using WebScraper.Core.Enums;
using WebScraper.Core.Shared;

namespace WebScraper.Core.Factories
{
    public interface IScraperFactory
    {
        IScraper BuildScraper(JobPortals website);
        IUrlFilter BuildUrlFilter(JobPortals website);
        IParser BuildParser(JobPortals website);

        IAnalyser BuildAnalyser(JobPortals website);
    }
}