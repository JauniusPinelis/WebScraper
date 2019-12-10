using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moq;
using WebScraper.Application.Common.Mappings;
using WebScraper.Application.Services;
using WebScraper.Core.Entities;
using WebScraper.Core.Factories;
using System.Net.Http;


namespace Webscraper.Application.UnitTests
{
    [TestFixture]
    public class ScrapingServiceTests : ContextTestBase
    {
        private readonly ApplicationRunner _scrapingService;

        public ScrapingServiceTests() : base()
        {
            var scraperFactory = new ScraperFactory();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            var mockFactory = new Mock<IHttpClientFactory>();

            _scrapingService = new ApplicationRunner(_context, scraperFactory, mapper, mockFactory.Object);
        }

        [Test]
        public void UpdateUrls_HavingDublicates_ShouldDetectDublicates()
        {
            //var entity = new JobUrl()
            //{
            //    Url = "Delfi.lt"
            //};

            //IList<JobUrl> collectedEntities = new List<JobUrl>();
            //collectedEntities.Add(entity);
            //collectedEntities.Add(entity);

            //_scrapingService.UpdateUrls(collectedEntities);

            //_context.JobUrls.Count().Should().Be(1);
        }

        [Test]
        public void UpdateUrls_HavingMultipleEntities_MultipleEntitiesShouldBeSaved()
        {
            //var entity1 = new JobUrl()
            //{
            //    Url = "Delfi.lt"
            //};

            //var entity2 = new JobUrl()
            //{
            //    Url = "google.lt"
            //};

            //IList<JobUrl> collectedEntities = new List<JobUrl>();
            //collectedEntities.Add(entity1);
            //collectedEntities.Add(entity2);

            //_scrapingService.UpdateUrls(collectedEntities);

            //_context.JobUrls.Count().Should().Be(2);
        }

       
    }
}