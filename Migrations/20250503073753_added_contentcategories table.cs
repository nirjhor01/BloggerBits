using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BloggerBits.Migrations
{
    /// <inheritdoc />
    public partial class added_contentcategoriestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentCategories_Category_CategoriesId",
                table: "ContentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentCategories_Content_ContentsId",
                table: "ContentCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentCategories",
                table: "ContentCategories");

            migrationBuilder.RenameColumn(
                name: "ContentsId",
                table: "ContentCategories",
                newName: "ContentId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "ContentCategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ContentCategories_ContentsId",
                table: "ContentCategories",
                newName: "IX_ContentCategories_ContentId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ContentCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ContentCategories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ContentCategories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "ContentCategories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Content",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentCategories",
                table: "ContentCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ContentCategories_CategoryId",
                table: "ContentCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCategories_Category_CategoryId",
                table: "ContentCategories",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCategories_Content_ContentId",
                table: "ContentCategories",
                column: "ContentId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentCategories_Category_CategoryId",
                table: "ContentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentCategories_Content_ContentId",
                table: "ContentCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentCategories",
                table: "ContentCategories");

            migrationBuilder.DropIndex(
                name: "IX_ContentCategories_CategoryId",
                table: "ContentCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ContentCategories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ContentCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ContentCategories");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "ContentCategories");

            migrationBuilder.RenameColumn(
                name: "ContentId",
                table: "ContentCategories",
                newName: "ContentsId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ContentCategories",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_ContentCategories_ContentId",
                table: "ContentCategories",
                newName: "IX_ContentCategories_ContentsId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Content",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentCategories",
                table: "ContentCategories",
                columns: new[] { "CategoriesId", "ContentsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCategories_Category_CategoriesId",
                table: "ContentCategories",
                column: "CategoriesId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCategories_Content_ContentsId",
                table: "ContentCategories",
                column: "ContentsId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
