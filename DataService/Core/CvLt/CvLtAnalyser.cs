using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;

namespace WebScraper.Core.CvLt
{
    public class CvLtAnalyser : BaseAnalyser
    {
        public override Salary GetSalary(string salary)
        {
            //Fix for Nuo 2.128 € iki 5.000 €
            salary = salary.Replace(".", "");

            return base.GetSalary(salary);
        }
    }
}
