using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Infrastructure.Db;
using WebScraper.Infrastructure.Entities;

namespace WebScraper.Infrastructure.Services
{
    public class ScraperService
    {
        private IGenericRepository<JobPortalPage> jobUrlRepository = null;

        public ScraperService()
        {
            jobUrlRepository = new GenericRepository<JobPortalPage>();
        }

        public ScraperService(IGenericRepository<JobPortalPage> repository)
        {
            jobUrlRepository = repository;
        }


    }
}
