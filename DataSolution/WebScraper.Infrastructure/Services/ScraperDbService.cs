using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebScraper.Core.Dtos;
using WebScraper.Infrastructure.Db;
using WebScraper.Infrastructure.Entities;

namespace WebScraper.Infrastructure.Services
{
    public class ScraperDbService
    {
        private IGenericRepository<JobPortalPage> jobUrlRepository = null;
        private IMapper mapper = null;

        public ScraperDbService()
        {
            jobUrlRepository = new GenericRepository<JobPortalPage>();
        }

        public ScraperDbService(IGenericRepository<JobPortalPage> repository, IMapper mapper)
        {
            jobUrlRepository = repository;
            this.mapper = mapper;
        }

        public void InsertUrl(JobUrl jobUrl)
        {
            var entity = mapper.Map<JobPortalPage>(jobUrl);
            var entities = jobUrlRepository.GetAll().ToList();

            if (!entities.Contains(entity))
            {
                jobUrlRepository.Insert(entity);
                jobUrlRepository.Save();
            }
        }


    }
}
