using WebScraper.Core.Dtos;

namespace WebScraper.Core.Parsers
{
    public interface IParser
    {
        JobInfo ParseInfo(JobInfo jobHtml);
    }
}