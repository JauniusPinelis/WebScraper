using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebScraper.Core.Factories;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Infrastructure.Services
{
    public class ScrapeService : IScrapeService
    {
        private IUnitOfWork _unitOfWork;
        private IScraperFactory _scraperFactory;

        public ScrapeService(IUnitOfWork unitOfWork, IScraperFactory factory )
        {
            _unitOfWork = unitOfWork;
            _scraperFactory = factory;
        }

        public void ImportInitialCvOnlineData()
        {
            var scraper = _scraperFactory.BuildScraper("CvOnline");

            var existingUrls = _unitOfWork.GetJobUrls();

            if (!existingUrls.Any())
            {

                var collectedUrls = scraper.ScrapePageUrls().ToList();

                var cvOnlineFilter = _scraperFactory.BuildUrlFilter("CvOnline");
                cvOnlineFilter.Apply(collectedUrls);

                _unitOfWork.SaveJobUrls(collectedUrls);
            }

            var existingHtmls = _unitOfWork.GetJobHtmls();
            if (!existingHtmls.Any())
            {
                var htmlResults = scraper.ScrapeJobHtmls(_unitOfWork.GetJobUrls());

                _unitOfWork.SaveJobHtmls(htmlResults);
            }
                //var scraper = ScraperFactory.BuildScraper("CvOnline");

                //var scraper.ScrapeJobPortalInfo("https://www.cvonline.lt/darbo-skelbimas/baltic-underwriting-agency-ab/draudimo-riziku-vertintojas-a-d4032450.html");
            }
        }
}
