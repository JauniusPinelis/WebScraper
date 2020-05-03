using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Application.Shared;
using WebScraper.Core.Entities;
using WebScraper.Core.Enums;
using WebScraper.Core.Shared;
using WebScraper.Infrastructure.Repositories;

namespace WebScraper.Application.CvLt
{
	public class ScrapePageUrls : BaseCommand
	{
		public ScrapePageUrls(IUnitOfWork unitOfWork, IAnalyser analyser, ScrapeClient scrapeClient)
			: base(unitOfWork, analyser, scrapeClient)
		{
			
		}

		public void Do(JobPortals jobPortal)
		{
			Log.Information($"Scraping urls for: {jobPortal.GetDescription()}");
			UpdateUrls(ExtractPageUrls());
		}

	}
}
