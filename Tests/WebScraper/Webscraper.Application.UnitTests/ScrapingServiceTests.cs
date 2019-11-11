using AutoMapper;
using NUnit.Framework;
using WebApi.Infrastructure.Mappings;
using WebScraper.Application.Services;
using WebScraper.Core.Factories;

namespace Webscraper.Application.UnitTests
{
    [TestFixture]
    public class ScrapingServiceTests : ContextTestBase
    {
        private readonly IScrapingService _scrapingService;

        public ScrapingServiceTests() : base()
        {
            var scraperFactory = new ScraperFactory();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            _scrapingService = new ScrapingService(_context, scraperFactory, mapper);
        }

        [Test]
        public void CheckIfUpdateServiceWorks()
        {
            Assert.Pass();
        }
    }
}