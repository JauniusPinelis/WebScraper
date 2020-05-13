using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Shared
{
    public interface IAnalyser
    {
        Salary GetSalary(string salary);
    }
}
