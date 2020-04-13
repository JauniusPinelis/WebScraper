using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using WebScraper.Core.Shared;

namespace WebScraper.Core.UnitTests.Base
{
    [TestFixture]
    public class BaseAnalyserTests
    {
        private BaseAnalyser _analyser;

        public BaseAnalyserTests()
        {
            _analyser = new BaseAnalyser();

           
        }

        [Test]
        public void HasNumber_GivenStringWithNumbers_ReturnsTrue()
        {
            _analyser.HasNumber("Salary is starting from 3000 eur").Should().BeTrue();
        }

        [Test]
        public void HasNumber_GivenStringWithNoNumbers_ReturnsFalse()
        {
            _analyser.HasNumber("There is no salary").Should().BeFalse();
        }

        [Test]
        public void RemoveZeros_GivenListWithNoZeros_ListRemainsTheSame()
        {
            var strings = new List<string>()
            {
                "3300",
                "2200"
            };

            _analyser.RemoveZeros(strings).Count.Should().Be(2);
        }

        [Test]
        public void RemoveZeros_GivenListWithZeros_ShouldReturnAListWithoutZeros()
        {
            var strings = new List<string>()
            {
                "3300",
                "00",
                "2200"
            };

            _analyser.RemoveZeros(strings).Count.Should().Be(2);
        }


    }
}
