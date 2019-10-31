using WebScraper.Core.Entities;

namespace WebScraper.Core.Parsers
{
    public interface IParser
    {
        JobInfo ParseInfo(JobInfo jobHtml);
    }
}