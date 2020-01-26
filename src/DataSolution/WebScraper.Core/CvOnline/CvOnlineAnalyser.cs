using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WebScraper.Core.Models;
using WebScraper.Core.Shared;

namespace WebScraper.Core.CvOnline
{
    public class CvOnlineAnalyser : BaseAnalyser
    {
       



        public Salary GetSalary(string salary)
        {
            if (!HasNumber(salary))
                return null; //No salary information in the advertisements

            decimal? from = null;
            decimal? to = null;
            decimal? exact = null;

            salary = salary.ToLower();

            List<string> matches = Regex.Matches(salary, @"\d+").Select(m => m.Value).ToList();

            matches = RemoveZeros(matches);

            if (matches.Count >= 2)
            {
                from = Decimal.Parse(matches[0]);
                to = Decimal.Parse(matches[1]);
            }
            else if (matches.Count == 1 && (salary.Contains("nuo ") || salary.Contains("from ")))
            {
                from = Decimal.Parse(matches[0]);
            }
            else if (matches.Count == 1)
            {
                exact = Decimal.Parse(matches[0]);
            }

            var type = salary.Contains("netto") || salary.Contains("rankas") ? "Netto" : "Brutto";


            var salaryData = new Salary()
            {
                From = from,
                To = to,
                Exact = exact,
                Type = type
            };

            return salaryData;
        }
    }
}
