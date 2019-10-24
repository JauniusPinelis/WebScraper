using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebScraper.Core.Dtos;
using WebScraper.Infrastructure.Db;
using WebScraper.Infrastructure.Entities;
using WebScraper.Infrastructure.Mappings;

namespace WebScraper.Infrastructure.Db
{
    public class UnitOfWork : IUnitOfWork
    {
        private IGenericRepository<JobUrl> _jobUrlRepository = null;
        private IGenericRepository<JobHtml> _jobHtmlRepository = null;
        private IMapper _mapper = null;

        public UnitOfWork(IGenericRepository<JobUrl> jobUrlRepository, IGenericRepository<JobHtml> jobHtmlRepository, IMapper mapper)
        {
            _jobUrlRepository = jobUrlRepository;
            _jobHtmlRepository = jobHtmlRepository;
            _mapper = mapper;
        }

        public void SaveJobHtmls(List<JobHtmlDto> jobHtmls)
        {
            jobHtmls.ForEach(j => InsertJobHtml(j));
        }

        public void SaveJobUrls(List<JobUrlDto> jobUrls)
        {
            jobUrls.ForEach(j => InsertJobUrl(j));
        }


        public void InsertJobUrl(JobUrlDto jobUrl)
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

      
        public void InsertJobHtml(JobHtmlDto jobHtml)
        {
            var htmlEntity = _mapper.Map<JobHtml>(jobHtml);
            var existingHtmls = _jobHtmlRepository.GetAll().Select(j => j.HtmlCode);

            if (!existingHtmls.Contains(htmlEntity.HtmlCode))
            {
                _jobHtmlRepository.Insert(htmlEntity);
                _jobHtmlRepository.Save();
            }
        }

        public List<JobUrlDto> GetJobUrls()
        {
            return _mapper.Map<List<JobUrlDto>>( _jobUrlRepository.GetAll());
        }

        public List<JobHtmlDto> GetJobHtmls()
        {
            return _mapper.Map<List<JobHtmlDto>>(_jobHtmlRepository.GetAll());
        }
    }
}
