using System.Collections.Generic;
using WebScraper.Core.Dtos;
using WebScraper.Infrastructure.Entities;

namespace WebScraper.Infrastructure.Db
{
    public interface IUnitOfWork
    {
        IEnumerable<JobUrlDto> GetJobUrls();

        IEnumerable<JobHtmlDto> GetJobHtmls();

        void SaveJobUrls(List<JobUrlDto> jobUrls);

        void SaveJobHtmls(List<JobHtmlDto> jobHtmls);

        void InsertJobUrl(JobUrlDto jobUrl);

        void InsertJobHtml(JobHtmlDto jobHtml);
    }
}