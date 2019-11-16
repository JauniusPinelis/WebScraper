using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;

namespace WebScraper.Core.CvOnline
{
    public class CvOnlineScraper : IScraper
    {
        private const int _jobPortalId = 1;
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

        public IEnumerable<JobUrl> ExtractPageUrls(string pageHtml)
        {
            var results = new List<JobUrl>();

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(pageHtml);

            var resultNodes = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'offer_primary_info')]");

            if (resultNodes.Count == 0)
            {
                return results;
            }

            foreach (var resultNode in resultNodes)
            {
                results.Add(ScrapeJobUrlInfo(resultNode.OuterHtml));
            }

            return results;
        }

        public IEnumerable<JobUrl> ScrapePageUrls()
        {
            var baseUrl = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos?page=";
            var webClient = new HttpClient();
            int pageCounter = 0;
            var continueParsing = true;
            var results = new List<JobUrl>();


            while (continueParsing && pageCounter < 3)
            {
                //Have some delay in parsing
                Thread.Sleep(1000);

                var validUrl = baseUrl + pageCounter;
                pageCounter += 1;

                var html = webClient.GetStringAsync(validUrl).Result;

                var pageResults = ExtractPageUrls(html);
                results.AddRange(pageResults);
            }

            return results;
        }

        public JobUrl ScrapeJobUrlInfo(string html)
        {

            var resultHtml = new HtmlDocument();
            resultHtml.LoadHtml(html);

            var url = resultHtml.DocumentNode.SelectSingleNode("//a[contains(@href, 'job-ad')]");
            var salary = resultHtml.DocumentNode.SelectSingleNode("//span[contains(@class, 'salary-blue')]");
            var location = resultHtml.DocumentNode.SelectSingleNode("//a[contains(@itemprop, 'address')]");
            var company = resultHtml.DocumentNode.SelectSingleNode("//a[contains(@itemprop, 'name')]");

            return new JobUrl()
            {
                Url = url?.GetAttributeValue("href", string.Empty),
                Salary = salary?.InnerText ?? "",
                Title = url?.InnerText,
                Location = location?.InnerText,
                Company = company?.InnerText,
                JobPortalId = 1
            };
        }

        private string TrimStart(string target, string trimString)
        {
            if (string.IsNullOrEmpty(trimString)) return target;

            string result = target;
            while (result.StartsWith(trimString))
            {
                result = result.Substring(trimString.Length);
            }

            return result;
        }

        private string ScrapeJobPortalInfo(string url, HttpClient webClient)
        {

            //temp stuff but this needs to be better refactored
            url = TrimStart(url, "//");
            url = "http://" + url;
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

            catch (Exception e)
            {
                return "";
            }
        }
    }
}
