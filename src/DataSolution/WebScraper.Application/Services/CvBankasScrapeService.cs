using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using HtmlAgilityPack;
using WebScraper.Application.Shared;
using WebScraper.Core.CvBankas;
using WebScraper.Core.CvOnline;
using WebScraper.Core.Entities;
using WebScraper.Core.Enums;
using WebScraper.Core.Factories;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Application.Services
{
    public class CvBankasScrapeService : BaseScrapeService, IScrapeService
    {
        public CvBankasScrapeService(IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory, IDataContext context) 
            : base(JobPortals.CvBankas,httpClientFactory, scraperFactory, context)
        {

        }

        public void Run()
        {
            

            //ScrapePageUrls();
            //ScrapePageInfos();
            //ProcessSalaries();
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

                var html = ScrapeJobHtml(urls[i].Url, "list_a can_visited list_a_has_logo");
             

                results.Add(new JobInfo()
                {
                    JobUrlId = urls[i].Id,
                    HtmlCode = html
                });
            }

            return results;
        }

        public void ScrapePageUrls()
        {
            var baseUrl = "https://www.cvbankas.lt/?padalinys%5B0%5D=76&page=";
            var urls = ExtractPageUrls(baseUrl);
            UpdateUrls(urls);
        }

        public void ScrapePageInfos()
        {
            ScrapePageInfos("jobad_content_main", JobPortals.CvBankas);
        }
    }
}
