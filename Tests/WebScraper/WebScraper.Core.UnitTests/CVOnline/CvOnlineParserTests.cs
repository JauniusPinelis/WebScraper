using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private List<TagCategory> MockedTagCategories { get; set; } = new List<TagCategory>()
        {
            new TagCategory() {Id = 1, Name = ".NET"},
            new TagCategory() {Id = 2, Name = "C#"},
            new TagCategory() {Id = 3, Name = "PHP"},
            new TagCategory() {Id = 4, Name = "Java"},
            new TagCategory() {Id = 5, Name = "Javascript"}
        };

        public CvOnlineParserTests()
        {
            _parser = new CvOnlineParser();
        }

        [Test]
        public void ParseTags_givenTestData_ReturnsCorrectTags()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvOnlineHtmlData.txt");
            var tags = _parser.ParseTags(textData, MockedTagCategories);

            var tagNames = tags.Select(t => t.Name);



            tagNames.Should().Contain(".NET".ToLower());
            tagNames.Should().Contain("c#".ToLower());
        }

        [Test]
        public void ParseTags_givenTestData_DoesNotContainPHP()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvOnlineHtmlData.txt");
            var tags = _parser.ParseTags(textData, MockedTagCategories);
            tags.Should().NotContain(("PHP".ToLower()));
        }


    }
}
