using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            var type = salary.Contains("netto") || salary.Contains("rankas") ? "Netto" : "Brutto";
            var 


            var salaryObject = new Salary()
            {


            };

            throw new NotImplementedException();
        }
    }
}
