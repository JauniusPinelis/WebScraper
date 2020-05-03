using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebScraper.Application.Shared;
using WebScraper.Core.Enums;
using WebScraper.Core.Factories;
using WebScraper.Core.Shared;
using WebScraper.Infrastructure.Repositories;

namespace WebScraper.Application.CvBankas
{
	public class ProcessSalaries : BaseCommand
	{

		public ProcessSalaries(IUnitOfWork unitOfWork, IAnalyser analyser, ScrapeClient scrapeClient) 
			: base(unitOfWork, analyser, scrapeClient)
		{
		
		}

		public void Do(JobPortals jobPortal)
		{
			this.ProcessSalaries(jobPortal);	
		}
	}
}
