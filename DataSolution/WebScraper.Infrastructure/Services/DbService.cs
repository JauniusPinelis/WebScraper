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
        private IGenericRepository<Entities.JobUrl> _jobUrlRepository = null;
        private IMapper _mapper = null;

        public DbService(IGenericRepository<Entities.JobUrl> repository, IMapper mapper)
        {
            _jobUrlRepository = repository;
            _mapper = mapper;
        }

        public void InsertUrl(JobUrlDto jobUrl)
        {
            var entity = _mapper.Map<Entities.JobUrl>(jobUrl);
            var entities = _jobUrlRepository.GetAll().ToList();
            var urls = entities.Select(e => e.Url);

            if (!urls.Contains(entity.Url))
            {
                _jobUrlRepository.Insert(entity);
                _jobUrlRepository.Save();
            }
        }

        public void SaveHtmlData(List<JobHtmlDto> jobHtmls)
        {
            throw new NotImplementedException();
        }

        public void SaveUrlData(List<JobUrlDto> jobUrls)
        {
            jobUrls.ForEach(j => InsertUrl(j));
        }
    }
}
