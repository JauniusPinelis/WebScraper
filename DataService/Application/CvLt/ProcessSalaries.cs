using WebScraper.Application.Shared;
using WebScraper.Core.Enums;
using WebScraper.Core.Shared;
using WebScraper.Infrastructure.Repositories;

namespace WebScraper.Application.CvLt
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
