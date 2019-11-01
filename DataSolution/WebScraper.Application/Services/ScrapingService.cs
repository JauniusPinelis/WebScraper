using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Application.JobUrls.Commands.CreateJobUrl;
using WebScraper.Application.JobUrls.GetJobsList;
using WebScraper.Core.Factories;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Application.Services
{
    public class ScrapingService : IScrapingService
    {
        private readonly IJobDbContext _context;
        private readonly IScraperFactory _scraperFactory;
        private IMediator _mediator;



        public ScrapingService(IJobDbContext context, IScraperFactory factory, IMediator mediator)
        {
            _context = context;
            _scraperFactory = factory;
            _mediator = mediator;
        }

        public async void ImportInitialCvOnlineData()
        {
            var scraper = _scraperFactory.BuildScraper("CvOnline");

            // Get Urls


            var getJobListQuery = new GetJobsListQuery();

            var result = _mediator.Send(new GetJobsListQuery()).Result;

            var test = "test";
        }
    }
}
