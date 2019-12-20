using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class tagsimplementation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblMeta_tag",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblMeta_tag",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblMeta_tag",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblMeta_tag",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblMeta_tag",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "tblMeta_tag");

            migrationBuilder.AddColumn<int>(
                name: "JobInfoId",
                table: "tblMeta_tag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TagCategoryId",
                table: "tblMeta_tag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tblMeta_tagCategory",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMeta_tagCategory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tblMeta_tagCategory",
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
                name: "IX_tblMeta_tag_JobInfoId",
                table: "tblMeta_tag",
                column: "JobInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMeta_tag_TagCategoryId",
                table: "tblMeta_tag",
                column: "TagCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMeta_tag_tblData_jobInfo_JobInfoId",
                table: "tblMeta_tag",
                column: "JobInfoId",
                principalTable: "tblData_jobInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblMeta_tag_tblMeta_tagCategory_TagCategoryId",
                table: "tblMeta_tag",
                column: "TagCategoryId",
                principalTable: "tblMeta_tagCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMeta_tag_tblData_jobInfo_JobInfoId",
                table: "tblMeta_tag");

            migrationBuilder.DropForeignKey(
                name: "FK_tblMeta_tag_tblMeta_tagCategory_TagCategoryId",
                table: "tblMeta_tag");

            migrationBuilder.DropTable(
                name: "tblMeta_tagCategory");

            migrationBuilder.DropIndex(
                name: "IX_tblMeta_tag_JobInfoId",
                table: "tblMeta_tag");

            migrationBuilder.DropIndex(
                name: "IX_tblMeta_tag_TagCategoryId",
                table: "tblMeta_tag");

            migrationBuilder.DropColumn(
                name: "JobInfoId",
                table: "tblMeta_tag");

            migrationBuilder.DropColumn(
                name: "TagCategoryId",
                table: "tblMeta_tag");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "tblMeta_tag",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

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
        }
    }
}
