using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Application.Shared;
using WebScraper.Core.Enums;
using WebScraper.Core.Shared;
using WebScraper.Infrastructure.Repositories;

namespace WebScraper.Application.CvLt
{
	public class ScrapePageInfos : BaseCommand
	{
	

		public ScrapePageInfos(IUnitOfWork unitOfWork, IAnalyser analyser, ScrapeClient scrapeClient) :
			base(unitOfWork, analyser, scrapeClient)
		{
			
		}

		public void Do()
		{
			ScrapePageInfos("jobCont", JobPortals.CvLt);
		}
	}
}
