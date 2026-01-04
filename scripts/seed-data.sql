PRAGMA foreign_keys = ON;

DELETE FROM "CarFeatures";
DELETE FROM "Orders";
DELETE FROM "Cars";
DELETE FROM "Features";
DELETE FROM "Brands";
DELETE FROM "Users";
DELETE FROM "Roles";

INSERT INTO "Roles" ("Id", "Name") VALUES
    ('11111111-1111-1111-1111-111111111111', 'Admin'),
    ('22222222-2222-2222-2222-222222222222', 'Manager'),
    ('33333333-3333-3333-3333-333333333333', 'User');

INSERT INTO "Users" ("Id", "Email", "PasswordHash", "FirstName", "LastName", "RoleId", "CreatedAt") VALUES
    ('aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'admin@carhouse.com', '$2a$11$XtfjIo.ZQyLC7ULml/1cVu7Wm8VavvEtqHgokaQk3gi.q0bL9w.7G', 'Admin', 'User', '11111111-1111-1111-1111-111111111111', '2025-01-01 00:00:00');

INSERT INTO "Brands" ("Id", "Name", "Country", "LogoUrl") VALUES
    ('B1111111-1111-1111-1111-111111111111', 'Toyota', 'Japan', 'https://upload.wikimedia.org/wikipedia/commons/e/e7/Toyota.svg'),
    ('B2222222-2222-2222-2222-222222222222', 'Honda', 'Japan', 'https://upload.wikimedia.org/wikipedia/commons/7/76/Honda_logo.svg'),
    ('B3333333-3333-3333-3333-333333333333', 'Ford', 'USA', 'https://upload.wikimedia.org/wikipedia/commons/a/a0/Ford_Motor_Company_Logo.svg'),
    ('B4444444-4444-4444-4444-444444444444', 'BMW', 'Germany', 'https://upload.wikimedia.org/wikipedia/commons/4/44/BMW.svg'),
    ('B5555555-5555-5555-5555-555555555555', 'Mercedes-Benz', 'Germany', 'https://upload.wikimedia.org/wikipedia/commons/9/9e/Mercedes-Benz_Logo_2010.svg'),
    ('B6666666-6666-6666-6666-666666666666', 'Audi', 'Germany', 'https://upload.wikimedia.org/wikipedia/commons/9/92/Audi-Logo_2016.svg'),
    ('B7777777-7777-7777-7777-777777777777', 'Volkswagen', 'Germany', 'https://upload.wikimedia.org/wikipedia/commons/6/6d/Volkswagen_logo_2019.svg'),
    ('B8888888-8888-8888-8888-888888888888', 'Chevrolet', 'USA', 'https://upload.wikimedia.org/wikipedia/commons/1/1e/Chevrolet-logo.png'),
    ('B9999999-9999-9999-9999-999999999999', 'Nissan', 'Japan', 'https://upload.wikimedia.org/wikipedia/commons/2/23/Nissan_2020_logo.svg'),
    ('BAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA', 'Hyundai', 'South Korea', 'https://upload.wikimedia.org/wikipedia/commons/4/44/Hyundai_Motor_Company_logo.svg');

INSERT INTO "Features" ("Id", "Name", "Category", "Description") VALUES
    -- Safety
    ('F1111111-1111-1111-1111-111111111111', 'ABS', 'Safety', 'Anti-lock Braking System prevents wheel lockup during braking'),
    ('F2222222-2222-2222-2222-222222222222', 'Airbags', 'Safety', 'Front and side airbags for driver and passenger protection'),
    ('F3333333-3333-3333-3333-333333333333', 'Blind Spot Monitor', 'Safety', 'Alerts driver to vehicles in blind spots'),
    -- Comfort
    ('F4444444-4444-4444-4444-444444444444', 'Leather Seats', 'Comfort', 'Premium leather upholstery'),
    ('F5555555-5555-5555-5555-555555555555', 'Sunroof', 'Comfort', 'Panoramic glass sunroof'),
    ('F6666666-6666-6666-6666-666666666666', 'Heated Seats', 'Comfort', 'Front heated seats for cold weather comfort'),
    -- Technology
    ('F7777777-7777-7777-7777-777777777777', 'Navigation System', 'Technology', 'Built-in GPS navigation with real-time traffic'),
    ('F8888888-8888-8888-8888-888888888888', 'Bluetooth', 'Technology', 'Wireless phone and audio connectivity'),
    ('F9999999-9999-9999-9999-999999999999', 'Backup Camera', 'Technology', 'Rear-view camera for safe reversing'),
    -- Performance
    ('FAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA', 'Turbo Engine', 'Performance', 'Turbocharged engine for enhanced power'),
    ('FBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB', 'Sport Suspension', 'Performance', 'Performance-tuned suspension system'),
    ('FCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCCCC', 'All-Wheel Drive', 'Performance', 'AWD system for improved traction');

INSERT INTO "Cars" ("Id", "BrandId", "Model", "Year", "Price", "Mileage", "Description", "ImageUrl", "IsAvailable", "CreatedAt") VALUES
    ('C1111111-1111-1111-1111-111111111111', 'B1111111-1111-1111-1111-111111111111', 'Camry', 2024, '28500.0', 0, 'Reliable midsize sedan with excellent fuel economy', 'https://upload.wikimedia.org/wikipedia/commons/a/ad/2024_Toyota_Camry_HEV_Premium_Luxury.jpg', 1, '2025-01-01 00:00:00'),
    ('C2222222-2222-2222-2222-222222222222', 'B2222222-2222-2222-2222-222222222222', 'Civic', 2024, '24500.0', 0, 'Compact car with sporty handling and great reliability', 'https://upload.wikimedia.org/wikipedia/commons/b/b5/2022_Honda_Civic_Touring_in_Lunar_Silver_Metallic%2C_Front_Left%2C_05-10-2022.jpg', 1, '2025-01-01 00:00:00'),
    ('C3333333-3333-3333-3333-333333333333', 'B3333333-3333-3333-3333-333333333333', 'Mustang GT', 2024, '42000.0', 5000, 'Iconic American muscle car with V8 power', 'https://upload.wikimedia.org/wikipedia/commons/9/97/2024_Ford_Mustang_2.3_EcoBoost_in_Race_Red%2C_front_left%2C_06-26-2024.jpg', 1, '2025-01-01 00:00:00'),
    ('C4444444-4444-4444-4444-444444444444', 'B4444444-4444-4444-4444-444444444444', '3 Series', 2024, '46000.0', 0, 'Luxury sport sedan with dynamic performance', 'https://upload.wikimedia.org/wikipedia/commons/e/e4/2019_BMW_318d_SE_Automatic_2.0_Front.jpg', 1, '2025-01-01 00:00:00'),
    ('C5555555-5555-5555-5555-555555555555', 'B5555555-5555-5555-5555-555555555555', 'C-Class', 2024, '48000.0', 0, 'Elegant luxury sedan with advanced technology', 'https://upload.wikimedia.org/wikipedia/commons/f/fc/2022_Mercedes-Benz_C-Class_C220d_Avantgarde.jpg', 1, '2025-01-01 00:00:00'),
    ('C6666666-6666-6666-6666-666666666666', 'B6666666-6666-6666-6666-666666666666', 'A4', 2024, '44000.0', 0, 'Premium compact sedan with Quattro AWD', 'https://upload.wikimedia.org/wikipedia/commons/9/9b/Audi_A4_B9_Limousine_3.0_TDI_quattro.JPG', 1, '2025-01-01 00:00:00'),
    ('C7777777-7777-7777-7777-777777777777', 'B7777777-7777-7777-7777-777777777777', 'Golf GTI', 2024, '32000.0', 0, 'Hot hatch with turbocharged performance', 'https://upload.wikimedia.org/wikipedia/commons/0/04/2020_Volkswagen_Golf_GTi_TSi_S-A_2.0_Front.jpg', 1, '2025-01-01 00:00:00'),
    ('C8888888-8888-8888-8888-888888888888', 'B8888888-8888-8888-8888-888888888888', 'Camaro SS', 2024, '45000.0', 3000, 'American sports car with aggressive styling', 'https://upload.wikimedia.org/wikipedia/commons/e/e7/18_Chevrolet_Camaro_SS.jpg', 1, '2025-01-01 00:00:00'),
    ('C9999999-9999-9999-9999-999999999999', 'B9999999-9999-9999-9999-999999999999', 'Altima', 2024, '27000.0', 0, 'Comfortable midsize sedan with AWD option', 'https://upload.wikimedia.org/wikipedia/commons/f/fa/20_Nissan_Altima_2.5_S.jpg', 1, '2025-01-01 00:00:00'),
    ('CAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA', 'BAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA', 'Sonata', 2024, '26500.0', 0, 'Stylish midsize sedan with excellent value', 'https://upload.wikimedia.org/wikipedia/commons/b/bd/0_Hyundai_Sonata_%28DN8%29_1.jpg', 1, '2025-01-01 00:00:00');

-- Toyota Camry features
INSERT INTO "CarFeatures" ("CarId", "FeatureId", "IsStandard", "AdditionalPrice") VALUES
    ('C1111111-1111-1111-1111-111111111111', 'F1111111-1111-1111-1111-111111111111', 1, '0.0'),
    ('C1111111-1111-1111-1111-111111111111', 'F2222222-2222-2222-2222-222222222222', 1, '0.0'),
    ('C1111111-1111-1111-1111-111111111111', 'F8888888-8888-8888-8888-888888888888', 1, '0.0'),
    ('C1111111-1111-1111-1111-111111111111', 'F9999999-9999-9999-9999-999999999999', 1, '0.0');

-- Honda Civic features
INSERT INTO "CarFeatures" ("CarId", "FeatureId", "IsStandard", "AdditionalPrice") VALUES
    ('C2222222-2222-2222-2222-222222222222', 'F1111111-1111-1111-1111-111111111111', 1, '0.0'),
    ('C2222222-2222-2222-2222-222222222222', 'F2222222-2222-2222-2222-222222222222', 1, '0.0'),
    ('C2222222-2222-2222-2222-222222222222', 'F8888888-8888-8888-8888-888888888888', 1, '0.0');

-- Ford Mustang GT features
INSERT INTO "CarFeatures" ("CarId", "FeatureId", "IsStandard", "AdditionalPrice") VALUES
    ('C3333333-3333-3333-3333-333333333333', 'F1111111-1111-1111-1111-111111111111', 1, '0.0'),
    ('C3333333-3333-3333-3333-333333333333', 'F2222222-2222-2222-2222-222222222222', 1, '0.0'),
    ('C3333333-3333-3333-3333-333333333333', 'FBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB', 1, '0.0'),
    ('C3333333-3333-3333-3333-333333333333', 'F4444444-4444-4444-4444-444444444444', 0, '1500.0');

-- BMW 3 Series features
INSERT INTO "CarFeatures" ("CarId", "FeatureId", "IsStandard", "AdditionalPrice") VALUES
    ('C4444444-4444-4444-4444-444444444444', 'F1111111-1111-1111-1111-111111111111', 1, '0.0'),
    ('C4444444-4444-4444-4444-444444444444', 'F2222222-2222-2222-2222-222222222222', 1, '0.0'),
    ('C4444444-4444-4444-4444-444444444444', 'F4444444-4444-4444-4444-444444444444', 1, '0.0'),
    ('C4444444-4444-4444-4444-444444444444', 'F7777777-7777-7777-7777-777777777777', 1, '0.0'),
    ('C4444444-4444-4444-4444-444444444444', 'F5555555-5555-5555-5555-555555555555', 0, '1200.0');

-- Mercedes C-Class features
INSERT INTO "CarFeatures" ("CarId", "FeatureId", "IsStandard", "AdditionalPrice") VALUES
    ('C5555555-5555-5555-5555-555555555555', 'F1111111-1111-1111-1111-111111111111', 1, '0.0'),
    ('C5555555-5555-5555-5555-555555555555', 'F2222222-2222-2222-2222-222222222222', 1, '0.0'),
    ('C5555555-5555-5555-5555-555555555555', 'F4444444-4444-4444-4444-444444444444', 1, '0.0'),
    ('C5555555-5555-5555-5555-555555555555', 'F7777777-7777-7777-7777-777777777777', 1, '0.0'),
    ('C5555555-5555-5555-5555-555555555555', 'F6666666-6666-6666-6666-666666666666', 1, '0.0'),
    ('C5555555-5555-5555-5555-555555555555', 'F3333333-3333-3333-3333-333333333333', 1, '0.0');

-- Audi A4 features
INSERT INTO "CarFeatures" ("CarId", "FeatureId", "IsStandard", "AdditionalPrice") VALUES
    ('C6666666-6666-6666-6666-666666666666', 'F1111111-1111-1111-1111-111111111111', 1, '0.0'),
    ('C6666666-6666-6666-6666-666666666666', 'F2222222-2222-2222-2222-222222222222', 1, '0.0'),
    ('C6666666-6666-6666-6666-666666666666', 'FCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCCCC', 1, '0.0'),
    ('C6666666-6666-6666-6666-666666666666', 'F4444444-4444-4444-4444-444444444444', 1, '0.0'),
    ('C6666666-6666-6666-6666-666666666666', 'F7777777-7777-7777-7777-777777777777', 1, '0.0');

-- VW Golf GTI features
INSERT INTO "CarFeatures" ("CarId", "FeatureId", "IsStandard", "AdditionalPrice") VALUES
    ('C7777777-7777-7777-7777-777777777777', 'F1111111-1111-1111-1111-111111111111', 1, '0.0'),
    ('C7777777-7777-7777-7777-777777777777', 'F2222222-2222-2222-2222-222222222222', 1, '0.0'),
    ('C7777777-7777-7777-7777-777777777777', 'FAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA', 1, '0.0'),
    ('C7777777-7777-7777-7777-777777777777', 'FBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB', 1, '0.0');

-- Chevrolet Camaro SS features
INSERT INTO "CarFeatures" ("CarId", "FeatureId", "IsStandard", "AdditionalPrice") VALUES
    ('C8888888-8888-8888-8888-888888888888', 'F1111111-1111-1111-1111-111111111111', 1, '0.0'),
    ('C8888888-8888-8888-8888-888888888888', 'F2222222-2222-2222-2222-222222222222', 1, '0.0'),
    ('C8888888-8888-8888-8888-888888888888', 'FBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB', 1, '0.0'),
    ('C8888888-8888-8888-8888-888888888888', 'F4444444-4444-4444-4444-444444444444', 1, '0.0');

-- Nissan Altima features
INSERT INTO "CarFeatures" ("CarId", "FeatureId", "IsStandard", "AdditionalPrice") VALUES
    ('C9999999-9999-9999-9999-999999999999', 'F1111111-1111-1111-1111-111111111111', 1, '0.0'),
    ('C9999999-9999-9999-9999-999999999999', 'F2222222-2222-2222-2222-222222222222', 1, '0.0'),
    ('C9999999-9999-9999-9999-999999999999', 'F8888888-8888-8888-8888-888888888888', 1, '0.0'),
    ('C9999999-9999-9999-9999-999999999999', 'FCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCCCC', 0, '2000.0');

-- Hyundai Sonata features
INSERT INTO "CarFeatures" ("CarId", "FeatureId", "IsStandard", "AdditionalPrice") VALUES
    ('CAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA', 'F1111111-1111-1111-1111-111111111111', 1, '0.0'),
    ('CAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA', 'F2222222-2222-2222-2222-222222222222', 1, '0.0'),
    ('CAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA', 'F8888888-8888-8888-8888-888888888888', 1, '0.0'),
    ('CAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA', 'F9999999-9999-9999-9999-999999999999', 1, '0.0'),
    ('CAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA', 'F3333333-3333-3333-3333-333333333333', 1, '0.0');
