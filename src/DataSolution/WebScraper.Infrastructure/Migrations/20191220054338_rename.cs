using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMeta_tag_tblData_jobInfo_JobInfoId",
                table: "tblMeta_tag");

            migrationBuilder.DropForeignKey(
                name: "FK_tblMeta_tag_tblMeta_tagCategory_TagCategoryId",
                table: "tblMeta_tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblMeta_tag",
                table: "tblMeta_tag");

            migrationBuilder.RenameTable(
                name: "tblMeta_tag",
                newName: "tblData_tag");

            migrationBuilder.RenameIndex(
                name: "IX_tblMeta_tag_TagCategoryId",
                table: "tblData_tag",
                newName: "IX_tblData_tag_TagCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_tblMeta_tag_JobInfoId",
                table: "tblData_tag",
                newName: "IX_tblData_tag_JobInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblData_tag",
                table: "tblData_tag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblData_tag_tblData_jobInfo_JobInfoId",
                table: "tblData_tag",
                column: "JobInfoId",
                principalTable: "tblData_jobInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblData_tag_tblMeta_tagCategory_TagCategoryId",
                table: "tblData_tag",
                column: "TagCategoryId",
                principalTable: "tblMeta_tagCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblData_tag_tblData_jobInfo_JobInfoId",
                table: "tblData_tag");

            migrationBuilder.DropForeignKey(
                name: "FK_tblData_tag_tblMeta_tagCategory_TagCategoryId",
                table: "tblData_tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblData_tag",
                table: "tblData_tag");

            migrationBuilder.RenameTable(
                name: "tblData_tag",
                newName: "tblMeta_tag");

            migrationBuilder.RenameIndex(
                name: "IX_tblData_tag_TagCategoryId",
                table: "tblMeta_tag",
                newName: "IX_tblMeta_tag_TagCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_tblData_tag_JobInfoId",
                table: "tblMeta_tag",
                newName: "IX_tblMeta_tag_JobInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblMeta_tag",
                table: "tblMeta_tag",
                column: "Id");

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
    }
}
