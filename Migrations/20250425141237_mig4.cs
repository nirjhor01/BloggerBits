using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloggerBits.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "UpdatedAt", "Username", "isActive" },
                values: new object[] { 1, new DateTime(2025, 4, 25, 14, 12, 36, 598, DateTimeKind.Utc).AddTicks(3271), "admin@bloggerbits.com", "DefaultName", new DateTime(2025, 4, 25, 14, 12, 36, 598, DateTimeKind.Utc).AddTicks(3384), "admin", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
