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
using WebScraper.Infrastructure.Repositories;

namespace WebScraper.Application.Services
{
    public class ApplicationRunner : IDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IScraperFactory _scraperFactory;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public ApplicationRunner(IUnitOfWork unitOfWork, IScraperFactory factory, 
             IMapper mapper, IHttpClientFactory clientFactory)
        {
            _unitOfWork = unitOfWork;
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

        public List<IDataService> InitScrapeServices()
        {
            var cvBankasScrapeService = new CvBankasDataService(_httpClientFactory, _scraperFactory, _unitOfWork);
            var cvLtScrapeService = new CvLtScrapeService(_httpClientFactory, _scraperFactory, _unitOfWork);
            var cvOnlineScrapeService = new CvOnlineDataService(_httpClientFactory, _scraperFactory, _unitOfWork);

            var scrapeServices = new List<IDataService>();
            scrapeServices.Add(cvBankasScrapeService);
            scrapeServices.Add(cvLtScrapeService);
            scrapeServices.Add(cvOnlineScrapeService);

            return scrapeServices;
        }
    }
}
