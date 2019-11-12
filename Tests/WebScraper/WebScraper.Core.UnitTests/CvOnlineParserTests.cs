using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;
using WebScraper.Core.Parsers;

namespace WebScraper.Core.UnitTests
{
    [TestFixture]
    public class CvOnlineParserTests
    {
        private readonly CvOnlineParser _parser;

        public CvOnlineParserTests()
        {
            _parser = new CvOnlineParser();
        }

       
    }
}
