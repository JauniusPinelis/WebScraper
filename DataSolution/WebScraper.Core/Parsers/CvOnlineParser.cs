using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;

namespace WebScraper.Core.Parsers
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
            return String.Empty;
        }
        public JobInfo ParseInfo(JobInfo jobHtml)
        {
            jobHtml.Title = ParseTitle(jobHtml.HtmlCode);
            jobHtml.Salary = ParseSalary(jobHtml.Salary);
            return jobHtml;
        }
    }
}
