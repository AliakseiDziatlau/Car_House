using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back_end.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBrandLogos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-1111-1111-1111-111111111111"),
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/e/e7/Toyota.svg");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"),
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/7/76/Honda_logo.svg");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-3333-3333-3333-333333333333"),
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/a/a0/Ford_Motor_Company_Logo.svg");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b4444444-4444-4444-4444-444444444444"),
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/4/44/BMW.svg");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b5555555-5555-5555-5555-555555555555"),
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/9/90/Mercedes-Benz_Logo_2010.svg");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b6666666-6666-6666-6666-666666666666"),
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/9/92/Audi-Logo_2016.svg");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b7777777-7777-7777-7777-777777777777"),
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/6/6d/Volkswagen_logo_2019.svg");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b8888888-8888-8888-8888-888888888888"),
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/1/1f/Logo_Chevrolet.svg");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b9999999-9999-9999-9999-999999999999"),
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/2/23/Nissan_2020_logo.svg");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("baaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "LogoUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/4/44/Hyundai_Motor_Company_logo.svg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 3, 0, 7, 21, 431, DateTimeKind.Utc).AddTicks(7600), "$2a$11$TqGoKMP1yQZloXSoKlRbZ.RAww.n8Ut7qXSCRd9RbHTMTqgCBXEry" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-1111-1111-1111-111111111111"),
                column: "LogoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"),
                column: "LogoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-3333-3333-3333-333333333333"),
                column: "LogoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b4444444-4444-4444-4444-444444444444"),
                column: "LogoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b5555555-5555-5555-5555-555555555555"),
                column: "LogoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b6666666-6666-6666-6666-666666666666"),
                column: "LogoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b7777777-7777-7777-7777-777777777777"),
                column: "LogoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b8888888-8888-8888-8888-888888888888"),
                column: "LogoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b9999999-9999-9999-9999-999999999999"),
                column: "LogoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("baaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "LogoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 2, 23, 58, 42, 571, DateTimeKind.Utc).AddTicks(9690), "$2a$11$1m2fXNtzmZvXh0XyiRHpQuC/C.fkDg0hwrCcnfUuiOtZTADgu4z/O" });
        }
    }
}
