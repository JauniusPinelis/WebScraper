using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;

namespace WebScraper.Core.Shared
{
    public interface IAnalyser
    {
        Salary GetSalary(string salary);
    }
}
