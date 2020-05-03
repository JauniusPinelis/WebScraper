using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebScraper.Application.Shared;
using WebScraper.Core.Entities;
using WebScraper.Core.Enums;
using WebScraper.Core.Shared;
using WebScraper.Infrastructure.Repositories;

namespace WebScraper.Application.CvBankas
{
	public class ScrapePageInfos : BaseCommand
	{
		private IUnitOfWork _unitOfWork;

		private ScrapeClient _scrapeClient;

		public ScrapePageInfos(IUnitOfWork unitOfWork, IAnalyser analyser, ScrapeClient scrapeClient)
			: base(unitOfWork, analyser, scrapeClient)
		{
			_unitOfWork = unitOfWork;
			_scrapeClient = scrapeClient;
		}

		public void Do(JobPortals portalName)
		{
			this.ScrapePageInfos("jobad_content_main", JobPortals.CvBankas);
		}
	}
}
