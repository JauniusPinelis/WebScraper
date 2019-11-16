using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class AddedJobPortal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobPortalId",
                table: "tblData_jobUrl",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblData_jobUrl_JobInfoId",
                table: "tblData_jobUrl",
                column: "JobInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblData_jobUrl_tblMeta_jobPortal_JobInfoId",
                table: "tblData_jobUrl",
                column: "JobInfoId",
                principalTable: "tblMeta_jobPortal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblData_jobUrl_tblMeta_jobPortal_JobInfoId",
                table: "tblData_jobUrl");

            migrationBuilder.DropIndex(
                name: "IX_tblData_jobUrl_JobInfoId",
                table: "tblData_jobUrl");

            migrationBuilder.DropColumn(
                name: "JobPortalId",
                table: "tblData_jobUrl");
        }
    }
}
