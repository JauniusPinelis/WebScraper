using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebScraper.Core.Entities;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Infrastructure.Db
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IGenericRepository<JobUrl> _jobUrlRepository = null;
        private readonly IGenericRepository<JobInfo> _jobInfoRepository = null;
        private readonly IMapper _mapper = null;

        public UnitOfWork(
            IGenericRepository<JobUrl> jobUrlRepository, 
            IGenericRepository<JobInfo> jobInfoRepository,
            IMapper mapper)
        {
            _jobUrlRepository = jobUrlRepository;
            _jobInfoRepository = jobInfoRepository;
            _mapper = mapper;
        }

        public void SaveJobHtmls(List<JobInfo> jobHtmls)
        {
            jobHtmls.ForEach(j => InsertJobHtml(j));
        }

        public void SaveJobUrls(List<JobUrl> jobUrls)
        {
            jobUrls.ForEach(j => InsertJobUrl(j));
        }


        public void InsertJobUrl(JobUrl jobUrl)
        {
            var entity = _mapper.Map<JobUrl>(jobUrl);
            var entities = _jobUrlRepository.GetAll().ToList();
            var urls = entities.Select(e => e.Url);

            if (!urls.Contains(entity.Url))
            {
                _jobUrlRepository.Insert(entity);
                _jobUrlRepository.Save();
            }
        }

      
        public void InsertJobHtml(JobInfo jobHtml)
        {
            /*var htmlEntity = _mapper.Map<JobInfo>(jobHtml);
            var existingHtmls = _jobHtmlRepository.GetAll().Select(j => j.HtmlCode);

            if (!existingHtmls.Contains(htmlEntity.HtmlCode))
            {
                _jobHtmlRepository.Insert(htmlEntity);
                _jobHtmlRepository.Save();
            }*/
        }

        public void InsertOrUpdateInfo (JobInfo jobInfo)
        {
            var htmlEntity = _mapper.Map<JobInfo>(jobInfo);

            

            _jobInfoRepository.Insert(htmlEntity);
            _jobInfoRepository.Save();

            // Unfinished
            throw new NotImplementedException();

        }

        public IEnumerable<JobUrl> GetJobUrls()
        {
            var jobUrls = _jobUrlRepository.GetAll().ToList();
            return _mapper.Map<List<JobUrl>>(jobUrls);
        }

        public IEnumerable<JobInfo> GetJobInfos()
        {
            return _mapper.Map<List<JobInfo>>(_jobInfoRepository.GetAll());
        }
    }
}
