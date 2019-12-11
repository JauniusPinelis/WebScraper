using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblMeta_jobPortal",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMeta_jobPortal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblMeta_tag",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMeta_tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblData_jobUrl",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Url = table.Column<string>(maxLength: 300, nullable: true),
                    Salary = table.Column<string>(maxLength: 500, nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    JobInfoId = table.Column<int>(nullable: true),
                    JobPortalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblData_jobUrl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblData_jobUrl_tblMeta_jobPortal_JobInfoId",
                        column: x => x.JobInfoId,
                        principalTable: "tblMeta_jobPortal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblData_jobInfo",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 6, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    HtmlCode = table.Column<string>(maxLength: 100000, nullable: true),
                    Title = table.Column<string>(maxLength: 100000, nullable: true),
                    Salary = table.Column<string>(maxLength: 100000, nullable: true),
                    JobUrlId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblData_jobInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblData_JobInfo_tblDataUrl",
                        column: x => x.JobUrlId,
                        principalTable: "tblData_jobUrl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "tblMeta_jobPortal",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CvOnline" },
                    { 2, "CvBankas" },
                    { 3, "CvLt" }
                });

            migrationBuilder.InsertData(
                table: "tblMeta_tag",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, ".NET" },
                    { 2, "C#" },
                    { 3, "PHP" },
                    { 4, "Java" },
                    { 5, "Javascript" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblData_jobInfo_JobUrlId",
                table: "tblData_jobInfo",
                column: "JobUrlId",
                unique: true,
                filter: "[JobUrlId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblData_jobUrl_JobInfoId",
                table: "tblData_jobUrl",
                column: "JobInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblData_jobInfo");

            migrationBuilder.DropTable(
                name: "tblMeta_tag");

            migrationBuilder.DropTable(
                name: "tblData_jobUrl");

            migrationBuilder.DropTable(
                name: "tblMeta_jobPortal");
        }
    }
}
