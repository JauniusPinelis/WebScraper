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
    public class DbService : IDbService
    {
        private IGenericRepository<Entities.JobUrl> jobUrlRepository = null;
        private IMapper mapper = null;

        public DbService(IGenericRepository<Entities.JobUrl> repository, IMapper mapper)
        {
            jobUrlRepository = repository;
            this.mapper = mapper;
        }

        public void InsertUrl(Core.Dtos.JobUrlDto jobUrl)
        {
            var entity = mapper.Map<Entities.JobUrl>(jobUrl);
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
