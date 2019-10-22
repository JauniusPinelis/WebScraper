using WebScraper.Core.Filters;

namespace WebScraper.Core.Factories
{
    public interface IScraperFactory
    {
        IScraper BuildScraper(string website);
        IUrlFilter BuildUrlFilter(string website);
    }
}