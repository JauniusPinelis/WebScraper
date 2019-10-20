using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Dtos;
using WebScraper.Infrastructure.Db;
using WebScraper.Infrastructure.Entities;

namespace WebScraper.Infrastructure.Services
{
    public class ScraperDbService
    {
        private IGenericRepository<JobPortalPage> jobUrlRepository = null;

        public ScraperDbService()
        {
            jobUrlRepository = new GenericRepository<JobPortalPage>();
        }

        public ScraperDbService(IGenericRepository<JobPortalPage> repository)
        {
            jobUrlRepository = repository;
        }

        public void InsertUrl(JobUrl jobUrl)
        {
            var entity = _mapper.Map<JobPortalPage>(jobUrl);
        }


    }
}
