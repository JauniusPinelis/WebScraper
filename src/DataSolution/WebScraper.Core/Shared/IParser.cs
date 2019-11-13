using WebScraper.Core.Entities;

namespace WebScraper.Core.Shared
{
    public interface IParser
    {
        JobInfo ParseInfo(JobInfo jobHtml);
    }
}