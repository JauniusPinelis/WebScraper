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

        public ScrapeService(IUnitOfWork unitOfWork, IScraperFactory factory)
        {
            _unitOfWork = unitOfWork;
            _scraperFactory = factory;
        }

        public void ImportInitialCvOnlineData()
        {
            var scraper = _scraperFactory.BuildScraper("CvOnline");

            // Get Urls
            var existingUrls = _unitOfWork.GetJobUrls();

            if (!existingUrls.Any())
            {

                var collectedUrls = scraper.ScrapePageUrls().ToList();

                var cvOnlineFilter = _scraperFactory.BuildUrlFilter("CvOnline");
                cvOnlineFilter.Apply(ref collectedUrls);

                _unitOfWork.SaveJobUrls(collectedUrls);
            }

            // Get Htmls
            var existingHtmls = _unitOfWork.GetJobHtmls();
            if (!existingHtmls.Any())
            {
                var htmlResults = scraper.ScrapeJobHtmls(_unitOfWork.GetJobUrls()).ToList();

                _unitOfWork.SaveJobHtmls(htmlResults);
            }

            // Parse Infos from Html
            var hmtlEntities = _unitOfWork.GetJobHtmls();
            var parser = _scraperFactory.BuildParser("cvonline");

            foreach (var htmlEntity in hmtlEntities)
            {
                var parseResult = parser.ParseInfo(htmlEntity);
                _unitOfWork.InsertJobInfo(parseResult);
            }
            

        }
    }
}
