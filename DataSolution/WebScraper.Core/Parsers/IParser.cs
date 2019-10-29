using WebScraper.Core.Dtos;

namespace WebScraper.Core.Parsers
{
    public interface IParser
    {
        ParseResult ParseInfo(JobHtmlDto jobHtml);
    }
}