using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using WebScraper.Core.Entities;
using WebScraper.Infrastructure.Db;
using WebScraper.Infrastructure.Services;

namespace WebScraper.Infrastructure.IntegrationTests
{

    [TestFixture]
    public class DataDbContextTests : IDisposable
    {
        private readonly DataContext _sut;
        private readonly DateTime _dateTime;
        private readonly Mock<IDateTime> _dateTimeMock;

        public DataDbContextTests()
        {
            _dateTime = new DateTime(2001, 1, 14);
            _dateTimeMock = new Mock<IDateTime>();
            _dateTimeMock.Setup(m => m.Now).Returns(_dateTime);

            var options = new DbContextOptionsBuilder<DataContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString())
               .Options;

            _sut = new DataContext(options, _dateTimeMock.Object);

        }

        [Test]
        public void SaveChanges_GivenNewUrl_ShouldSetCreated()
        {
            var url = new JobUrl()
            {
                Url = "Test"
            };

            _sut.JobUrls.Add(url);
            _sut.SaveChanges();

            url.Created.Should().Be(_dateTime);
        }

        public void Dispose()
        {
            _sut?.Dispose();
        }
    }
}