﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Infrastructure.Migrations
{
    [DbContext(typeof(JobDbContext))]
    partial class ScraperDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebScraper.Infrastructure.Entities.JobHtml", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HtmlCode");

                    b.Property<int>("JobUrlId");

                    b.HasKey("Id");

                    b.HasIndex("JobUrlId");

                    b.ToTable("tblData_JobHtml");
                });

            modelBuilder.Entity("WebScraper.Infrastructure.Entities.JobInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Salary");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("tblData_JobInfo");
                });

            modelBuilder.Entity("WebScraper.Infrastructure.Entities.JobUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<int>("InfoId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("InfoId");

                    b.ToTable("tblData_JobUrl");
                });

            modelBuilder.Entity("WebScraper.Infrastructure.Entities.JobUrlCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("tblData_JobUrlCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "CvOnline.lt"
                        });
                });

            modelBuilder.Entity("WebScraper.Infrastructure.Entities.JobHtml", b =>
                {
                    b.HasOne("WebScraper.Infrastructure.Entities.JobUrl", "JobUrl")
                        .WithMany()
                        .HasForeignKey("JobUrlId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebScraper.Infrastructure.Entities.JobUrl", b =>
                {
                    b.HasOne("WebScraper.Infrastructure.Entities.JobUrlCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebScraper.Infrastructure.Entities.JobInfo", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
