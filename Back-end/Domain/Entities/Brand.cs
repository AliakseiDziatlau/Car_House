namespace Back_end.Domain.Entities;

public class Brand
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string? LogoUrl { get; set; }

    public ICollection<Car> Cars { get; set; } = new List<Car>();
}
