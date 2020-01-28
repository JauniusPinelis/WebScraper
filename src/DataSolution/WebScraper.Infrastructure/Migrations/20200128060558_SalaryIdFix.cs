using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class SalaryIdFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblData_jobInfo_tblData_salary_SalaryId",
                table: "tblData_jobInfo");

            migrationBuilder.DropIndex(
                name: "IX_tblData_jobInfo_SalaryId",
                table: "tblData_jobInfo");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "tblData_salary",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "tblData_salary",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalaryId",
                table: "tblData_jobInfo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_tblData_jobInfo_SalaryId",
                table: "tblData_jobInfo",
                column: "SalaryId",
                unique: true,
                filter: "[SalaryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_tblData_jobInfo_tblData_salary_SalaryId",
                table: "tblData_jobInfo",
                column: "SalaryId",
                principalTable: "tblData_salary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblData_jobInfo_tblData_salary_SalaryId",
                table: "tblData_jobInfo");

            migrationBuilder.DropIndex(
                name: "IX_tblData_jobInfo_SalaryId",
                table: "tblData_jobInfo");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "tblData_salary");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "tblData_salary");

            migrationBuilder.AlterColumn<int>(
                name: "SalaryId",
                table: "tblData_jobInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblData_jobInfo_SalaryId",
                table: "tblData_jobInfo",
                column: "SalaryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblData_jobInfo_tblData_salary_SalaryId",
                table: "tblData_jobInfo",
                column: "SalaryId",
                principalTable: "tblData_salary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
