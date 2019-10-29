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
        private readonly IGenericRepository<JobUrl> _jobUrlRepository = null;
        private readonly IGenericRepository<JobHtml> _jobHtmlRepository = null;
        private readonly IGenericRepository<JobInfo> _jobInfoRepository = null;
        private readonly IMapper _mapper = null;

        public UnitOfWork(
            IGenericRepository<JobUrl> jobUrlRepository, 
            IGenericRepository<JobHtml> jobHtmlRepository,
            IGenericRepository<JobInfo> jobInfoRepository,
            IMapper mapper)
        {
            _jobUrlRepository = jobUrlRepository;
            _jobHtmlRepository = jobHtmlRepository;
            _jobInfoRepository = jobInfoRepository;
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

        public void InsertOrUpdateInfo (ParseResult jobInfo)
        {
            var htmlEntity = _mapper.Map<JobInfo>(jobInfo);

            var savedEntity = _jobUrlRepository

            _jobInfoRepository.Insert(htmlEntity);
            _jobInfoRepository.Save();

            // Unfinished
            throw new NotImplementedException();

        }

        public IEnumerable<JobUrlDto> GetJobUrls()
        {
            var jobUrls = _jobUrlRepository.GetAll().ToList();
            return _mapper.Map<List<JobUrlDto>>(jobUrls);
        }

        public IEnumerable<JobHtmlDto> GetJobHtmls()
        {
            return _mapper.Map<List<JobHtmlDto>>(_jobHtmlRepository.GetAll());
        }
    }
}
