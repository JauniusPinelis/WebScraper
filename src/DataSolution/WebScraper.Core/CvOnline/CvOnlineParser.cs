using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;

namespace WebScraper.Core.CvOnline
{
    public class CvOnlineParser : IParser
    {

        private string ParseTitle(string html)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var resultNodes = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'application-title')]//h1");
            var title = resultNodes[0].InnerText;
            return title;
        }

        private string ParseSalary(string html)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var resultNodes = htmlDocument.DocumentNode.SelectNodes("//li[contains(text(), 'EUR')]");
            var title = resultNodes[0].InnerText;

            //a[contains(text(), 'About us') or contains(text(), 'about us')]
            return String.Empty;
        }

        public List<string> ParseTags(string html)
        {
            var tags = new List<string>();
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            //TODO: Add functionality

            return tags;
        }

        public JobInfo ParseInfo(JobInfo jobHtml)
        {
            jobHtml.Title = ParseTitle(jobHtml.HtmlCode);
            jobHtml.Salary = ParseSalary(jobHtml.Salary);
            return jobHtml;
        }
    }
}
