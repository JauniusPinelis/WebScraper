using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using WebScraper.Core.Dtos;
using WebScraper.Core.Filters;

namespace WebScraper.Core
{
    public class CvOnlineScraper : IScraper
    {
        public IEnumerable<JobHtmlDto> ScrapeJobHtmls(IEnumerable<JobUrlDto> urlDtos)
        {
            var urls = urlDtos.ToList();
            var results = new List<JobHtmlDto>();
            var webClient = new HttpClient();

            /* As testing lets do only 20 page htmls for now - dont wanna 
             * overload the page */

            var limit = 10;
            var delay = 1000;

            for (int i = 0; i <= limit; i++)
            {
                Thread.Sleep(delay);
                var html = ScrapeJobPortalInfo(urls[i].Url, webClient);

                results.Add(new JobHtmlDto()
                {
                    JobUrlId = urls[i].Id,
                    HtmlCode = html
                });


            }

            return results;
        }

        public IEnumerable<JobUrlDto> ScrapePageUrls()
        {
            var baseUrl = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos?page=";
            var webClient = new HttpClient();
            int pageCounter = 0;
            var continueParsing = true;
            var results = new List<JobUrlDto>();

            while (continueParsing && pageCounter < 3)
            {
                //Have some delay in parsing
                Thread.Sleep(1000);

                var validUrl = baseUrl + pageCounter;
                pageCounter += 1;

                var html = webClient.GetStringAsync(validUrl).Result;


                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var resultNodes = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'offer_primary_info')]//a");

                if (resultNodes.Count == 0)
                {
                    continueParsing = false;
                    continue;
                }

                foreach (var resultNode in resultNodes)
                {
                    results.Add(new JobUrlDto(){
                        Url = resultNode.GetAttributeValue("href", string.Empty),
                        CategoryId = 1
                    }
                    );
                }

            }

            return results;
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

            var html = webClient.GetStringAsync(url).Result;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var resultNode = htmlDocument.DocumentNode.SelectSingleNode("//div[contains(@id, 'page-main-content')]");

            var resultNode = htmlDocument.DocumentNode.SelectSingleNode("//div[contains(@id, 'page-main-content')]").InnerHtml;

            return resultNode;
        }
    }
}
