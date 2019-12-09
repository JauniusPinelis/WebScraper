using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using Serilog;
using WebScraper.Core.CvOnline;
using WebScraper.Core.Entities;
using WebScraper.Core.Factories;
using WebScraper.Core.Shared;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Application.Services
{
    public class CvOnlineScrapeService : BaseScrapeService
    {

        public CvOnlineScrapeService(IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory, IDataContext dataContext) : base(httpClientFactory, scraperFactory, dataContext)
        {
            _scraper = scraperFactory.BuildScraper("cvonline");
        }

        public void Run()
        {
            Log.Information("CvOnline - starting to scraper CvOnline");

            var collectedUrls = ScrapePageUrls().ToList();

            var cvOnlineFilter = _scraperFactory.BuildUrlFilter("CvOnline");
            cvOnlineFilter.Apply(ref collectedUrls);

            UpdateUrls(collectedUrls);



            Log.Information("CvOnline - CvOnline Urls saved");

            // Get Htmls
            var urlsInDb = _context.JobUrls;

            var htmlResults = ScrapeJobHtmls(urlsInDb.ToList());

            foreach (var html in htmlResults)
            {
                UpdateJobInfo(html);
            }

            /*
            // Parse Infos from Html

            var htmlEntities = _context.JobInfos;

            var parser = _scraperFactory.BuildParser("cvonline");

            foreach (var htmlEntity in htmlEntities)
            {
                var parseResult = parser.ParseInfo(htmlEntity);

                var entity = _context.JobInfos.Find(parseResult.Id);

                entity.Title = parseResult.Title;
                
            }**/
        }

        public IEnumerable<JobUrl> ScrapePageUrls()
        {
            var baseUrl = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos?page=";

            return ScrapePageUrls(baseUrl);

        }

        public IEnumerable<JobInfo> ScrapeJobHtmls(IEnumerable<JobUrl> urlDtos)
        {
            var urls = urlDtos.ToList();
            var results = new List<JobInfo>();

            /* As testing lets do only 20 page htmls for now - dont wanna 
             * overload the page */

            var limit = 10;
            var delay = 1000;

            for (int i = 0; i <= limit; i++)
            {
                Thread.Sleep(delay);

                var html = _scraper.ScrapeJobPortalInfo(urls[i].Url);


                results.Add(new JobInfo()
                {
                    JobUrlId = urls[i].Id,
                    HtmlCode = html
                });
            }

            return results;
        }
    }
}
