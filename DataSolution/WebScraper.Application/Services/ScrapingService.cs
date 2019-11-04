using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebScraper.Application.JobInfos.Commands.UpsertJobInfo;
using WebScraper.Application.JobInfos.Queries.GetJobInfos;
using WebScraper.Application.JobUrls.Commands.CreateJobUrl;
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
        private IMediator _mediator;
        private readonly IMapper _mapper;



        public ScrapingService(IJobDbContext context, IScraperFactory factory, 
            IMediator mediator, IMapper mapper)
        {
            _context = context;
            _scraperFactory = factory;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async void ImportInitialCvOnlineData()
        {
            var scraper = _scraperFactory.BuildScraper("CvOnline");

            // Get Urls
            var jobUrlsVm = _mediator.Send(new GetJobUrlsQuery()).Result;
            var jobUrls = jobUrlsVm.JobUrls;

            if (!jobUrls.Any())
            {

                var collectedUrls = scraper.ScrapePageUrls().ToList();

                var cvOnlineFilter = _scraperFactory.BuildUrlFilter("CvOnline");
                cvOnlineFilter.Apply(ref collectedUrls);

                foreach (var newUrl in collectedUrls)
                {
                    await _mediator.Send(new UpsertJobUrlCommand()
                    {
                        Id = newUrl.Id,
                        Url = newUrl.Url
                    });
                }
            }

            // Get Htmls
            var existingHtmlsVm = _mediator.Send(new GetJobInfosQuery()).Result;
            var existingHtmls = existingHtmlsVm.JobInfos;

            if (!existingHtmls.Any())
            {
                var htmlResults = scraper.ScrapeJobHtmls(_context.JobUrls.ToList());

                foreach(var html in htmlResults)
                {
                    await _mediator.Send(new UpsertJobInfoCommand()
                    {
                        Id = html.Id,
                        HtmlCode = html.HtmlCode
                    });
                }
            }

            // Parse Infos from Html
            var hmtlEntitiesVm = _mediator.Send(new GetJobInfosQuery()).Result;
            var htmlEntities = hmtlEntitiesVm.JobInfos;

            var mappedHtmlEntities = _mapper.Map<List<JobInfo>>(htmlEntities);

            var parser = _scraperFactory.BuildParser("cvonline");

            foreach (var htmlEntity in mappedHtmlEntities)
            {
                var parseResult = parser.ParseInfo(htmlEntity);

                //_mediator.Send(new UpsertJobInfoCommand(parseResult));
            }


            var test = "test";
        }
    }
}
