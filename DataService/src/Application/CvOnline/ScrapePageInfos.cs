using System;
using System.Collections.Generic;
using System.Text;
using Application.Shared;
using Core.Enums;
using Core.Shared;
using Infrastructure.Repositories;

namespace Application.CvOnline
{
	public class ScrapePageInfos : BaseCommand
	{
		public ScrapePageInfos(IUnitOfWork unitOfWork, IAnalyser analyser, ScrapeClient scrapeClient) :
			base(unitOfWork, analyser, scrapeClient)
		{
			
		}

		public void Do()
		{
			ScrapePageInfos("page-main-content", JobPortals.CvOnline);
		}
	}
}
