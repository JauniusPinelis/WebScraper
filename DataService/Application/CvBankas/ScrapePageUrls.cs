using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebScraper.Application.Shared;
using WebScraper.Core.Entities;
using WebScraper.Core.Enums;
using WebScraper.Core.Factories;
using WebScraper.Core.Shared;
using WebScraper.Infrastructure.Repositories;

namespace WebScraper.Application.CvBankas
{
	public class ScrapePageUrls : BaseCommand
	{
		private ScrapeClient _scrapeClient;

		public ScrapePageUrls(IUnitOfWork unitOfWork, IAnalyser analyser, ScrapeClient scrapeClient)
			:base(unitOfWork, analyser, scrapeClient)
		{
			_scrapeClient = scrapeClient;
		}

		public void Do(JobPortals jobPortal)
		{
			Log.Information($"Scraping urls for: {jobPortal.GetDescription()}");
			UpdateUrls(ExtractPageUrls());
		}
	}
}
