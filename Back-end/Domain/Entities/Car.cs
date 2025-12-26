namespace Back_end.Domain.Entities;

public class Car
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal Price { get; set; }
    public int Mileage { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsAvailable { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Brand Brand { get; set; } = null!;
    public ICollection<CarFeature> CarFeatures { get; set; } = new List<CarFeature>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
