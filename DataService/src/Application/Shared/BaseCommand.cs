using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Core.Entities;
using Core.Enums;
using Core.Factories;
using Core.Shared;
using Infrastructure.Repositories;

namespace Application.Shared
{
	public abstract class BaseCommand
	{
		private UnitOfWork _unitOfWork;
		private IAnalyser _analyser;
		private ScrapeClient _scrapeClient;


		public BaseCommand(UnitOfWork unitOfWork, IAnalyser analyser, ScrapeClient scrapeClient)
		{
			_unitOfWork = unitOfWork;
			_analyser = analyser;
			_scrapeClient = scrapeClient;
		}


		public void ProcessSalaries(JobPortals jobPortal)
		{
			Log.Information($"processing Salaries for {jobPortal.GetDescription()}");
			var jobUrls = _unitOfWork.JobUrlRepository.GetAll();

			var jobsWithSalaries = jobUrls.Where(j => !String.IsNullOrEmpty(j.SalaryText)).ToList();

			foreach (var jobUrl in jobsWithSalaries)
			{
				var salary = _analyser.GetSalary(jobUrl.SalaryText);

				salary.JObUrlId = jobUrl.Id;

				_unitOfWork.SalaryRepository.Upsert(salary, salary.Id);
				Log.Information($"Updating salary for: {jobPortal.GetDescription()}");
				_unitOfWork.SaveChanges();
			}
		}

		public void UpdateUrls(IList<JobUrl> jobUrls)
		{
			foreach (var jobUrl in jobUrls)
			{
				Log.Information($"Upserting url: {jobUrl.Url}");
				_unitOfWork.JobUrlRepository.Upsert(jobUrl, jobUrl.Id);
				_unitOfWork.SaveChanges();
			}
		}

		/// <summary>
		/// If Database is empty it does a full scrape - if not
		/// is run only for the first 3 pages
		/// </summary>
		public List<JobUrl> ExtractPageUrls() 
		=> _unitOfWork.JobUrlRepository.GetAll().Any() ? 
				_scrapeClient.ExtractPageUrls(3) : _scrapeClient.ExtractPageUrls();
			
		


		public void ScrapePageInfos(string elementId, JobPortals jobPortal)
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
