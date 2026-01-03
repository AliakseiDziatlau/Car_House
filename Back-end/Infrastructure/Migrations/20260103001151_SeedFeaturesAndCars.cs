using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Back_end.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedFeaturesAndCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "CreatedAt", "Description", "ImageUrl", "IsAvailable", "Mileage", "Model", "Price", "Year" },
                values: new object[,]
                {
                    { new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Reliable midsize sedan with excellent fuel economy", null, true, 0, "Camry", 28500m, 2024 },
                    { new Guid("c2222222-2222-2222-2222-222222222222"), new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Compact car with sporty handling and great reliability", null, true, 0, "Civic", 24500m, 2024 },
                    { new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Iconic American muscle car with V8 power", null, true, 5000, "Mustang GT", 42000m, 2024 },
                    { new Guid("c4444444-4444-4444-4444-444444444444"), new Guid("b4444444-4444-4444-4444-444444444444"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Luxury sport sedan with dynamic performance", null, true, 0, "3 Series", 46000m, 2024 },
                    { new Guid("c5555555-5555-5555-5555-555555555555"), new Guid("b5555555-5555-5555-5555-555555555555"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Elegant luxury sedan with advanced technology", null, true, 0, "C-Class", 48000m, 2024 },
                    { new Guid("c6666666-6666-6666-6666-666666666666"), new Guid("b6666666-6666-6666-6666-666666666666"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Premium compact sedan with Quattro AWD", null, true, 0, "A4", 44000m, 2024 },
                    { new Guid("c7777777-7777-7777-7777-777777777777"), new Guid("b7777777-7777-7777-7777-777777777777"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Hot hatch with turbocharged performance", null, true, 0, "Golf GTI", 32000m, 2024 },
                    { new Guid("c8888888-8888-8888-8888-888888888888"), new Guid("b8888888-8888-8888-8888-888888888888"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "American sports car with aggressive styling", null, true, 3000, "Camaro SS", 45000m, 2024 },
                    { new Guid("c9999999-9999-9999-9999-999999999999"), new Guid("b9999999-9999-9999-9999-999999999999"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Comfortable midsize sedan with AWD option", null, true, 0, "Altima", 27000m, 2024 },
                    { new Guid("caaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("baaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Stylish midsize sedan with excellent value", null, true, 0, "Sonata", 26500m, 2024 }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Category", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("f1111111-1111-1111-1111-111111111111"), "Safety", "Anti-lock Braking System prevents wheel lockup during braking", "ABS" },
                    { new Guid("f2222222-2222-2222-2222-222222222222"), "Safety", "Front and side airbags for driver and passenger protection", "Airbags" },
                    { new Guid("f3333333-3333-3333-3333-333333333333"), "Safety", "Alerts driver to vehicles in blind spots", "Blind Spot Monitor" },
                    { new Guid("f4444444-4444-4444-4444-444444444444"), "Comfort", "Premium leather upholstery", "Leather Seats" },
                    { new Guid("f5555555-5555-5555-5555-555555555555"), "Comfort", "Panoramic glass sunroof", "Sunroof" },
                    { new Guid("f6666666-6666-6666-6666-666666666666"), "Comfort", "Front heated seats for cold weather comfort", "Heated Seats" },
                    { new Guid("f7777777-7777-7777-7777-777777777777"), "Technology", "Built-in GPS navigation with real-time traffic", "Navigation System" },
                    { new Guid("f8888888-8888-8888-8888-888888888888"), "Technology", "Wireless phone and audio connectivity", "Bluetooth" },
                    { new Guid("f9999999-9999-9999-9999-999999999999"), "Technology", "Rear-view camera for safe reversing", "Backup Camera" },
                    { new Guid("faaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Performance", "Turbocharged engine for enhanced power", "Turbo Engine" },
                    { new Guid("fbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Performance", "Performance-tuned suspension system", "Sport Suspension" },
                    { new Guid("fccccccc-cccc-cccc-cccc-cccccccccccc"), "Performance", "AWD system for improved traction", "All-Wheel Drive" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 3, 0, 11, 51, 455, DateTimeKind.Utc).AddTicks(4210), "$2a$11$beK4qZeVCEoa/Z0zfVJjKuCSjXGZxpowwl/dssGxE6zy60r0rSGVG" });

            migrationBuilder.InsertData(
                table: "CarFeatures",
                columns: new[] { "CarId", "FeatureId", "AdditionalPrice", "IsStandard" },
                values: new object[,]
                {
                    { new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("f1111111-1111-1111-1111-111111111111"), 0m, true },
                    { new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("f2222222-2222-2222-2222-222222222222"), 0m, true },
                    { new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("f8888888-8888-8888-8888-888888888888"), 0m, true },
                    { new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("f9999999-9999-9999-9999-999999999999"), 0m, true },
                    { new Guid("c2222222-2222-2222-2222-222222222222"), new Guid("f1111111-1111-1111-1111-111111111111"), 0m, true },
                    { new Guid("c2222222-2222-2222-2222-222222222222"), new Guid("f2222222-2222-2222-2222-222222222222"), 0m, true },
                    { new Guid("c2222222-2222-2222-2222-222222222222"), new Guid("f8888888-8888-8888-8888-888888888888"), 0m, true },
                    { new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("f1111111-1111-1111-1111-111111111111"), 0m, true },
                    { new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("f2222222-2222-2222-2222-222222222222"), 0m, true },
                    { new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("f4444444-4444-4444-4444-444444444444"), 1500m, false },
                    { new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("fbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), 0m, true },
                    { new Guid("c4444444-4444-4444-4444-444444444444"), new Guid("f1111111-1111-1111-1111-111111111111"), 0m, true },
                    { new Guid("c4444444-4444-4444-4444-444444444444"), new Guid("f2222222-2222-2222-2222-222222222222"), 0m, true },
                    { new Guid("c4444444-4444-4444-4444-444444444444"), new Guid("f4444444-4444-4444-4444-444444444444"), 0m, true },
                    { new Guid("c4444444-4444-4444-4444-444444444444"), new Guid("f5555555-5555-5555-5555-555555555555"), 1200m, false },
                    { new Guid("c4444444-4444-4444-4444-444444444444"), new Guid("f7777777-7777-7777-7777-777777777777"), 0m, true },
                    { new Guid("c5555555-5555-5555-5555-555555555555"), new Guid("f1111111-1111-1111-1111-111111111111"), 0m, true },
                    { new Guid("c5555555-5555-5555-5555-555555555555"), new Guid("f2222222-2222-2222-2222-222222222222"), 0m, true },
                    { new Guid("c5555555-5555-5555-5555-555555555555"), new Guid("f3333333-3333-3333-3333-333333333333"), 0m, true },
                    { new Guid("c5555555-5555-5555-5555-555555555555"), new Guid("f4444444-4444-4444-4444-444444444444"), 0m, true },
                    { new Guid("c5555555-5555-5555-5555-555555555555"), new Guid("f6666666-6666-6666-6666-666666666666"), 0m, true },
                    { new Guid("c5555555-5555-5555-5555-555555555555"), new Guid("f7777777-7777-7777-7777-777777777777"), 0m, true },
                    { new Guid("c6666666-6666-6666-6666-666666666666"), new Guid("f1111111-1111-1111-1111-111111111111"), 0m, true },
                    { new Guid("c6666666-6666-6666-6666-666666666666"), new Guid("f2222222-2222-2222-2222-222222222222"), 0m, true },
                    { new Guid("c6666666-6666-6666-6666-666666666666"), new Guid("f4444444-4444-4444-4444-444444444444"), 0m, true },
                    { new Guid("c6666666-6666-6666-6666-666666666666"), new Guid("f7777777-7777-7777-7777-777777777777"), 0m, true },
                    { new Guid("c6666666-6666-6666-6666-666666666666"), new Guid("fccccccc-cccc-cccc-cccc-cccccccccccc"), 0m, true },
                    { new Guid("c7777777-7777-7777-7777-777777777777"), new Guid("f1111111-1111-1111-1111-111111111111"), 0m, true },
                    { new Guid("c7777777-7777-7777-7777-777777777777"), new Guid("f2222222-2222-2222-2222-222222222222"), 0m, true },
                    { new Guid("c7777777-7777-7777-7777-777777777777"), new Guid("faaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 0m, true },
                    { new Guid("c7777777-7777-7777-7777-777777777777"), new Guid("fbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), 0m, true },
                    { new Guid("c8888888-8888-8888-8888-888888888888"), new Guid("f1111111-1111-1111-1111-111111111111"), 0m, true },
                    { new Guid("c8888888-8888-8888-8888-888888888888"), new Guid("f2222222-2222-2222-2222-222222222222"), 0m, true },
                    { new Guid("c8888888-8888-8888-8888-888888888888"), new Guid("f4444444-4444-4444-4444-444444444444"), 0m, true },
                    { new Guid("c8888888-8888-8888-8888-888888888888"), new Guid("fbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), 0m, true },
                    { new Guid("c9999999-9999-9999-9999-999999999999"), new Guid("f1111111-1111-1111-1111-111111111111"), 0m, true },
                    { new Guid("c9999999-9999-9999-9999-999999999999"), new Guid("f2222222-2222-2222-2222-222222222222"), 0m, true },
                    { new Guid("c9999999-9999-9999-9999-999999999999"), new Guid("f8888888-8888-8888-8888-888888888888"), 0m, true },
                    { new Guid("c9999999-9999-9999-9999-999999999999"), new Guid("fccccccc-cccc-cccc-cccc-cccccccccccc"), 2000m, false },
                    { new Guid("caaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("f1111111-1111-1111-1111-111111111111"), 0m, true },
                    { new Guid("caaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("f2222222-2222-2222-2222-222222222222"), 0m, true },
                    { new Guid("caaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("f3333333-3333-3333-3333-333333333333"), 0m, true },
                    { new Guid("caaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("f8888888-8888-8888-8888-888888888888"), 0m, true },
                    { new Guid("caaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("f9999999-9999-9999-9999-999999999999"), 0m, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("f1111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("f2222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("f8888888-8888-8888-8888-888888888888") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("f9999999-9999-9999-9999-999999999999") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c2222222-2222-2222-2222-222222222222"), new Guid("f1111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c2222222-2222-2222-2222-222222222222"), new Guid("f2222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c2222222-2222-2222-2222-222222222222"), new Guid("f8888888-8888-8888-8888-888888888888") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("f1111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("f2222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("f4444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c3333333-3333-3333-3333-333333333333"), new Guid("fbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c4444444-4444-4444-4444-444444444444"), new Guid("f1111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c4444444-4444-4444-4444-444444444444"), new Guid("f2222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c4444444-4444-4444-4444-444444444444"), new Guid("f4444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c4444444-4444-4444-4444-444444444444"), new Guid("f5555555-5555-5555-5555-555555555555") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c4444444-4444-4444-4444-444444444444"), new Guid("f7777777-7777-7777-7777-777777777777") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c5555555-5555-5555-5555-555555555555"), new Guid("f1111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c5555555-5555-5555-5555-555555555555"), new Guid("f2222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c5555555-5555-5555-5555-555555555555"), new Guid("f3333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c5555555-5555-5555-5555-555555555555"), new Guid("f4444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c5555555-5555-5555-5555-555555555555"), new Guid("f6666666-6666-6666-6666-666666666666") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c5555555-5555-5555-5555-555555555555"), new Guid("f7777777-7777-7777-7777-777777777777") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c6666666-6666-6666-6666-666666666666"), new Guid("f1111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c6666666-6666-6666-6666-666666666666"), new Guid("f2222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c6666666-6666-6666-6666-666666666666"), new Guid("f4444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c6666666-6666-6666-6666-666666666666"), new Guid("f7777777-7777-7777-7777-777777777777") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c6666666-6666-6666-6666-666666666666"), new Guid("fccccccc-cccc-cccc-cccc-cccccccccccc") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c7777777-7777-7777-7777-777777777777"), new Guid("f1111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c7777777-7777-7777-7777-777777777777"), new Guid("f2222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c7777777-7777-7777-7777-777777777777"), new Guid("faaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c7777777-7777-7777-7777-777777777777"), new Guid("fbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c8888888-8888-8888-8888-888888888888"), new Guid("f1111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c8888888-8888-8888-8888-888888888888"), new Guid("f2222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c8888888-8888-8888-8888-888888888888"), new Guid("f4444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c8888888-8888-8888-8888-888888888888"), new Guid("fbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c9999999-9999-9999-9999-999999999999"), new Guid("f1111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c9999999-9999-9999-9999-999999999999"), new Guid("f2222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c9999999-9999-9999-9999-999999999999"), new Guid("f8888888-8888-8888-8888-888888888888") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c9999999-9999-9999-9999-999999999999"), new Guid("fccccccc-cccc-cccc-cccc-cccccccccccc") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("caaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("f1111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("caaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("f2222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("caaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("f3333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("caaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("f8888888-8888-8888-8888-888888888888") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("caaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("f9999999-9999-9999-9999-999999999999") });

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c5555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c6666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c7777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c8888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c9999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("caaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f4444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f5555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f6666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f7777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f8888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f9999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("faaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("fbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("fccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 3, 0, 7, 21, 431, DateTimeKind.Utc).AddTicks(7600), "$2a$11$TqGoKMP1yQZloXSoKlRbZ.RAww.n8Ut7qXSCRd9RbHTMTqgCBXEry" });
        }
    }
}
