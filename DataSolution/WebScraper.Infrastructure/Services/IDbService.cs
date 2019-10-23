using System.Collections.Generic;
using WebScraper.Core.Dtos;
using WebScraper.Infrastructure.Entities;

namespace WebScraper.Infrastructure.Services
{
    public interface IDbService
    {
        void SaveUrlData(List<JobUrl> jobUrls);

        void SaveHtmlData(List<JobHtmlDto> jobHtmls);

        void InsertUrl(JobUrlDto jobUrl);
    }
}