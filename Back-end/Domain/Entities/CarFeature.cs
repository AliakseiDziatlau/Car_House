namespace Back_end.Domain.Entities;

public class CarFeature
{
    public Guid CarId { get; set; }
    public Guid FeatureId { get; set; }
    public bool IsStandard { get; set; } = true;
    public decimal AdditionalPrice { get; set; } = 0;

    public Car Car { get; set; } = null!;
    public Feature Feature { get; set; } = null!;
}
