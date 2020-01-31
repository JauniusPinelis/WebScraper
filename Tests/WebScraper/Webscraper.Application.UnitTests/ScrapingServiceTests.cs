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
using WebScraper.Infrastructure.Repositories;

namespace Webscraper.Application.UnitTests
{
    [TestFixture]
    public class ScrapingServiceTests : ContextTestBase
    {
        private readonly CvOnlineScrapeService _scrapingService;

        public ScrapingServiceTests() : base()
        {
            var scraperFactory = new ScraperFactory();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            

            _scrapingService = new CvOnlineScrapeService(_httpClientFactory, scraperFactory, _unitOfWork);
        }

        [Test]
        public void BasicTest()
        {
            var result = await subjectUnderTest
   .GetSomethingRemoteAsync('api/test/whatever');

            // ASSERT
            result.Should().NotBeNull(); // this is fluent assertions here...
            result.Id.Should().Be(1);

            // also check the 'http' call was like we expected it
            var expectedUri = new Uri("http://test.com/api/test/whatever");

            handlerMock.Protected().Verify(
               "SendAsync",
               Times.Exactly(1), // we expected a single external request
               ItExpr.Is<HttpRequestMessage>(req =>
                  req.Method == HttpMethod.Get  // we expected a GET request
                  && req.RequestUri == expectedUri // to this uri
               ),
               ItExpr.IsAny<CancellationToken>()
            );
        }
       
    }
}