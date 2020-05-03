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
		private ScrapeClient _htmlScraper;

		public ScrapePageUrls(IUnitOfWork unitOfWork, IAnalyser analyser, IScraper scraper, HttpClient httpClient)
			:base(unitOfWork, analyser)
		{
			_htmlScraper = new ScrapeClient( httpClient, scraper);
		}

		public void Do(JobPortals jobPortal)
		{
			Log.Information($"Scraping urls for: {jobPortal.GetDescription()}");
			UpdateUrls(ExtractPageUrls());
		}

		public List<JobUrl> ExtractPageUrls() => _htmlScraper.ExtractPageUrls();
	}
}
