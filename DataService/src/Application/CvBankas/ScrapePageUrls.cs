using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Application.Shared;
using Core.Entities;
using Core.Enums;
using Core.Factories;
using Core.Shared;
using Infrastructure.Repositories;

namespace Application.CvBankas
{
	public class ScrapePageUrls : BaseCommand
	{

		public ScrapePageUrls(UnitOfWork unitOfWork, IAnalyser analyser, ScrapeClient scrapeClient)
			:base(unitOfWork, analyser, scrapeClient)
		{

		}

		public void Do(JobPortals jobPortal)
		{
			Log.Information($"Scraping urls for: {jobPortal.GetDescription()}");
			UpdateUrls(ExtractPageUrls());
		}
	}
}
