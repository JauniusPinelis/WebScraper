using Microsoft;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebScraper.Core.Entities;

namespace WebScraper.Infrastructure.Configurations
{
    public class SalaryConfiguration : IEntityTypeConfiguration<Salary>
    {
        public void Configure([ValidatedNotNullAttribute] EntityTypeBuilder<Salary> builder)
        {
            builder.ToTable("tblData_salary");

            builder.Property(e => e.Id)
               .HasColumnName("Id")
               .HasMaxLength(5)
               .ValueGeneratedOnAdd();


            builder.HasOne(e => e.JobUrl)
               .WithOne(p => p.Salary)
               .HasForeignKey<JobUrl>(f => f.SalaryId);
        }
    }
    
}
