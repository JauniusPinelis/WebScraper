using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Factories;
using Infrastructure.Db;
using Infrastructure.Repositories;
using Infrastructure.Services;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration,
             string connectionString)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddSingleton<IDataContext>(provider => provider.GetService<DataContext>());
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            return services;
        }

      
    }
}
