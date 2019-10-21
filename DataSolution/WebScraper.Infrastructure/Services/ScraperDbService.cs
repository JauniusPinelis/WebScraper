using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebScraper.Core.Dtos;
using WebScraper.Infrastructure.Db;
using WebScraper.Infrastructure.Entities;
using WebScraper.Infrastructure.Mappings;

namespace WebScraper.Infrastructure.Services
{
    public class ScraperDbService : IDbService
    {
        private IGenericRepository<JobPortalPage> jobUrlRepository = null;
        private IMapper mapper = null;

        public ScraperDbService()
        {
            jobUrlRepository = new GenericRepository<JobPortalPage>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            mapper = mappingConfig.CreateMapper();
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
            var urls = entities.Select(e => e.Url);

            if (!urls.Contains(entity.Url))
            {
                jobUrlRepository.Insert(entity);
                jobUrlRepository.Save();
            }
        }


    }
}
