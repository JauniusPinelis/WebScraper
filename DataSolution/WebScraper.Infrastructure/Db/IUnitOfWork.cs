using System.Collections.Generic;
using WebScraper.Core.Entities;

namespace WebScraper.Infrastructure.Db
{
    public interface IUnitOfWork
    {
        IEnumerable<JobUrl> GetJobUrls();

        IEnumerable<JobInfo> GetJobInfos();

        void SaveJobUrls(List<JobUrl> jobUrls);

        void SaveJobHtmls(List<JobInfo> jobHtmls);

        void InsertJobUrl(JobUrl jobUrl);

        void InsertJobHtml(JobInfo jobHtml);

        void InsertOrUpdateInfo(JobInfo jobInfo);

    }
}