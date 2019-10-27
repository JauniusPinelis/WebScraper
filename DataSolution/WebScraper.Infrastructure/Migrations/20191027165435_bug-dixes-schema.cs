using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class bugdixesschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblData_JobHtml",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HtmlCode = table.Column<string>(nullable: true),
                    JobUrlId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblData_JobHtml", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblData_JobHtml_tblData_JobUrl_JobUrlId",
                        column: x => x.JobUrlId,
                        principalTable: "tblData_JobUrl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblData_JobHtml_JobUrlId",
                table: "tblData_JobHtml",
                column: "JobUrlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblData_JobHtml");
        }
    }
}
