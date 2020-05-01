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
    public class ApplicationRunner : IScrapeService
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

        /// <summary>
        /// Run all Services
        /// </summary>
        public void Run() => InitScrapeServices().ToList().ForEach(s => s.Run());




        public IEnumerable<IScrapeService> InitScrapeServices() => 
            new List<IScrapeService>()
            {   new CvBankasDataService(_httpClientFactory, _scraperFactory, _unitOfWork),
                new CvLtScrapeService(_httpClientFactory, _scraperFactory, _unitOfWork),
                new CvOnlineDataService(_httpClientFactory, _scraperFactory, _unitOfWork) 
            };

    }
}
