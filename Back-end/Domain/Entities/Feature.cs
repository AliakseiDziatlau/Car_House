namespace Back_end.Domain.Entities;

public class Feature
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Category { get; set; } = string.Empty;

    public ICollection<CarFeature> CarFeatures { get; set; } = new List<CarFeature>();
}
