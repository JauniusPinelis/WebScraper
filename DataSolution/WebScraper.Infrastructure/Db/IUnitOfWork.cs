using System.Collections.Generic;
using WebScraper.Core.Dtos;
using WebScraper.Infrastructure.Entities;

namespace WebScraper.Infrastructure.Db
{
    public interface IUnitOfWork
    {
        IEnumerable<JobUrlDto> GetJobUrls();

        IEnumerable<JobHtmlDto> GetJobHtmls();

        void SaveJobUrls(IEnumerable<JobUrlDto> jobUrls);

        void SaveJobHtmls(IEnumerable<JobHtmlDto> jobHtmls);

        void InsertJobUrl(JobUrlDto jobUrl);

        void InsertJobHtml(JobHtmlDto jobHtml);
    }
}