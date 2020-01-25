using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WebScraper.Core.Models;

namespace WebScraper.Core.CvOnline
{
    public class CvOnlineAnalyser
    {
        public bool HasNumber(string input) => input.Where(i => Char.IsDigit(i)).Any();


        public List<Match> RemoveZeros(List<Match> data) => data.Where(d => !d.Value.All(v => v.Equals('0'))).ToList();



        public Salary GetSalary(string salary)
        {
            if (!HasNumber(salary))
                return null; //No salary information in the advertisements

            decimal? from = null;
            decimal? to = null;
            decimal? exact = null;

            salary = salary.ToLower();

            List<Match> matches = Regex.Matches(salary, @"\d+").ToList();

            matches = RemoveZeros(matches);

            if (matches.Count >= 2)
            {
                from = Decimal.Parse(matches[0].Value);
                to = Decimal.Parse(matches[1].Value);
            }

            if (matches.Count == 1)
            {
                exact = Decimal.Parse(matches[0].Value);
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
