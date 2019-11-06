﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Infrastructure.Migrations
{
    [DbContext(typeof(JobDbContext))]
    partial class JobDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebScraper.Core.Entities.JobInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasMaxLength(6)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HtmlCode")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(100000);

                    b.Property<int?>("JobUrlId")
                        .HasColumnType("int");

                    b.Property<string>("Salary")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(100000);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(100000);

                    b.HasKey("Id");

                    b.HasIndex("JobUrlId")
                        .IsUnique()
                        .HasFilter("[JobUrlId] IS NOT NULL");

                    b.ToTable("tblData_jobInfo");
                });

            modelBuilder.Entity("WebScraper.Core.Entities.JobUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasMaxLength(5)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("JobInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("tblData_jobUrl");
                });

            modelBuilder.Entity("WebScraper.Core.Entities.JobInfo", b =>
                {
                    b.HasOne("WebScraper.Core.Entities.JobUrl", "JobUrl")
                        .WithOne("JobInfo")
                        .HasForeignKey("WebScraper.Core.Entities.JobInfo", "JobUrlId")
                        .HasConstraintName("FK_tblData_JobInfo_tblDataUrl")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
