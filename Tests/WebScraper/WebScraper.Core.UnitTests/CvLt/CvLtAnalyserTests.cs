using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.CvLt;
using WebScraper.Core.CvOnline;
using WebScraper.Core.Shared;

namespace WebScraper.Core.UnitTests.CvLt
{
    [TestFixture]
    public class CvLtAnalyserTests
    {
        private IAnalyser _analyser;

        public CvLtAnalyserTests()
        {
            _analyser = new CvLtAnalyser();
        }

        [Test]
        public void GetSalary_GivenDotAsNumeratorToThousands_GetsCorrectSalary()
        {
           
            string textData = "Nuo 2.128 € iki 5.000 €";

            var salary = _analyser.GetSalary(textData);

            salary.From.Should().Be(2128);
            salary.To.Should().Be(5000); 
        }
    }
}
