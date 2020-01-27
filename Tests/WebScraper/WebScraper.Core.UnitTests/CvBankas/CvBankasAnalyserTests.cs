using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.CvBankas;

namespace WebScraper.Core.UnitTests.CvBankas
{
    [TestFixture]
    public class CvBankasAnalyserTests
    {
        private CvBankasAnalyser _analyser;

        public CvBankasAnalyserTests()
        {
            _analyser = new CvBankasAnalyser();
        }

        [Test]
        public void GetSalary_GivenFromKeyword_GivesMinimumSalary()
        {
            var textData = "Nuo 1200";

            var salary = _analyser.GetSalary(textData);

            salary.Exact.Should().BeNull();
            salary.To.Should().BeNull();
            salary.From.Should().Be(1200);
        }
    }
}
