using Application.CvBankas;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IntegrationTests.CvBankas
{

	using static Testing;

	public class ScrapePageUrlsTests : TestBase
	{
		[Test]
		public void TestConfig()
		{
			var context = GetDbContext();


			var query = new ScrapePageUrls(context);
		}
	}
}
