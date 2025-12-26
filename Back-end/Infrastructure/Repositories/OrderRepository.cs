using Back_end.Domain.Entities;
using Back_end.Domain.Interfaces;
using Back_end.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context) { }

    public async Task<Order?> GetByIdWithDetailsAsync(Guid id)
    {
        return await _dbSet
            .Include(o => o.User)
                .ThenInclude(u => u.Role)
            .Include(o => o.Car)
                .ThenInclude(c => c.Brand)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<(IEnumerable<Order> Items, int TotalCount)> GetPagedWithDetailsAsync(int page, int pageSize, Guid? userId = null)
    {
        var query = _dbSet
            .Include(o => o.User)
            .Include(o => o.Car)
                .ThenInclude(c => c.Brand)
            .AsQueryable();

        if (userId.HasValue)
        {
            query = query.Where(o => o.UserId == userId.Value);
        }

        var totalCount = await query.CountAsync();
        var items = await query
            .OrderByDescending(o => o.OrderDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }
}
