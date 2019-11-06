using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebScraper.Application.JobInfos.Commands.UpsertJobInfo;
using WebScraper.Application.JobInfos.Queries.GetJobInfos;
using WebScraper.Application.JobUrls.Commands.CreateJobUrl;
using WebScraper.Application.JobUrls.Commands.UpsertJobUrl;
using WebScraper.Application.JobUrls.GetJobsUrls;
using WebScraper.Core.Entities;
using WebScraper.Core.Factories;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Application.Services
{
    public class ScrapingService : IScrapingService
    {
        private readonly IJobDbContext _context;
        private readonly IScraperFactory _scraperFactory;
        private readonly IMapper _mapper;



        public ScrapingService(IJobDbContext context, IScraperFactory factory, 
            IMediator mediator, IMapper mapper)
        {
            _context = context;
            _scraperFactory = factory;
            _mapper = mapper;
        }

        public void UpdateJobInfo(JobInfo jobInfo)
        {
            
            JobInfo entity;
            var exists = _context.JobInfos.Any(j => j.HtmlCode == jobInfo.HtmlCode);

            if (exists)
            {
                entity = _context.JobInfos.SingleOrDefault(j => j.HtmlCode == jobInfo.HtmlCode);
            }
            else
            {
                entity = new JobInfo();
                _context.JobInfos.Add(entity);
            }

            entity.HtmlCode = jobInfo.HtmlCode;
            entity.JobUrlId = jobInfo.JobUrlId;

            _context.SaveChanges();

        }

        public void UpdateUrls(IList<JobUrl> jobUrls)
        {
            foreach(var jobUrl in jobUrls)
            {
                var urlsInDb = _context.JobUrls;
                var exists = urlsInDb.Any(j => j.Url == jobUrl.Url);

                if (!exists)
                {
                    _context.JobUrls.Add(new JobUrl()
                    {
                        Url = jobUrl.Url
                    });
                }

            }

            _context.SaveChanges();
        }

        public async void ImportInitialCvOnlineData()
        {
            var scraper = _scraperFactory.BuildScraper("CvOnline");

            // Get Urls
            var jobUrls = _context.JobUrls;

            if (!jobUrls.Any())
            {

                var collectedUrls = scraper.ScrapePageUrls().ToList();

                var cvOnlineFilter = _scraperFactory.BuildUrlFilter("CvOnline");
                cvOnlineFilter.Apply(ref collectedUrls);

                UpdateUrls(collectedUrls);
               
            }

            // Get Htmls
            var urlsInDb = _context.JobUrls;

            if (urlsInDb.Any())
            {
                var htmlResults = scraper.ScrapeJobHtmls(urlsInDb.ToList());

                foreach(var html in htmlResults)
                {
                    UpdateJobInfo(html);
                }
            }

            // Parse Infos from Html
            //var hmtlEntitiesVm = _mediator.Send(new GetJobInfosQuery()).Result;
            //var htmlEntities = hmtlEntitiesVm.JobInfos;

            //var mappedHtmlEntities = _mapper.Map<List<JobInfo>>(htmlEntities);

            //var parser = _scraperFactory.BuildParser("cvonline");

            //foreach (var htmlEntity in mappedHtmlEntities)
            //{
            //    var parseResult = parser.ParseInfo(htmlEntity);

            //    //_mediator.Send(new UpsertJobInfoCommand(parseResult));
            //}


            var test = "test";
        }
    }
}
