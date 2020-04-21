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

        [Test]
        public void GetSalary_GivenRange_ReturnsMinimumAndMaximumSalary()
        {
            var textData = "2500-5000";

            var salary = _analyser.GetSalary(textData);

            salary.Exact.Should().BeNull();
            salary.From.Should().Be(2500);
            salary.To.Should().Be(5000);
            salary.Period.Should().Be("Monthly");
            salary.Type.Should().Be("Brutto");
        }
    }
}
