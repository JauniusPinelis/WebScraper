using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using HtmlAgilityPack;
using Serilog;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;
using Microsoft.Extensions.DependencyInjection;
using WebScraper.Core.Factories;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Application.Shared
{
    public class BaseScrapeService
    {
        protected IHttpClientFactory _httpClientFactory;
        protected IScraperFactory _scraperFactory;
        protected IScraper _scraper;
        protected IDataContext _context;

        protected const int _sleepTime = 300;
        protected const int _scrapeLimit = 200;

        public BaseScrapeService(IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory,  IDataContext context)
        {
            _scraperFactory = scraperFactory;
            _httpClientFactory = httpClientFactory;
            _context = context;
        }

        public IEnumerable<JobUrl> ScrapePageUrls(string baseUrl)
        {

            var webClient = new HttpClient();
            int pageCounter = 0;
            var continueParsing = true;
            var results = new List<JobUrl>();


            while (continueParsing && pageCounter < 20)
            {
                string html;
                try
                {
                    //Have some delay in parsing
                    Thread.Sleep(_sleepTime);

                    var validUrl = baseUrl + pageCounter;
                    pageCounter += 1;
                    Log.Information("Scraping page {pageIndex}", pageCounter);

                    html = webClient.GetStringAsync(validUrl).Result;
                }
                catch (Exception)
                {
                    // html is empty
                    html = "";
                }

                var pageResults = _scraper.ExtractPageUrls(html);

                // no more found - stop parsing
                if (!pageResults.Any())
                {
                    Log.Information("Finished scraping page urls");
                    continueParsing = false;
                }

                results.AddRange(pageResults);
            }

            return results;
        }

        public void UpdateJobInfo(JobInfo jobInfo)
        {

            JobInfo entity;
            var exists = _context.JobInfos.Any(j => j.HtmlCode == jobInfo.HtmlCode);

            if (exists)
            {
                entity = _context.JobInfos.SingleOrDefault(j => j.HtmlCode == jobInfo.HtmlCode);
            }
            else
            {
                entity = new JobInfo();
                _context.JobInfos.Add(entity);
            }

            entity.HtmlCode = jobInfo.HtmlCode;
            entity.JobUrlId = jobInfo.JobUrlId;

            _context.SaveChanges();

        }

        public void UpdateUrls(IList<JobUrl> jobUrls)
        {
            foreach (var jobUrl in jobUrls)
            {
                var urlsInDb = _context.JobUrls;
                var exists = urlsInDb.Any(j => j.Url == jobUrl.Url);

                if (!exists)
                {
                    _context.JobUrls.Add(jobUrl);
                    _context.SaveChanges();
                    Log.Information("{url} has been added", jobUrl.Url);
                }
                else
                {
                    Log.Information("{url} already exists", jobUrl.Url);
                }
            }
        }

        public string ScrapeJobHtml(string url, string contentId)
        {
            try
            {
                var webClient = _httpClientFactory.CreateClient();
                var html = webClient.GetStringAsync(url).Result;
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var resultNode = htmlDocument.DocumentNode.SelectSingleNode($"//div[contains(@id, '{contentId}')]");

                if (resultNode != null)
                    return resultNode.InnerHtml;
                return "";
            }

            catch (Exception)
            {
                return "";
            }
        }
    }
}
