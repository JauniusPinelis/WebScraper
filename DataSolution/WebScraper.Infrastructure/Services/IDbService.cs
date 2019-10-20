using WebScraper.Core.Dtos;

namespace WebScraper.Infrastructure.Services
{
    public interface IDbService
    {
        void InsertUrl(JobUrl jobUrl);
    }
}