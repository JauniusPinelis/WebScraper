using HtmlAgilityPack;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using WebScraper.Core.Entities;

namespace WebScraper.Core.Shared
{
    public abstract class BaseScraper
    {
        public List<JobUrl> jobUrls { get; set; }

        private const int _sleepTime = 1000;

        public BaseScraper()
        {
            jobUrls = new List<JobUrl>();
        }

        public IEnumerable<JobUrl> ExtractPageUrls(string pageHtml, string selectQuery)
        {

            if (pageHtml == "")
                return jobUrls;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(pageHtml);

            var resultNodes = htmlDocument.DocumentNode.SelectNodes(selectQuery);

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

        public string ScrapeJobHtml(string html, string contentId)
        {
            try
            {
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

        public JobUrl ScrapeJobUrlInfo(string html, JobUrlScraperInfoModel scrapeInfo, int websiteType)
        {
            var resultHtml = new HtmlDocument();
            resultHtml.LoadHtml(html);

            var url = resultHtml.DocumentNode.SelectSingleNode(scrapeInfo.Url);
            var title = resultHtml.DocumentNode.SelectSingleNode(scrapeInfo.Title);
            var salary = resultHtml.DocumentNode.SelectSingleNode(scrapeInfo.Salary);
            var location = resultHtml.DocumentNode.SelectSingleNode(scrapeInfo.Location);
            var company = resultHtml.DocumentNode.SelectSingleNode(scrapeInfo.Company);
            var logo = resultHtml.DocumentNode.SelectSingleNode(scrapeInfo.Logo);

            return new JobUrl()
            {
                Url = url?.GetAttributeValue(scrapeInfo.UrlAttribute, string.Empty),
                //Url = url?.GetAttributeValue("content", string.Empty),
                SalaryText = salary?.InnerText ?? "",
                Title = scrapeInfo.TitleAttribute != null ? title?.GetAttributeValue(scrapeInfo.TitleAttribute, string.Empty):  title?.InnerText,
                //Location = location?.GetAttributeValue("content", string.Empty),
                Location = scrapeInfo.LocationAttribute != null ? location?.GetAttributeValue("content", string.Empty) :  location?.InnerHtml,
                Company = company?.InnerText,
                JobPortalId = websiteType,
                Logo = scrapeInfo.LogoAttribute != null ? logo?.GetAttributeValue(scrapeInfo.LogoAttribute, string.Empty) : logo?.InnerText
            };
        }

        public abstract JobUrl ScrapeJobUrlInfo(string html);

        public abstract IEnumerable<JobUrl> ExtractPageUrls(string pageHtml);
    }
}
