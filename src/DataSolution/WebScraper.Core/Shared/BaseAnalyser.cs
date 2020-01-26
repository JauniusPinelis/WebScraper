using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WebScraper.Core.Shared
{
    public class BaseAnalyser
    {
        public bool HasNumber(string input) => input.Where(i => Char.IsDigit(i)).Any();

        public List<string> RemoveZeros(List<string> data) => data.Where(d => !d.All(v => v.Equals('0'))).ToList();
    }
}
