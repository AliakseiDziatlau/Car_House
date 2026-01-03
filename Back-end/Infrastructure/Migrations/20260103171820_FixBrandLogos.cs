using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back_end.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixBrandLogos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 20, 573, DateTimeKind.Utc).AddTicks(7030), "$2a$11$6UxrO.QQgz62N42BbwWV.uzZSV5/ysdS1WSp8eaXXcUG0PhbyaBXW" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b5555555-5555-5555-5555-555555555555"),
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/9/9e/Mercedes-Benz_Logo_2010.svg");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b8888888-8888-8888-8888-888888888888"),
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/1/1e/Chevrolet-logo.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 7, 47, 757, DateTimeKind.Utc).AddTicks(1340), "$2a$11$U2MvnDiGQIRCWNAN1gUT/OY3MwL.EfSV8wX6/frHGTQ51uZX8nA9O" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b5555555-5555-5555-5555-555555555555"),
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/9/90/Mercedes-Benz_Logo_2010.svg");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b8888888-8888-8888-8888-888888888888"),
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/1/1f/Logo_Chevrolet.svg");
        }
    }
}
