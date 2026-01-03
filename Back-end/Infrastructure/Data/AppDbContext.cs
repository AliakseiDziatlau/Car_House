using Back_end.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Feature> Features => Set<Feature>();
    public DbSet<CarFeature> CarFeatures => Set<CarFeature>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Country).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LogoUrl).HasMaxLength(500);
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Model).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Price).HasPrecision(18, 2);
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
            entity.HasOne(e => e.Brand)
                .WithMany(b => b.Cars)
                .HasForeignKey(e => e.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Feature>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Category).IsRequired().HasMaxLength(50);
        });

        modelBuilder.Entity<CarFeature>(entity =>
        {
            entity.HasKey(e => new { e.CarId, e.FeatureId });
            entity.Property(e => e.AdditionalPrice).HasPrecision(18, 2);
            entity.HasOne(e => e.Car)
                .WithMany(c => c.CarFeatures)
                .HasForeignKey(e => e.CarId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Feature)
                .WithMany(f => f.CarFeatures)
                .HasForeignKey(e => e.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.Name).IsUnique();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(256);
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasOne(e => e.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
            entity.Property(e => e.TotalPrice).HasPrecision(18, 2);
            entity.Property(e => e.Notes).HasMaxLength(1000);
            entity.HasOne(e => e.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Car)
                .WithMany(c => c.Orders)
                .HasForeignKey(e => e.CarId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        var adminRoleId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var managerRoleId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var userRoleId = Guid.Parse("33333333-3333-3333-3333-333333333333");

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = adminRoleId, Name = "Admin" },
            new Role { Id = managerRoleId, Name = "Manager" },
            new Role { Id = userRoleId, Name = "User" }
        );

        var adminId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = adminId,
                Email = "admin@carhouse.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                FirstName = "Admin",
                LastName = "User",
                RoleId = adminRoleId,
                CreatedAt = DateTime.UtcNow
            }
        );

        modelBuilder.Entity<Brand>().HasData(
            new Brand { Id = Guid.Parse("b1111111-1111-1111-1111-111111111111"), Name = "Toyota", Country = "Japan", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/e/e7/Toyota.svg" },
            new Brand { Id = Guid.Parse("b2222222-2222-2222-2222-222222222222"), Name = "Honda", Country = "Japan", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/7/76/Honda_logo.svg" },
            new Brand { Id = Guid.Parse("b3333333-3333-3333-3333-333333333333"), Name = "Ford", Country = "USA", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a0/Ford_Motor_Company_Logo.svg" },
            new Brand { Id = Guid.Parse("b4444444-4444-4444-4444-444444444444"), Name = "BMW", Country = "Germany", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/4/44/BMW.svg" },
            new Brand { Id = Guid.Parse("b5555555-5555-5555-5555-555555555555"), Name = "Mercedes-Benz", Country = "Germany", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/9/90/Mercedes-Benz_Logo_2010.svg" },
            new Brand { Id = Guid.Parse("b6666666-6666-6666-6666-666666666666"), Name = "Audi", Country = "Germany", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/9/92/Audi-Logo_2016.svg" },
            new Brand { Id = Guid.Parse("b7777777-7777-7777-7777-777777777777"), Name = "Volkswagen", Country = "Germany", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/6/6d/Volkswagen_logo_2019.svg" },
            new Brand { Id = Guid.Parse("b8888888-8888-8888-8888-888888888888"), Name = "Chevrolet", Country = "USA", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/1/1f/Logo_Chevrolet.svg" },
            new Brand { Id = Guid.Parse("b9999999-9999-9999-9999-999999999999"), Name = "Nissan", Country = "Japan", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/2/23/Nissan_2020_logo.svg" },
            new Brand { Id = Guid.Parse("baaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), Name = "Hyundai", Country = "South Korea", LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/4/44/Hyundai_Motor_Company_logo.svg" }
        );

        var absId = Guid.Parse("f1111111-1111-1111-1111-111111111111");
        var airbagsId = Guid.Parse("f2222222-2222-2222-2222-222222222222");
        var blindSpotId = Guid.Parse("f3333333-3333-3333-3333-333333333333");
        var leatherSeatsId = Guid.Parse("f4444444-4444-4444-4444-444444444444");
        var sunroofId = Guid.Parse("f5555555-5555-5555-5555-555555555555");
        var heatedSeatsId = Guid.Parse("f6666666-6666-6666-6666-666666666666");
        var navigationId = Guid.Parse("f7777777-7777-7777-7777-777777777777");
        var bluetoothId = Guid.Parse("f8888888-8888-8888-8888-888888888888");
        var backupCameraId = Guid.Parse("f9999999-9999-9999-9999-999999999999");
        var turboEngineId = Guid.Parse("faaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        var sportSuspensionId = Guid.Parse("fbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        var awdId = Guid.Parse("fccccccc-cccc-cccc-cccc-cccccccccccc");

        modelBuilder.Entity<Feature>().HasData(
            new Feature { Id = absId, Name = "ABS", Category = "Safety", Description = "Anti-lock Braking System prevents wheel lockup during braking" },
            new Feature { Id = airbagsId, Name = "Airbags", Category = "Safety", Description = "Front and side airbags for driver and passenger protection" },
            new Feature { Id = blindSpotId, Name = "Blind Spot Monitor", Category = "Safety", Description = "Alerts driver to vehicles in blind spots" },
            new Feature { Id = leatherSeatsId, Name = "Leather Seats", Category = "Comfort", Description = "Premium leather upholstery" },
            new Feature { Id = sunroofId, Name = "Sunroof", Category = "Comfort", Description = "Panoramic glass sunroof" },
            new Feature { Id = heatedSeatsId, Name = "Heated Seats", Category = "Comfort", Description = "Front heated seats for cold weather comfort" },
            new Feature { Id = navigationId, Name = "Navigation System", Category = "Technology", Description = "Built-in GPS navigation with real-time traffic" },
            new Feature { Id = bluetoothId, Name = "Bluetooth", Category = "Technology", Description = "Wireless phone and audio connectivity" },
            new Feature { Id = backupCameraId, Name = "Backup Camera", Category = "Technology", Description = "Rear-view camera for safe reversing" },
            new Feature { Id = turboEngineId, Name = "Turbo Engine", Category = "Performance", Description = "Turbocharged engine for enhanced power" },
            new Feature { Id = sportSuspensionId, Name = "Sport Suspension", Category = "Performance", Description = "Performance-tuned suspension system" },
            new Feature { Id = awdId, Name = "All-Wheel Drive", Category = "Performance", Description = "AWD system for improved traction" }
        );

        var toyotaBrandId = Guid.Parse("b1111111-1111-1111-1111-111111111111");
        var hondaBrandId = Guid.Parse("b2222222-2222-2222-2222-222222222222");
        var fordBrandId = Guid.Parse("b3333333-3333-3333-3333-333333333333");
        var bmwBrandId = Guid.Parse("b4444444-4444-4444-4444-444444444444");
        var mercedesBrandId = Guid.Parse("b5555555-5555-5555-5555-555555555555");
        var audiBrandId = Guid.Parse("b6666666-6666-6666-6666-666666666666");
        var vwBrandId = Guid.Parse("b7777777-7777-7777-7777-777777777777");
        var chevroletBrandId = Guid.Parse("b8888888-8888-8888-8888-888888888888");
        var nissanBrandId = Guid.Parse("b9999999-9999-9999-9999-999999999999");
        var hyundaiBrandId = Guid.Parse("baaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

        var camryId = Guid.Parse("c1111111-1111-1111-1111-111111111111");
        var civicId = Guid.Parse("c2222222-2222-2222-2222-222222222222");
        var mustangId = Guid.Parse("c3333333-3333-3333-3333-333333333333");
        var bmw3Id = Guid.Parse("c4444444-4444-4444-4444-444444444444");
        var cClassId = Guid.Parse("c5555555-5555-5555-5555-555555555555");
        var a4Id = Guid.Parse("c6666666-6666-6666-6666-666666666666");
        var golfId = Guid.Parse("c7777777-7777-7777-7777-777777777777");
        var camaroId = Guid.Parse("c8888888-8888-8888-8888-888888888888");
        var altimaId = Guid.Parse("c9999999-9999-9999-9999-999999999999");
        var sonataId = Guid.Parse("caaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

        var seedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        modelBuilder.Entity<Car>().HasData(
            new Car { Id = camryId, BrandId = toyotaBrandId, Model = "Camry", Year = 2024, Price = 28500, Mileage = 0, Description = "Reliable midsize sedan with excellent fuel economy", IsAvailable = true, CreatedAt = seedDate },
            new Car { Id = civicId, BrandId = hondaBrandId, Model = "Civic", Year = 2024, Price = 24500, Mileage = 0, Description = "Compact car with sporty handling and great reliability", IsAvailable = true, CreatedAt = seedDate },
            new Car { Id = mustangId, BrandId = fordBrandId, Model = "Mustang GT", Year = 2024, Price = 42000, Mileage = 5000, Description = "Iconic American muscle car with V8 power", IsAvailable = true, CreatedAt = seedDate },
            new Car { Id = bmw3Id, BrandId = bmwBrandId, Model = "3 Series", Year = 2024, Price = 46000, Mileage = 0, Description = "Luxury sport sedan with dynamic performance", IsAvailable = true, CreatedAt = seedDate },
            new Car { Id = cClassId, BrandId = mercedesBrandId, Model = "C-Class", Year = 2024, Price = 48000, Mileage = 0, Description = "Elegant luxury sedan with advanced technology", IsAvailable = true, CreatedAt = seedDate },
            new Car { Id = a4Id, BrandId = audiBrandId, Model = "A4", Year = 2024, Price = 44000, Mileage = 0, Description = "Premium compact sedan with Quattro AWD", IsAvailable = true, CreatedAt = seedDate },
            new Car { Id = golfId, BrandId = vwBrandId, Model = "Golf GTI", Year = 2024, Price = 32000, Mileage = 0, Description = "Hot hatch with turbocharged performance", IsAvailable = true, CreatedAt = seedDate },
            new Car { Id = camaroId, BrandId = chevroletBrandId, Model = "Camaro SS", Year = 2024, Price = 45000, Mileage = 3000, Description = "American sports car with aggressive styling", IsAvailable = true, CreatedAt = seedDate },
            new Car { Id = altimaId, BrandId = nissanBrandId, Model = "Altima", Year = 2024, Price = 27000, Mileage = 0, Description = "Comfortable midsize sedan with AWD option", IsAvailable = true, CreatedAt = seedDate },
            new Car { Id = sonataId, BrandId = hyundaiBrandId, Model = "Sonata", Year = 2024, Price = 26500, Mileage = 0, Description = "Stylish midsize sedan with excellent value", IsAvailable = true, CreatedAt = seedDate }
        );

        modelBuilder.Entity<CarFeature>().HasData(
            new CarFeature { CarId = camryId, FeatureId = absId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = camryId, FeatureId = airbagsId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = camryId, FeatureId = bluetoothId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = camryId, FeatureId = backupCameraId, IsStandard = true, AdditionalPrice = 0 },

            new CarFeature { CarId = civicId, FeatureId = absId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = civicId, FeatureId = airbagsId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = civicId, FeatureId = bluetoothId, IsStandard = true, AdditionalPrice = 0 },

            new CarFeature { CarId = mustangId, FeatureId = absId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = mustangId, FeatureId = airbagsId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = mustangId, FeatureId = sportSuspensionId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = mustangId, FeatureId = leatherSeatsId, IsStandard = false, AdditionalPrice = 1500 },

            new CarFeature { CarId = bmw3Id, FeatureId = absId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = bmw3Id, FeatureId = airbagsId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = bmw3Id, FeatureId = leatherSeatsId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = bmw3Id, FeatureId = navigationId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = bmw3Id, FeatureId = sunroofId, IsStandard = false, AdditionalPrice = 1200 },

            new CarFeature { CarId = cClassId, FeatureId = absId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = cClassId, FeatureId = airbagsId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = cClassId, FeatureId = leatherSeatsId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = cClassId, FeatureId = navigationId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = cClassId, FeatureId = heatedSeatsId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = cClassId, FeatureId = blindSpotId, IsStandard = true, AdditionalPrice = 0 },

            new CarFeature { CarId = a4Id, FeatureId = absId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = a4Id, FeatureId = airbagsId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = a4Id, FeatureId = awdId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = a4Id, FeatureId = leatherSeatsId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = a4Id, FeatureId = navigationId, IsStandard = true, AdditionalPrice = 0 },

            new CarFeature { CarId = golfId, FeatureId = absId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = golfId, FeatureId = airbagsId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = golfId, FeatureId = turboEngineId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = golfId, FeatureId = sportSuspensionId, IsStandard = true, AdditionalPrice = 0 },

            new CarFeature { CarId = camaroId, FeatureId = absId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = camaroId, FeatureId = airbagsId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = camaroId, FeatureId = sportSuspensionId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = camaroId, FeatureId = leatherSeatsId, IsStandard = true, AdditionalPrice = 0 },

            new CarFeature { CarId = altimaId, FeatureId = absId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = altimaId, FeatureId = airbagsId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = altimaId, FeatureId = bluetoothId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = altimaId, FeatureId = awdId, IsStandard = false, AdditionalPrice = 2000 },

            new CarFeature { CarId = sonataId, FeatureId = absId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = sonataId, FeatureId = airbagsId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = sonataId, FeatureId = bluetoothId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = sonataId, FeatureId = backupCameraId, IsStandard = true, AdditionalPrice = 0 },
            new CarFeature { CarId = sonataId, FeatureId = blindSpotId, IsStandard = true, AdditionalPrice = 0 }
        );
    }
}
