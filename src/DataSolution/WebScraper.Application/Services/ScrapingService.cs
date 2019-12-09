using AutoMapper;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using WebScraper.Core.Entities;
using WebScraper.Core.Factories;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Application.Services
{
    public class ScrapingService : IScrapingService
    {
        private readonly IDataContext _context;
        private readonly IScraperFactory _scraperFactory;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public ScrapingService(IDataContext context, IScraperFactory factory, 
             IMapper mapper, IHttpClientFactory clientFactory)
        {
            _context = context;
            _scraperFactory = factory;
            _mapper = mapper;
            _httpClientFactory = clientFactory;
        }

        public void Run()
        {
            Log.Information("CVOnline: Starting to scrape data");
            ScrapeCvOnlineData();
            //Log.Information("CVBankas: Starting to scrape data");
            //ScrapeCvBankasData();
            //Log.Information("CvLt: Starting to scrape data");
            //ScrapeCvLtData();
        }

       

      

        public void ScrapeCvBankasData()
        { 

            var scrapeService = new CvBankasScrapeService(_httpClientFactory, _scraperFactory, _context);
            
        }

        public void ScrapeCvLtData()
        {

            var scrapeService = new CvLtScrapeService(_httpClientFactory, _scraperFactory, _context);

        }

        public void ScrapeCvOnlineData()
        {
            
        }
    }
}
