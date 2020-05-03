using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebScraper.Core.Entities;
using WebScraper.Core.Enums;
using WebScraper.Infrastructure.Repositories;

namespace WebScraper.Application.CvBankas
{
	public class ScrapePageInfos
	{
		private IUnitOfWork _unitOfWork;

		private ScrapeClient _scrapeClient;

		public ScrapePageInfos(IUnitOfWork unitOfWork, ScrapeClient scrapeClient)
		{
			_unitOfWork = unitOfWork;
			_scrapeClient = scrapeClient;
		}

		public void Do(JobPortals portalName)
		{
			Scrape("jobad_content_main", JobPortals.CvBankas);
		}

		public void Scrape(string elementId, JobPortals jobPortal)
		{
			Log.Information($"Scraping page infos for {jobPortal.GetDescription()}");

			var jobPortalsUrls = _unitOfWork.JobUrlRepository.GetAll()
				.Where(j => j.JobPortalId == (int)jobPortal).ToList();

			foreach (var url in jobPortalsUrls)
			{
				var html = ScrapeJobHtml(url.Url, elementId);

				Log.Information($"Updating HtmlCode for Job Url {url.Id}");

				var jobInfo = new JobInfo()
				{
					HtmlCode = html,
					JobUrlId = url.Id
				};

				_unitOfWork.JobInfoRepository.Upsert(jobInfo, jobInfo.Id);
				_unitOfWork.SaveChanges();
			}
		}

		public string ScrapeJobHtml(string url, string contentId) => _scrapeClient.ScrapeJobHtml(url, contentId);
	}
}
