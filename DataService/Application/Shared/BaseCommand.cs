using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using WebScraper.Core.Entities;
using WebScraper.Core.Enums;
using WebScraper.Core.Factories;
using WebScraper.Core.Shared;
using WebScraper.Infrastructure.Repositories;

namespace WebScraper.Application.Shared
{
	public abstract class BaseCommand
	{
		private IUnitOfWork _unitOfWork;
		private IAnalyser _analyser;


		public BaseCommand(IUnitOfWork unitOfWork, IAnalyser analyser)
		{
			_unitOfWork = unitOfWork;
			_analyser = analyser;
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

	}
}
