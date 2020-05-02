using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using HtmlAgilityPack;
using Serilog;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;
using Microsoft.Extensions.DependencyInjection;
using WebScraper.Core.Enums;
using WebScraper.Core.Factories;
using WebScraper.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using WebScraper.Infrastructure.Repositories;

namespace WebScraper.Application.Shared
{
    public abstract class BaseScrapeService
    {
        protected IHttpClientFactory _httpClientFactory;
        protected IScraperFactory _scraperFactory;
        protected IScraper _scraper;
        protected IAnalyser _analyser;
        protected IUnitOfWork _unitOfWork;

        protected const int _sleepTime = 300;
        protected const int _scrapeLimit = 200;

        protected ScrapeClient _htmlScraper;

		private JobPortals _portalName;

        public BaseScrapeService(JobPortals portalName, IHttpClientFactory httpClientFactory, IScraperFactory scraperFactory,  IUnitOfWork unitOfWork)
        {
            _scraperFactory = scraperFactory;
            _httpClientFactory = httpClientFactory;
            _unitOfWork = unitOfWork;

            _scraper = _scraperFactory.BuildScraper(portalName);
            _analyser = _scraperFactory.BuildAnalyser(portalName);

			var httpClient = _httpClientFactory.CreateClient(portalName.GetDescription());

			_htmlScraper = new ScrapeClient(httpClient, _scraper);
        }

        public List<JobUrl> ExtractPageUrls() => _htmlScraper.ExtractPageUrls();

        public string ScrapeJobHtml(string url, string contentId) => _htmlScraper.ScrapeJobHtml(url, contentId);

        public void ProcessSalaries()
        {
			Log.Information($"processing Salaries for {_portalName.GetDescription()}");

			var jobsWithSalaries = _unitOfWork.JobUrlRepository.GetAll()
                .Where(j => !String.IsNullOrEmpty(j.SalaryText)).ToList();

            foreach (var jobUrl in jobsWithSalaries)
            {
                var salary = _analyser.GetSalary(jobUrl.SalaryText);

                salary.JObUrlId = jobUrl.Id;

                _unitOfWork.SalaryRepository.Upsert(salary, salary.Id);

				Log.Information($"Updating salary for: {_portalName.GetDescription()}");

				_unitOfWork.SaveChanges();
            }
        }

        public void ScrapePageInfos(string elementId, JobPortals jobPortals)
        {
			Log.Information($"Scraping page infos for {_portalName.GetDescription()}");

			var jobPortalUrls = _unitOfWork.JobUrlRepository.GetAll()
                .Where(j => j.JobPortalId == (int)jobPortals).ToList();

            foreach (var url in jobPortalUrls)
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

        public void UpdateUrls(IList<JobUrl> jobUrls)
        {
            foreach (var jobUrl in jobUrls)
            {
				Log.Information($"Upserting url: {jobUrl.Url}");
				_unitOfWork.JobUrlRepository.Upsert(jobUrl, jobUrl.Id);
                _unitOfWork.SaveChanges();
            }
        }

		public virtual void ScrapePageUrls()
		{
			Log.Information($"Scraping urls for: {_portalName.GetDescription()}");
			var urls = ExtractPageUrls();
			UpdateUrls(urls);
		}
	}
}
