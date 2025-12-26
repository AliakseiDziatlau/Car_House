using Back_end.Application.DTOs;

namespace Back_end.Application.Interfaces;

public interface IOrderService
{
    Task<PagedResult<OrderListDto>> GetAllAsync(int page, int pageSize, Guid? userId = null);
    Task<OrderDetailDto?> GetByIdAsync(Guid id);
    Task<OrderDetailDto> CreateAsync(CreateOrderDto dto, Guid userId);
    Task<OrderDetailDto?> UpdateStatusAsync(Guid id, UpdateOrderStatusDto dto);
    Task<bool> DeleteAsync(Guid id);
}
