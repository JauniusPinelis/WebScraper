using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebScraper.Infrastructure.Db;
using WebScraper.Infrastructure.Repositories;

namespace Webscraper.Application.UnitTests
{
    public class TestBase : IDisposable
    {
        protected readonly DataContext _context;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IHttpClientFactory _httpClientFactory;

        

        public TestBase()
        {
            _context = ContextFactory.CreateTestDataContext();
            _unitOfWork = ContextFactory.CreateTestUnitOfWork();
            _httpClientFactory = GenerateTestHttpClientFactory();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(_context);
        }

        

        private IHttpClientFactory GenerateTestHttpClientFactory()
        {
            var content = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\TestData\\CvOnlineTestPageData.txt");

            var mockFactory = new Mock<IHttpClientFactory>();

            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(content),
               })
               .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/"),
            };

            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            return mockFactory.Object;
        }
    }
}
