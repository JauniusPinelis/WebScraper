using Core.Enums;
using Core.Shared;

namespace Core.Factories
{
    public interface IScraperFactory
    {
        IScraper BuildScraper(JobPortals website);
        IUrlFilter BuildUrlFilter(JobPortals website);
        IParser BuildParser(JobPortals website);

        IAnalyser BuildAnalyser(JobPortals website);
    }
}