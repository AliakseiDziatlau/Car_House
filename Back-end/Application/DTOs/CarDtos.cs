namespace Back_end.Application.DTOs;

public class CarListDto
{
    public Guid Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public string BrandName { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
}

public class CarDetailDto
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal Price { get; set; }
    public int Mileage { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime CreatedAt { get; set; }
    public BrandDto Brand { get; set; } = null!;
    public ICollection<CarFeatureDto> Features { get; set; } = new List<CarFeatureDto>();
}

public class CarFeatureDto
{
    public Guid FeatureId { get; set; }
    public string FeatureName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public bool IsStandard { get; set; }
    public decimal AdditionalPrice { get; set; }
}

public class CreateCarDto
{
    public Guid BrandId { get; set; }
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal Price { get; set; }
    public int Mileage { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsAvailable { get; set; } = true;
    public ICollection<CreateCarFeatureDto> Features { get; set; } = new List<CreateCarFeatureDto>();
}

public class CreateCarFeatureDto
{
    public Guid FeatureId { get; set; }
    public bool IsStandard { get; set; } = true;
    public decimal AdditionalPrice { get; set; } = 0;
}

public class UpdateCarDto
{
    public Guid BrandId { get; set; }
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal Price { get; set; }
    public int Mileage { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsAvailable { get; set; }
    public ICollection<CreateCarFeatureDto> Features { get; set; } = new List<CreateCarFeatureDto>();
}
