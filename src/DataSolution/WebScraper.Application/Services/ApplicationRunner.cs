using AutoMapper;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using WebScraper.Application.Shared;
using WebScraper.Core.Entities;
using WebScraper.Core.Factories;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Application.Services
{
    public class ApplicationRunner : IScrapeService
    {
        private readonly IDataContext _context;
        private readonly IScraperFactory _scraperFactory;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public ApplicationRunner(IDataContext context, IScraperFactory factory, 
             IMapper mapper, IHttpClientFactory clientFactory)
        {
            _context = context;
            _scraperFactory = factory;
            _mapper = mapper;
            _httpClientFactory = clientFactory;
        }

        public void Run()
        {
            var services = InitScrapeServices();

            foreach (var scrapeService in services)
            {
                scrapeService.Run();
            }
        }

        public List<IScrapeService> InitScrapeServices()
        {
            var cvBankasScrapeService = new CvBankasScrapeService(_httpClientFactory, _scraperFactory, _context);
            var cvLtScrapeService = new CvLtScrapeService(_httpClientFactory, _scraperFactory, _context);
            var cvOnlineScrapeService = new CvLtScrapeService(_httpClientFactory, _scraperFactory, _context);

            var scrapeServices = new List<IScrapeService>();
            scrapeServices.Add(cvBankasScrapeService);
            scrapeServices.Add(cvLtScrapeService);
            scrapeServices.Add(cvOnlineScrapeService);

            return scrapeServices;
        }
    }
}
