using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using WebScraper.Application.Common.Mappings;
using WebScraper.Application.Services;
using WebScraper.Application.Shared;
using WebScraper.Core.Enums;
using WebScraper.Core.Factories;

namespace WebScraper.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddScoped<IScrapeService, ApplicationRunner>();
            services.AddScoped<IScraperFactory, ScraperFactory>();

			services.AddHttpClient(JobPortals.CvLt.ToString(), client =>
			{
				client.BaseAddress = new Uri("https://www.cv.lt/employee/announcementsAll.do?regular=true&department=1040&page=");
			});
			services.AddHttpClient(JobPortals.CvBankas.ToString(), client =>
			{
				client.BaseAddress = new Uri("https://www.cvbankas.lt/?padalinys%5B0%5D=76&page=");
			});
			services.AddHttpClient(JobPortals.CvOnline.ToString(), client =>
			{
				client.BaseAddress = new Uri("https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos?page=");
			});


			return services;
        }
        public static void ConfigureMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
