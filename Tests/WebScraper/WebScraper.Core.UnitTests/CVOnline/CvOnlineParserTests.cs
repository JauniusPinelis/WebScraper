using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentAssertions;
using WebScraper.Core.CvOnline;
using WebScraper.Core.Entities;

namespace WebScraper.Core.UnitTests
{
    [TestFixture]
    public class CvOnlineParserTests
    {
        private readonly CvOnlineParser _parser;

        private List<Tag> MockedTags { get; set; } = new List<Tag>()
        {
            new Tag() {Id = 1, Name = ".NET"},
            new Tag() {Id = 2, Name = "C#"},
            new Tag() {Id = 3, Name = "PHP"},
            new Tag() {Id = 4, Name = "Java"},
            new Tag() {Id = 5, Name = "Javascript"}
        };

        public CvOnlineParserTests()
        {
            _parser = new CvOnlineParser();
        }

        [Test]
        public void ParseTags_givenTestData_ReturnsCorrectTags()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvOnlineHtmlData.txt");
            var tags = _parser.ParseTags(textData, MockedTags);
            tags.Should().Contain(".NET".ToLower());
            tags.Should().Contain("c#".ToLower());
        }

       
    }
}
