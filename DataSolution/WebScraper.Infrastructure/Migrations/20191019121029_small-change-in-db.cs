using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class smallchangeindb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "tblData_PortalPage",
                newName: "Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "tblData_PortalPage",
                newName: "Data");
        }
    }
}
