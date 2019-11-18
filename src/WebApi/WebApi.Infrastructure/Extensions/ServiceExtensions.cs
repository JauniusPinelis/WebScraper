using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Infrastructure.Db;
using AutoMapper;

namespace WebApi.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options =>
               options.UseSqlServer(connectionString));
        }

       
    }
}
