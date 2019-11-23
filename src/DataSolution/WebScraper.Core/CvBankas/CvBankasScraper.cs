using HtmlAgilityPack;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;

namespace WebScraper.Core.CvBankas
{
    public class CvBankasScraper :  BaseScraper, IScraper
    {

        public IEnumerable<JobInfo> ScrapeJobHtmls(IEnumerable<JobUrl> urlDtos)
        {
            var urls = urlDtos.ToList();
            var results = new List<JobInfo>();
            var webClient = new HttpClient();

            /* As testing lets do only 20 page htmls for now - dont wanna 
             * overload the page */

            var limit = 10;
            var delay = 1000;

            for (int i = 0; i <= limit; i++)
            {
                Thread.Sleep(delay);
                var html = ScrapeJobPortalInfo(urls[i].Url, webClient);

                results.Add(new JobInfo()
                {
                    JobUrlId = urls[i].Id,
                    HtmlCode = html
                });
            }

            return results;
        }

        public IEnumerable<JobUrl> ScrapePageUrls()
        {
            var baseUrl = "https://www.cvbankas.lt/?padalinys%5B0%5D=76&page=";
            var webClient = new HttpClient();
            int pageCounter = 1;
            var continueParsing = true;
            var results = new List<JobUrl>();


            while (continueParsing && pageCounter <= 10)
            {
                //Have some delay in parsing
                Thread.Sleep(1000);

                var validUrl = baseUrl + pageCounter;
                pageCounter += 1;
                Log.Information("CvBankas: scraping page {pageIndex}", pageCounter);

                var html = webClient.GetStringAsync(validUrl).Result;

                var pageResults = ExtractPageUrls(html);

                // no more found - stop parsing
                if (!pageResults.Any())
                {
                    Log.Information("CvBankas: finished scraping page urls");
                    continueParsing = false;
                }
                results.AddRange(pageResults);
            }

            return results;
        }

        public JobUrl ScrapeJobUrlInfo(string html)
        {

            var resultHtml = new HtmlDocument();
            resultHtml.LoadHtml(html);

            var url = resultHtml.DocumentNode.FirstChild.Attributes["href"].Value;
            var title = resultHtml.DocumentNode.SelectSingleNode("//h3[contains(@class, 'list_h3')]");
            var salary = resultHtml.DocumentNode.SelectSingleNode("//span[contains(@class, 'salary_amount')]");
            var location = resultHtml.DocumentNode.SelectSingleNode("//span[contains(@class, 'list_city')]");
            var company = resultHtml.DocumentNode.SelectSingleNode("//span[contains(@class, 'dib mt5')]");

            return new JobUrl()
            {
                Url = url,
                Salary = salary?.InnerText ?? "",
                Title = title.InnerText,
                Location = location?.InnerText,
                Company = company?.InnerText,
                JobPortalId = 2

            };
        }

        public IEnumerable<JobUrl> ExtractPageUrls(string html)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var resultNodes = htmlDocument.DocumentNode.SelectNodes("//a[contains(@class, 'list_a can_visited list_a_has_logo')]");

            if (resultNodes.Count == 0)
            {
                return jobUrls;
            }

            foreach (var resultNode in resultNodes)
            {
                jobUrls.Add(ScrapeJobUrlInfo(resultNode.OuterHtml));
            }

            return jobUrls;
        }

        private string ScrapeJobPortalInfo(string url, HttpClient webClient)
        {
            try
            {
                var html = webClient.GetStringAsync(url).Result;
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var resultNode = htmlDocument.DocumentNode.SelectSingleNode("//div[contains(@id, 'page-main-content')]");

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
