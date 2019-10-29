using WebScraper.Core.Filters;
using WebScraper.Core.Parsers;

namespace WebScraper.Core.Factories
{
    public interface IScraperFactory
    {
        IScraper BuildScraper(string website);
        IUrlFilter BuildUrlFilter(string website);
        IParser BuildParser(string website);
    }
}