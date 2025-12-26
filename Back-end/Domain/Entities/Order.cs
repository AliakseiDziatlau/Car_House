namespace Back_end.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CarId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Pending";
    public decimal TotalPrice { get; set; }
    public string? Notes { get; set; }

    public User User { get; set; } = null!;
    public Car Car { get; set; } = null!;
}
