using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back_end.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 23, 46, 448, DateTimeKind.Utc).AddTicks(7380), "$2a$11$XtfjIo.ZQyLC7ULml/1cVu7Wm8VavvEtqHgokaQk3gi.q0bL9w.7G" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name", "Country", "LogoUrl" },
                values: new object[,]
                {
                    { new Guid("b0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"), "Porsche", "Germany", "https://upload.wikimedia.org/wikipedia/commons/e/ee/Porsche-Automarken-Logo.jpg" },
                    { new Guid("b0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"), "Lexus", "Japan", "https://upload.wikimedia.org/wikipedia/commons/7/75/Lexus.svg" },
                    { new Guid("b0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"), "Mazda", "Japan", "https://upload.wikimedia.org/wikipedia/commons/b/b6/Mazda_logo_with_emblem%2C_new.svg" },
                    { new Guid("b0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), "Tesla", "USA", "https://upload.wikimedia.org/wikipedia/commons/b/bd/Tesla_Motors.svg" },
                    { new Guid("b0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), "Volvo", "Sweden", "https://upload.wikimedia.org/wikipedia/commons/5/54/Volvo_logo.svg" },
                    { new Guid("b0101010-1010-1010-1010-101010101010"), "Subaru", "Japan", "https://upload.wikimedia.org/wikipedia/commons/4/47/Subaru_logo.svg" }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Name", "Category", "Description" },
                values: new object[,]
                {
                    { new Guid("f0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"), "Lane Departure Warning", "Safety", "Alerts when leaving lane unintentionally" },
                    { new Guid("f0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), "Adaptive Cruise Control", "Safety", "Maintains distance from vehicle ahead" },
                    { new Guid("f0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), "Automatic Emergency Braking", "Safety", "Auto-brakes to prevent collisions" },
                    { new Guid("f0101010-1010-1010-1010-101010101010"), "Ventilated Seats", "Comfort", "Cooled seats for hot weather" },
                    { new Guid("f0111111-1111-1111-1111-111111111111"), "Wireless Charging", "Technology", "Qi wireless phone charging pad" },
                    { new Guid("f0121212-1212-1212-1212-121212121212"), "Apple CarPlay", "Technology", "iPhone integration with car display" },
                    { new Guid("f0131313-1313-1313-1313-131313131313"), "Android Auto", "Technology", "Android phone integration" },
                    { new Guid("f0141414-1414-1414-1414-141414141414"), "360 Camera", "Technology", "Bird's-eye view parking camera" },
                    { new Guid("f0151515-1515-1515-1515-151515151515"), "Electric Motor", "Performance", "Zero-emission electric powertrain" },
                    { new Guid("f0161616-1616-1616-1616-161616161616"), "Launch Control", "Performance", "Optimized acceleration from standstill" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "Model", "Year", "Price", "Mileage", "Description", "ImageUrl", "IsAvailable", "CreatedAt" },
                values: new object[,]
                {
                    { new Guid("c0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"), new Guid("b0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"), "911 Carrera", 2024, 115000m, 0, "Iconic sports car with rear-engine layout and timeless design", "https://upload.wikimedia.org/wikipedia/commons/2/2d/Porsche_911%2C_EMS_2024%2C_Essen_%28P1032183%29.jpg", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0b0b0b1-b0b1-b0b1-b0b1-b0b1b0b1b0b1"), new Guid("b0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"), "Cayenne", 2024, 75000m, 0, "Luxury performance SUV with sports car DNA", "https://upload.wikimedia.org/wikipedia/commons/f/ff/Porsche_Cayenne_Coup%C3%A9_GTS_1X7A7224.jpg", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"), new Guid("b0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"), "ES 350", 2024, 42000m, 0, "Refined luxury sedan with exceptional comfort", "https://upload.wikimedia.org/wikipedia/commons/2/2b/2022_Lexus_ES_350_%28GSZ10%29_1X7A5794.jpg", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0c0c0c1-c0c1-c0c1-c0c1-c0c1c0c1c0c1"), new Guid("b0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"), "RX 350", 2024, 50000m, 0, "Premium luxury crossover with bold styling", "https://upload.wikimedia.org/wikipedia/commons/2/2d/Lexus_RX_450h%2B_%28AALH16%29_1X7A1930.jpg", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"), new Guid("b0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"), "MX-5 Miata", 2024, 28000m, 0, "Lightweight roadster with perfect balance and pure driving joy", "https://upload.wikimedia.org/wikipedia/commons/b/b7/Mazda_MX-5_%28ND%29_1X7A7471.jpg", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0d0d0d1-d0d1-d0d1-d0d1-d0d1d0d1d0d1"), new Guid("b0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"), "CX-5", 2024, 30000m, 0, "Stylish compact SUV with premium feel and engaging drive", "https://upload.wikimedia.org/wikipedia/commons/4/43/Mazda_CX-5_Newground_1X7A6786.jpg", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), new Guid("b0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), "Model 3", 2024, 40000m, 0, "Best-selling electric sedan with cutting-edge technology", "https://upload.wikimedia.org/wikipedia/commons/9/97/Tesla_Model_3%2C_EMS_2024%2C_Essen_%28P1032260%29.jpg", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0e0e0e1-e0e1-e0e1-e0e1-e0e1e0e1e0e1"), new Guid("b0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), "Model Y", 2024, 45000m, 0, "Versatile electric SUV with impressive range and space", "https://upload.wikimedia.org/wikipedia/commons/5/5c/Tesla_Model_Y_1X7A6211.jpg", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), new Guid("b0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), "XC60", 2024, 48000m, 0, "Scandinavian luxury SUV with world-class safety", "https://upload.wikimedia.org/wikipedia/commons/3/30/Volvo_XC60_%28SPA%29_FL_1X7A0185.jpg", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0101010-1010-1010-1010-101010101010"), new Guid("b0101010-1010-1010-1010-101010101010"), "Outback", 2024, 32000m, 0, "Rugged wagon with standard AWD and go-anywhere capability", "https://upload.wikimedia.org/wikipedia/commons/6/6a/Subaru_Outback_%28BT%29_DSC_8814.jpg", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c0101011-1011-1011-1011-101110111011"), new Guid("b0101010-1010-1010-1010-101010101010"), "WRX", 2024, 35000m, 0, "Rally-bred sports sedan with turbocharged performance", "https://upload.wikimedia.org/wikipedia/commons/9/98/SUBARU_WRX_%28VB%29_China.jpg", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "CarFeatures",
                columns: new[] { "CarId", "FeatureId", "IsStandard", "AdditionalPrice" },
                values: new object[,]
                {
                    { new Guid("c0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"), new Guid("f1111111-1111-1111-1111-111111111111"), true, 0m },
                    { new Guid("c0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"), new Guid("f2222222-2222-2222-2222-222222222222"), true, 0m },
                    { new Guid("c0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"), new Guid("f4444444-4444-4444-4444-444444444444"), true, 0m },
                    { new Guid("c0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"), new Guid("fbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, 0m },
                    { new Guid("c0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"), new Guid("f0161616-1616-1616-1616-161616161616"), true, 0m },
                    { new Guid("c0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"), new Guid("f0121212-1212-1212-1212-121212121212"), true, 0m },

                    { new Guid("c0b0b0b1-b0b1-b0b1-b0b1-b0b1b0b1b0b1"), new Guid("f1111111-1111-1111-1111-111111111111"), true, 0m },
                    { new Guid("c0b0b0b1-b0b1-b0b1-b0b1-b0b1b0b1b0b1"), new Guid("f2222222-2222-2222-2222-222222222222"), true, 0m },
                    { new Guid("c0b0b0b1-b0b1-b0b1-b0b1-b0b1b0b1b0b1"), new Guid("f4444444-4444-4444-4444-444444444444"), true, 0m },
                    { new Guid("c0b0b0b1-b0b1-b0b1-b0b1-b0b1b0b1b0b1"), new Guid("fccccccc-cccc-cccc-cccc-cccccccccccc"), true, 0m },
                    { new Guid("c0b0b0b1-b0b1-b0b1-b0b1-b0b1b0b1b0b1"), new Guid("f0141414-1414-1414-1414-141414141414"), true, 0m },
                    { new Guid("c0b0b0b1-b0b1-b0b1-b0b1-b0b1b0b1b0b1"), new Guid("f0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), true, 0m },

                    { new Guid("c0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"), new Guid("f1111111-1111-1111-1111-111111111111"), true, 0m },
                    { new Guid("c0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"), new Guid("f2222222-2222-2222-2222-222222222222"), true, 0m },
                    { new Guid("c0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"), new Guid("f4444444-4444-4444-4444-444444444444"), true, 0m },
                    { new Guid("c0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"), new Guid("f0101010-1010-1010-1010-101010101010"), true, 0m },
                    { new Guid("c0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"), new Guid("f0121212-1212-1212-1212-121212121212"), true, 0m },
                    { new Guid("c0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"), new Guid("f7777777-7777-7777-7777-777777777777"), true, 0m },

                    { new Guid("c0c0c0c1-c0c1-c0c1-c0c1-c0c1c0c1c0c1"), new Guid("f1111111-1111-1111-1111-111111111111"), true, 0m },
                    { new Guid("c0c0c0c1-c0c1-c0c1-c0c1-c0c1c0c1c0c1"), new Guid("f2222222-2222-2222-2222-222222222222"), true, 0m },
                    { new Guid("c0c0c0c1-c0c1-c0c1-c0c1-c0c1c0c1c0c1"), new Guid("f4444444-4444-4444-4444-444444444444"), true, 0m },
                    { new Guid("c0c0c0c1-c0c1-c0c1-c0c1-c0c1c0c1c0c1"), new Guid("f0141414-1414-1414-1414-141414141414"), true, 0m },
                    { new Guid("c0c0c0c1-c0c1-c0c1-c0c1-c0c1c0c1c0c1"), new Guid("f0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), true, 0m },
                    { new Guid("c0c0c0c1-c0c1-c0c1-c0c1-c0c1c0c1c0c1"), new Guid("fccccccc-cccc-cccc-cccc-cccccccccccc"), false, 2500m },

                    { new Guid("c0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"), new Guid("f1111111-1111-1111-1111-111111111111"), true, 0m },
                    { new Guid("c0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"), new Guid("f2222222-2222-2222-2222-222222222222"), true, 0m },
                    { new Guid("c0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"), new Guid("fbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, 0m },
                    { new Guid("c0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"), new Guid("f0121212-1212-1212-1212-121212121212"), true, 0m },

                    { new Guid("c0d0d0d1-d0d1-d0d1-d0d1-d0d1d0d1d0d1"), new Guid("f1111111-1111-1111-1111-111111111111"), true, 0m },
                    { new Guid("c0d0d0d1-d0d1-d0d1-d0d1-d0d1d0d1d0d1"), new Guid("f2222222-2222-2222-2222-222222222222"), true, 0m },
                    { new Guid("c0d0d0d1-d0d1-d0d1-d0d1-d0d1d0d1d0d1"), new Guid("f3333333-3333-3333-3333-333333333333"), true, 0m },
                    { new Guid("c0d0d0d1-d0d1-d0d1-d0d1-d0d1d0d1d0d1"), new Guid("f0121212-1212-1212-1212-121212121212"), true, 0m },
                    { new Guid("c0d0d0d1-d0d1-d0d1-d0d1-d0d1d0d1d0d1"), new Guid("f0131313-1313-1313-1313-131313131313"), true, 0m },
                    { new Guid("c0d0d0d1-d0d1-d0d1-d0d1-d0d1d0d1d0d1"), new Guid("fccccccc-cccc-cccc-cccc-cccccccccccc"), false, 1800m },

                    { new Guid("c0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), new Guid("f1111111-1111-1111-1111-111111111111"), true, 0m },
                    { new Guid("c0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), new Guid("f2222222-2222-2222-2222-222222222222"), true, 0m },
                    { new Guid("c0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), new Guid("f0151515-1515-1515-1515-151515151515"), true, 0m },
                    { new Guid("c0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), new Guid("f0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), true, 0m },
                    { new Guid("c0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), new Guid("f0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), true, 0m },
                    { new Guid("c0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), new Guid("f0111111-1111-1111-1111-111111111111"), true, 0m },

                    { new Guid("c0e0e0e1-e0e1-e0e1-e0e1-e0e1e0e1e0e1"), new Guid("f1111111-1111-1111-1111-111111111111"), true, 0m },
                    { new Guid("c0e0e0e1-e0e1-e0e1-e0e1-e0e1e0e1e0e1"), new Guid("f2222222-2222-2222-2222-222222222222"), true, 0m },
                    { new Guid("c0e0e0e1-e0e1-e0e1-e0e1-e0e1e0e1e0e1"), new Guid("f0151515-1515-1515-1515-151515151515"), true, 0m },
                    { new Guid("c0e0e0e1-e0e1-e0e1-e0e1-e0e1e0e1e0e1"), new Guid("f0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), true, 0m },
                    { new Guid("c0e0e0e1-e0e1-e0e1-e0e1-e0e1e0e1e0e1"), new Guid("f0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), true, 0m },
                    { new Guid("c0e0e0e1-e0e1-e0e1-e0e1-e0e1e0e1e0e1"), new Guid("f0141414-1414-1414-1414-141414141414"), true, 0m },

                    { new Guid("c0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), new Guid("f1111111-1111-1111-1111-111111111111"), true, 0m },
                    { new Guid("c0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), new Guid("f2222222-2222-2222-2222-222222222222"), true, 0m },
                    { new Guid("c0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), new Guid("f4444444-4444-4444-4444-444444444444"), true, 0m },
                    { new Guid("c0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), new Guid("f0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"), true, 0m },
                    { new Guid("c0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), new Guid("f0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), true, 0m },
                    { new Guid("c0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), new Guid("f0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), true, 0m },
                    { new Guid("c0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), new Guid("f0141414-1414-1414-1414-141414141414"), true, 0m },

                    { new Guid("c0101010-1010-1010-1010-101010101010"), new Guid("f1111111-1111-1111-1111-111111111111"), true, 0m },
                    { new Guid("c0101010-1010-1010-1010-101010101010"), new Guid("f2222222-2222-2222-2222-222222222222"), true, 0m },
                    { new Guid("c0101010-1010-1010-1010-101010101010"), new Guid("fccccccc-cccc-cccc-cccc-cccccccccccc"), true, 0m },
                    { new Guid("c0101010-1010-1010-1010-101010101010"), new Guid("f0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"), true, 0m },
                    { new Guid("c0101010-1010-1010-1010-101010101010"), new Guid("f0121212-1212-1212-1212-121212121212"), true, 0m },

                    { new Guid("c0101011-1011-1011-1011-101110111011"), new Guid("f1111111-1111-1111-1111-111111111111"), true, 0m },
                    { new Guid("c0101011-1011-1011-1011-101110111011"), new Guid("f2222222-2222-2222-2222-222222222222"), true, 0m },
                    { new Guid("c0101011-1011-1011-1011-101110111011"), new Guid("fccccccc-cccc-cccc-cccc-cccccccccccc"), true, 0m },
                    { new Guid("c0101011-1011-1011-1011-101110111011"), new Guid("faaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), true, 0m },
                    { new Guid("c0101011-1011-1011-1011-101110111011"), new Guid("fbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), true, 0m },
                    { new Guid("c0101011-1011-1011-1011-101110111011"), new Guid("f0161616-1616-1616-1616-161616161616"), false, 1000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"), new Guid("f1111111-1111-1111-1111-111111111111") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"), new Guid("f2222222-2222-2222-2222-222222222222") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"), new Guid("f4444444-4444-4444-4444-444444444444") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"), new Guid("fbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"), new Guid("f0161616-1616-1616-1616-161616161616") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"), new Guid("f0121212-1212-1212-1212-121212121212") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0b0b0b1-b0b1-b0b1-b0b1-b0b1b0b1b0b1"), new Guid("f1111111-1111-1111-1111-111111111111") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0b0b0b1-b0b1-b0b1-b0b1-b0b1b0b1b0b1"), new Guid("f2222222-2222-2222-2222-222222222222") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0b0b0b1-b0b1-b0b1-b0b1-b0b1b0b1b0b1"), new Guid("f4444444-4444-4444-4444-444444444444") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0b0b0b1-b0b1-b0b1-b0b1-b0b1b0b1b0b1"), new Guid("fccccccc-cccc-cccc-cccc-cccccccccccc") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0b0b0b1-b0b1-b0b1-b0b1-b0b1b0b1b0b1"), new Guid("f0141414-1414-1414-1414-141414141414") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0b0b0b1-b0b1-b0b1-b0b1-b0b1b0b1b0b1"), new Guid("f0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"), new Guid("f1111111-1111-1111-1111-111111111111") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"), new Guid("f2222222-2222-2222-2222-222222222222") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"), new Guid("f4444444-4444-4444-4444-444444444444") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"), new Guid("f0101010-1010-1010-1010-101010101010") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"), new Guid("f0121212-1212-1212-1212-121212121212") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"), new Guid("f7777777-7777-7777-7777-777777777777") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0c0c0c1-c0c1-c0c1-c0c1-c0c1c0c1c0c1"), new Guid("f1111111-1111-1111-1111-111111111111") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0c0c0c1-c0c1-c0c1-c0c1-c0c1c0c1c0c1"), new Guid("f2222222-2222-2222-2222-222222222222") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0c0c0c1-c0c1-c0c1-c0c1-c0c1c0c1c0c1"), new Guid("f4444444-4444-4444-4444-444444444444") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0c0c0c1-c0c1-c0c1-c0c1-c0c1c0c1c0c1"), new Guid("f0141414-1414-1414-1414-141414141414") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0c0c0c1-c0c1-c0c1-c0c1-c0c1c0c1c0c1"), new Guid("f0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0c0c0c1-c0c1-c0c1-c0c1-c0c1c0c1c0c1"), new Guid("fccccccc-cccc-cccc-cccc-cccccccccccc") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"), new Guid("f1111111-1111-1111-1111-111111111111") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"), new Guid("f2222222-2222-2222-2222-222222222222") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"), new Guid("fbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"), new Guid("f0121212-1212-1212-1212-121212121212") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0d0d0d1-d0d1-d0d1-d0d1-d0d1d0d1d0d1"), new Guid("f1111111-1111-1111-1111-111111111111") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0d0d0d1-d0d1-d0d1-d0d1-d0d1d0d1d0d1"), new Guid("f2222222-2222-2222-2222-222222222222") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0d0d0d1-d0d1-d0d1-d0d1-d0d1d0d1d0d1"), new Guid("f3333333-3333-3333-3333-333333333333") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0d0d0d1-d0d1-d0d1-d0d1-d0d1d0d1d0d1"), new Guid("f0121212-1212-1212-1212-121212121212") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0d0d0d1-d0d1-d0d1-d0d1-d0d1d0d1d0d1"), new Guid("f0131313-1313-1313-1313-131313131313") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0d0d0d1-d0d1-d0d1-d0d1-d0d1d0d1d0d1"), new Guid("fccccccc-cccc-cccc-cccc-cccccccccccc") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), new Guid("f1111111-1111-1111-1111-111111111111") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), new Guid("f2222222-2222-2222-2222-222222222222") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), new Guid("f0151515-1515-1515-1515-151515151515") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), new Guid("f0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), new Guid("f0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"), new Guid("f0111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0e0e0e1-e0e1-e0e1-e0e1-e0e1e0e1e0e1"), new Guid("f1111111-1111-1111-1111-111111111111") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0e0e0e1-e0e1-e0e1-e0e1-e0e1e0e1e0e1"), new Guid("f2222222-2222-2222-2222-222222222222") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0e0e0e1-e0e1-e0e1-e0e1-e0e1e0e1e0e1"), new Guid("f0151515-1515-1515-1515-151515151515") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0e0e0e1-e0e1-e0e1-e0e1-e0e1e0e1e0e1"), new Guid("f0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0e0e0e1-e0e1-e0e1-e0e1-e0e1e0e1e0e1"), new Guid("f0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0e0e0e1-e0e1-e0e1-e0e1-e0e1e0e1e0e1"), new Guid("f0141414-1414-1414-1414-141414141414") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), new Guid("f1111111-1111-1111-1111-111111111111") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), new Guid("f2222222-2222-2222-2222-222222222222") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), new Guid("f4444444-4444-4444-4444-444444444444") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), new Guid("f0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), new Guid("f0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), new Guid("f0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"), new Guid("f0141414-1414-1414-1414-141414141414") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0101010-1010-1010-1010-101010101010"), new Guid("f1111111-1111-1111-1111-111111111111") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0101010-1010-1010-1010-101010101010"), new Guid("f2222222-2222-2222-2222-222222222222") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0101010-1010-1010-1010-101010101010"), new Guid("fccccccc-cccc-cccc-cccc-cccccccccccc") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0101010-1010-1010-1010-101010101010"), new Guid("f0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0101010-1010-1010-1010-101010101010"), new Guid("f0121212-1212-1212-1212-121212121212") });

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0101011-1011-1011-1011-101110111011"), new Guid("f1111111-1111-1111-1111-111111111111") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0101011-1011-1011-1011-101110111011"), new Guid("f2222222-2222-2222-2222-222222222222") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0101011-1011-1011-1011-101110111011"), new Guid("fccccccc-cccc-cccc-cccc-cccccccccccc") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0101011-1011-1011-1011-101110111011"), new Guid("faaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0101011-1011-1011-1011-101110111011"), new Guid("fbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") });
            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumns: new[] { "CarId", "FeatureId" },
                keyValues: new object[] { new Guid("c0101011-1011-1011-1011-101110111011"), new Guid("f0161616-1616-1616-1616-161616161616") });

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"));
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c0b0b0b1-b0b1-b0b1-b0b1-b0b1b0b1b0b1"));
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"));
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c0c0c0c1-c0c1-c0c1-c0c1-c0c1c0c1c0c1"));
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"));
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c0d0d0d1-d0d1-d0d1-d0d1-d0d1d0d1d0d1"));
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"));
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c0e0e0e1-e0e1-e0e1-e0e1-e0e1e0e1e0e1"));
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"));
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c0101010-1010-1010-1010-101010101010"));
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c0101011-1011-1011-1011-101110111011"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"));
            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"));
            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"));
            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f0101010-1010-1010-1010-101010101010"));
            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f0111111-1111-1111-1111-111111111111"));
            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f0121212-1212-1212-1212-121212121212"));
            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f0131313-1313-1313-1313-131313131313"));
            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f0141414-1414-1414-1414-141414141414"));
            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f0151515-1515-1515-1515-151515151515"));
            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("f0161616-1616-1616-1616-161616161616"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b0b0b0b0-b0b0-b0b0-b0b0-b0b0b0b0b0b0"));
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b0c0c0c0-c0c0-c0c0-c0c0-c0c0c0c0c0c0"));
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b0d0d0d0-d0d0-d0d0-d0d0-d0d0d0d0d0d0"));
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b0e0e0e0-e0e0-e0e0-e0e0-e0e0e0e0e0e0"));
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b0f0f0f0-f0f0-f0f0-f0f0-f0f0f0f0f0f0"));
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b0101010-1010-1010-1010-101010101010"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 3, 17, 18, 20, 573, DateTimeKind.Utc).AddTicks(7030), "$2a$11$6UxrO.QQgz62N42BbwWV.uzZSV5/ysdS1WSp8eaXXcUG0PhbyaBXW" });
        }
    }
}
