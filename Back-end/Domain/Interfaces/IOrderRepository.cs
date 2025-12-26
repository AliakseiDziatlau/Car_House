using Back_end.Domain.Entities;

namespace Back_end.Domain.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
    Task<Order?> GetByIdWithDetailsAsync(Guid id);
    Task<(IEnumerable<Order> Items, int TotalCount)> GetPagedWithDetailsAsync(int page, int pageSize, Guid? userId = null);
}
