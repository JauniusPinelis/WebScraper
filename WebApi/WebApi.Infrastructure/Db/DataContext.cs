using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Infrastructure.Entities;

namespace WebApi.Infrastructure.Db
{
    public class DataContext : DbContext
    {
        public DbSet<JobHtml> JobHtmls { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}
