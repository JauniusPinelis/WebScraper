using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WebScraper.Core.Entities;

namespace WebScraper.Core.Shared
{
    public class BaseAnalyser : IAnalyser
    {
        public bool HasNumber(string input) => input.Where(i => Char.IsDigit(i)).Any();

        public List<string> RemoveZeros(List<string> data) => data.Where(d => !d.All(v => v.Equals('0'))).ToList();

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
            var period = salary.Contains("metinis") ? "Yearly" : "Monthly";


            var salaryData = new Salary()
            {
                From = from,
                To = to,
                Exact = exact,
                Type = type,
                Period = period
            };

            return salaryData;
        }
    }
}
