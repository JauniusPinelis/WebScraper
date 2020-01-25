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
        public bool HasNumber(string input)
        {
            return input.Where(i => Char.IsDigit(i)).Any();
        }


        
        public Salary GetSalary(string salary)
        {
            if (HasNumber(salary))
                return null; //No salary information in the advertisements

            salary = salary.ToLower();

            MatchCollection matches = Regex.Matches(salary, @"\d+");

            var type = salary.Contains("netto") || salary.Contains("rankas") ? "Netto" : "Brutto";
            


            var salaryObject = new Salary()
            {


            };

            throw new NotImplementedException();
        }
    }
}
