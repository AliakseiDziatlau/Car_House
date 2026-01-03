using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back_end.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCarImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 7, 47, 757, DateTimeKind.Utc).AddTicks(1340), "$2a$11$U2MvnDiGQIRCWNAN1gUT/OY3MwL.EfSV8wX6/frHGTQ51uZX8nA9O" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-1111-1111-1111-111111111111"),
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/a/ad/2024_Toyota_Camry_HEV_Premium_Luxury.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-2222-2222-2222-222222222222"),
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/b/b5/2022_Honda_Civic_Touring_in_Lunar_Silver_Metallic%2C_Front_Left%2C_05-10-2022.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-3333-3333-333333333333"),
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/9/97/2024_Ford_Mustang_2.3_EcoBoost_in_Race_Red%2C_front_left%2C_06-26-2024.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-4444-4444-4444-444444444444"),
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/e/e4/2019_BMW_318d_SE_Automatic_2.0_Front.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c5555555-5555-5555-5555-555555555555"),
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/f/fc/2022_Mercedes-Benz_C-Class_C220d_Avantgarde.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c6666666-6666-6666-6666-666666666666"),
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/9/9b/Audi_A4_B9_Limousine_3.0_TDI_quattro.JPG");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c7777777-7777-7777-7777-777777777777"),
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/0/04/2020_Volkswagen_Golf_GTi_TSi_S-A_2.0_Front.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c8888888-8888-8888-8888-888888888888"),
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/e/e7/18_Chevrolet_Camaro_SS.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c9999999-9999-9999-9999-999999999999"),
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/f/fa/20_Nissan_Altima_2.5_S.jpg");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("caaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/b/bd/0_Hyundai_Sonata_%28DN8%29_1.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 3, 0, 11, 51, 455, DateTimeKind.Utc).AddTicks(4210), "$2a$11$beK4qZeVCEoa/Z0zfVJjKuCSjXGZxpowwl/dssGxE6zy60r0rSGVG" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-1111-1111-1111-111111111111"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-2222-2222-2222-222222222222"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-3333-3333-333333333333"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-4444-4444-4444-444444444444"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c5555555-5555-5555-5555-555555555555"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c6666666-6666-6666-6666-666666666666"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c7777777-7777-7777-7777-777777777777"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c8888888-8888-8888-8888-888888888888"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c9999999-9999-9999-9999-999999999999"),
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("caaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "ImageUrl",
                value: null);
        }
    }
}
