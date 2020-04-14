using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Enums;

namespace WebScraper.Core.UnitTests.Enums
{
	[TestFixture]
	public class JobPortalsTests
	{
		
		[Test]
		public void GetDescription_BasicSetup_GetsCorrectDescriptions()
		{
			JobPortals.CvLt.GetDescription().Should().Be("CvLt");
			JobPortals.CvOnline.GetDescription().Should().Be("CvOnline");
			JobPortals.CvBankas.GetDescription().Should().Be("CvBankas");
		}
	}
}
