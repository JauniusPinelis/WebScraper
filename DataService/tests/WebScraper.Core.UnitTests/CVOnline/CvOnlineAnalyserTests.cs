using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebScraper.Core.CvOnline;
using WebScraper.Core.Shared;

namespace WebScraper.Core.UnitTests.CVOnline
{
    [TestFixture]
    public class CvOnlineAnalyserTests
    {
        private BaseAnalyser _analyser;
        
        public CvOnlineAnalyserTests()
        {
            _analyser = new BaseAnalyser();
        }
        
        [Test]
        public void GetSalary_GivenBasicTestData_GetsFullSalaryRange()
        {
            string textData = "<span class=salary - blue>Mėnesinis atlygis (bruto): Nuo 2500.00 iki 5800.00 EUR</span></li>";

            var salary = _analyser.GetSalary(textData);

            salary.From.Should().Be(2500);
            salary.To.Should().Be(5800);
            salary.Exact.Should().BeNull();
            salary.Currency.Should().Be("EUR");
            salary.Type.Should().Be("Brutto");

        }

        [Test]
        public void GetSalary_GivenEmptyString_ShouldREturnEmptyProject()
        {
            string textData = "";

            var salary = _analyser.GetSalary(textData);

            salary.Should().BeNull();
        }

        [Test]
        public void GetSalary_GivenMinimumRange_ShouldReturnOnlyMinimumFrom()
        {
            string textData = "Atlyginimas nuo 2200 euru";

            var salary = _analyser.GetSalary(textData);

            salary.Exact.Should().BeNull();
            salary.To.Should().BeNull();
            salary.From.Should().Be(2200);
        }

        [Test]
        public void GetSalary_GivenYearRange_ShouldReturnAYearlySalaryObject()
        {
            string textData = "Metinis atlyginimas:Nuo 22800.00 iki 30000.00 EUR";

            var salary = _analyser.GetSalary(textData);

            salary.Period.Should().Be("Yearly");
            salary.Exact.Should().BeNull();
            salary.To.Should().Be(30000);
            salary.From.Should().Be(22800);
        }
    }
}
