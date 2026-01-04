PRAGMA foreign_keys = ON;

DROP TABLE IF EXISTS "CarFeatures";
DROP TABLE IF EXISTS "Orders";
DROP TABLE IF EXISTS "Cars";
DROP TABLE IF EXISTS "Features";
DROP TABLE IF EXISTS "Brands";
DROP TABLE IF EXISTS "Users";
DROP TABLE IF EXISTS "Roles";
DROP TABLE IF EXISTS "__EFMigrationsHistory";

CREATE TABLE "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Roles" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Roles" PRIMARY KEY,
    "Name" TEXT NOT NULL
);

CREATE UNIQUE INDEX "IX_Roles_Name" ON "Roles" ("Name");

CREATE TABLE "Users" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY,
    "Email" TEXT NOT NULL,
    "PasswordHash" TEXT NOT NULL,
    "FirstName" TEXT NOT NULL,
    "LastName" TEXT NOT NULL,
    "RoleId" TEXT NOT NULL,
    "CreatedAt" TEXT NOT NULL,
    CONSTRAINT "FK_Users_Roles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "Roles" ("Id") ON DELETE RESTRICT
);

CREATE UNIQUE INDEX "IX_Users_Email" ON "Users" ("Email");
CREATE INDEX "IX_Users_RoleId" ON "Users" ("RoleId");

CREATE TABLE "Brands" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Brands" PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "Country" TEXT NOT NULL,
    "LogoUrl" TEXT NULL
);

CREATE TABLE "Features" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Features" PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "Description" TEXT NULL,
    "Category" TEXT NOT NULL
);

CREATE TABLE "Cars" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Cars" PRIMARY KEY,
    "BrandId" TEXT NOT NULL,
    "Model" TEXT NOT NULL,
    "Year" INTEGER NOT NULL,
    "Price" TEXT NOT NULL,
    "Mileage" INTEGER NOT NULL,
    "Description" TEXT NULL,
    "ImageUrl" TEXT NULL,
    "IsAvailable" INTEGER NOT NULL,
    "CreatedAt" TEXT NOT NULL,
    CONSTRAINT "FK_Cars_Brands_BrandId" FOREIGN KEY ("BrandId") REFERENCES "Brands" ("Id") ON DELETE RESTRICT
);

CREATE INDEX "IX_Cars_BrandId" ON "Cars" ("BrandId");

CREATE TABLE "CarFeatures" (
    "CarId" TEXT NOT NULL,
    "FeatureId" TEXT NOT NULL,
    "IsStandard" INTEGER NOT NULL,
    "AdditionalPrice" TEXT NOT NULL,
    CONSTRAINT "PK_CarFeatures" PRIMARY KEY ("CarId", "FeatureId"),
    CONSTRAINT "FK_CarFeatures_Cars_CarId" FOREIGN KEY ("CarId") REFERENCES "Cars" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_CarFeatures_Features_FeatureId" FOREIGN KEY ("FeatureId") REFERENCES "Features" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_CarFeatures_FeatureId" ON "CarFeatures" ("FeatureId");

CREATE TABLE "Orders" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Orders" PRIMARY KEY,
    "UserId" TEXT NOT NULL,
    "CarId" TEXT NOT NULL,
    "OrderDate" TEXT NOT NULL,
    "Status" TEXT NOT NULL,
    "TotalPrice" TEXT NOT NULL,
    "Notes" TEXT NULL,
    CONSTRAINT "FK_Orders_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Orders_Cars_CarId" FOREIGN KEY ("CarId") REFERENCES "Cars" ("Id") ON DELETE RESTRICT
);

CREATE INDEX "IX_Orders_UserId" ON "Orders" ("UserId");
CREATE INDEX "IX_Orders_CarId" ON "Orders" ("CarId");
