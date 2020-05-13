using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Shared;
using Core.Entities;
using Core.Enums;
using Core.Shared;
using Infrastructure.Repositories;

namespace Application.CvBankas
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
