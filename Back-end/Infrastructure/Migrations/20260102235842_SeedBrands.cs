using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Back_end.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedBrands : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Country", "LogoUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("b1111111-1111-1111-1111-111111111111"), "Japan", null, "Toyota" },
                    { new Guid("b2222222-2222-2222-2222-222222222222"), "Japan", null, "Honda" },
                    { new Guid("b3333333-3333-3333-3333-333333333333"), "USA", null, "Ford" },
                    { new Guid("b4444444-4444-4444-4444-444444444444"), "Germany", null, "BMW" },
                    { new Guid("b5555555-5555-5555-5555-555555555555"), "Germany", null, "Mercedes-Benz" },
                    { new Guid("b6666666-6666-6666-6666-666666666666"), "Germany", null, "Audi" },
                    { new Guid("b7777777-7777-7777-7777-777777777777"), "Germany", null, "Volkswagen" },
                    { new Guid("b8888888-8888-8888-8888-888888888888"), "USA", null, "Chevrolet" },
                    { new Guid("b9999999-9999-9999-9999-999999999999"), "Japan", null, "Nissan" },
                    { new Guid("baaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "South Korea", null, "Hyundai" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 23, 58, 42, 571, DateTimeKind.Utc).AddTicks(9690), "$2a$11$1m2fXNtzmZvXh0XyiRHpQuC/C.fkDg0hwrCcnfUuiOtZTADgu4z/O" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b4444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b5555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b6666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b7777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b8888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b9999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("baaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2025, 12, 25, 23, 45, 27, 637, DateTimeKind.Utc).AddTicks(2480), "$2a$11$D43qRZXX4Kgy6t6XZV8me.wWygQz5N1.ejkDnO26RpjrYWRi8Ul8G" });
        }
    }
}
