using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Infrastructure.Services
{
    public class ScrapeService : IScrapeService
    {
        private IUnitOfWork _unitOfWork;

        public ScrapeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void ImportInitialCvOnlineData()
        {
            throw new NotImplementedException();
        }
    }
}
