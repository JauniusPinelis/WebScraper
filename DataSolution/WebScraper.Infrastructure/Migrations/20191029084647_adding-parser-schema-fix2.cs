using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class addingparserschemafix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblData_JobUrl_tblData_JonInfo_InfoId",
                table: "tblData_JobUrl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblData_JonInfo",
                table: "tblData_JonInfo");

            migrationBuilder.RenameTable(
                name: "tblData_JonInfo",
                newName: "tblData_JobInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblData_JobInfo",
                table: "tblData_JobInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblData_JobUrl_tblData_JobInfo_InfoId",
                table: "tblData_JobUrl",
                column: "InfoId",
                principalTable: "tblData_JobInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblData_JobUrl_tblData_JobInfo_InfoId",
                table: "tblData_JobUrl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblData_JobInfo",
                table: "tblData_JobInfo");

            migrationBuilder.RenameTable(
                name: "tblData_JobInfo",
                newName: "tblData_JonInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblData_JonInfo",
                table: "tblData_JonInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblData_JobUrl_tblData_JonInfo_InfoId",
                table: "tblData_JobUrl",
                column: "InfoId",
                principalTable: "tblData_JonInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
