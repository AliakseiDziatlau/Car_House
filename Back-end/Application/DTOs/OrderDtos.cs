namespace Back_end.Application.DTOs;

public class OrderListDto
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
    public string CarModel { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
}

public class OrderDetailDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CarId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
    public string? Notes { get; set; }
    public UserDto User { get; set; } = null!;
    public CarListDto Car { get; set; } = null!;
}

public class CreateOrderDto
{
    public Guid CarId { get; set; }
    public string? Notes { get; set; }
}

public class UpdateOrderStatusDto
{
    public string Status { get; set; } = string.Empty;
}
