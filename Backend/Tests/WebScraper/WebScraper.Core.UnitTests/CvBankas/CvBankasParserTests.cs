using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebScraper.Core.CvBankas;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;

namespace WebScraper.Core.UnitTests.CvBankas
{

    [TestFixture]
    public class CvBankasParserTests
    {
        private readonly IParser _parser;

        private List<TagCategory> MockedTagCategories { get; set; } = new List<TagCategory>()
        {
            new TagCategory() {Id = 1, Name = ".NET"},
            new TagCategory() {Id = 2, Name = "C#"},
            new TagCategory() {Id = 3, Name = "PHP"},
            new TagCategory() {Id = 4, Name = "Java"},
            new TagCategory() {Id = 5, Name = "Javascript"},
            new TagCategory() {Id = 6, Name = "Ruby" },
            new TagCategory() {Id = 7, Name = "React"}
        };

        public CvBankasParserTests()
        {
            _parser = new CvBankasParser();
        }

        [Test]
        public void ParseTags_GivenSampleDotNetData_GetsTheRightTags()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvBankasSingleJobPosting.txt");
            var tags = _parser.ParseTags(textData, MockedTagCategories);

            var tagNames = tags.Select(t => t.Name);

            tagNames.Should().Contain(".NET".ToLower());
            tagNames.Should().Contain("React".ToLower());
        }

        [Test]
        public void ParseTags_GivenSampleDotNetData_NoFalsePositive()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvBankasSingleJobPosting.txt");
            var tags = _parser.ParseTags(textData, MockedTagCategories);

            var tagNames = tags.Select(t => t.Name);

            tagNames.Should().NotContain("Python".ToLower());
            tagNames.Should().NotContain("node.js".ToLower());
        }

    }
}
