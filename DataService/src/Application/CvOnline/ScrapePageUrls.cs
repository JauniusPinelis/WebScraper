using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Shared;
using Core.Enums;
using Core.Shared;
using Infrastructure.Repositories;

namespace Application.CvOnline
{
	public class ScrapePageUrls : BaseCommand
	{
		public ScrapePageUrls(UnitOfWork unitOfWork, IAnalyser analyser, ScrapeClient scrapeClient)
			: base(unitOfWork, analyser, scrapeClient)
		{

		}

		public void Do(JobPortals jobPortal, IUrlFilter filter)
		{
			Log.Information($"Scraping urls for: {jobPortal.GetDescription()}");
			var urls = ExtractPageUrls();

			filter.Apply(ref urls);

			UpdateUrls(urls);
		}
	}
}
