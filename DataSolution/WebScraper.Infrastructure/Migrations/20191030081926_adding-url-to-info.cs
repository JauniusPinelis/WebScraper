using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class addingurltoinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobUrlId",
                table: "tblData_JobInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblData_JobInfo_JobUrlId",
                table: "tblData_JobInfo",
                column: "JobUrlId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblData_JobInfo_tblData_JobUrl_JobUrlId",
                table: "tblData_JobInfo",
                column: "JobUrlId",
                principalTable: "tblData_JobUrl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblData_JobInfo_tblData_JobUrl_JobUrlId",
                table: "tblData_JobInfo");

            migrationBuilder.DropIndex(
                name: "IX_tblData_JobInfo_JobUrlId",
                table: "tblData_JobInfo");

            migrationBuilder.DropColumn(
                name: "JobUrlId",
                table: "tblData_JobInfo");
        }
    }
}
