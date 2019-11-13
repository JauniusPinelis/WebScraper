using WebScraper.Core.Shared;

namespace WebScraper.Core.Factories
{
    public interface IScraperFactory
    {
        IScraper BuildScraper(string website);
        IUrlFilter BuildUrlFilter(string website);
        IParser BuildParser(string website);
    }
}