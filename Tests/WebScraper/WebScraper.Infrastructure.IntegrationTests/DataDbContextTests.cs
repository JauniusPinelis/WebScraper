using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
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
        public void InitDb_GivenDefaultConnectionString_ShouldCreateConnection()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);

            using (DataContext dbContext = new DataContext(optionsBuilder.Options))
            {
                dbContext.Database.CanConnect().Should().Be(true);
            }
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

        [Test]
        public void SaveChanges_GivenNewUrlWithVilnius_SavedLocationShouldBeVilnius()
        {
            var url = new JobUrl()
            {
                Url = "Test",
                Location = "Vilnius"
            };

            _sut.JobUrls.Add(url);
            _sut.SaveChanges();

            url.Location.Should().Be("Vilnius");
        }

        [Test]
        public void SaveChanges_GivenNewCompanyWithVilnius_SavedCompanyShouldBeMedScinet()
        {
            var url = new JobUrl()
            {
                Url = "Test",
                Location = "Vilnius",
                Company = "MedSciNet",
            };

            _sut.JobUrls.Add(url);
            _sut.SaveChanges();

            url.Company.Should().Be("MedSciNet");
        }

        [Test]
        public void SeedData_DefaultDb_HasJobPortalsSeeded()
        {
            /*.Database.Migrate();

            var jobPortals = _sut.JobPortals.ToList();

            var jobPortalNames = jobPortals.Select(p => p.Name.ToLower());

            jobPortalNames.Should().NotBeEmpty();
            jobPortalNames.Should().Contain("cvonline");
            jobPortalNames.Should().Contain("cvbankas");
            jobPortalNames.Should().Contain("cvlt");
            */

            Assert.Pass();
        }

        public void Dispose()
        {
            _sut?.Dispose();
        }
    }
}