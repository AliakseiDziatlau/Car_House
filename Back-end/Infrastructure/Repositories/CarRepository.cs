using Back_end.Domain.Entities;
using Back_end.Domain.Interfaces;
using Back_end.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Infrastructure.Repositories;

public class CarRepository : Repository<Car>, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context) { }

    public async Task<Car?> GetByIdWithDetailsAsync(Guid id)
    {
        return await _dbSet
            .Include(c => c.Brand)
            .Include(c => c.CarFeatures)
                .ThenInclude(cf => cf.Feature)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<(IEnumerable<Car> Items, int TotalCount)> GetPagedWithBrandAsync(int page, int pageSize, Guid? brandId = null)
    {
        var query = _dbSet.Include(c => c.Brand).AsQueryable();

        if (brandId.HasValue)
        {
            query = query.Where(c => c.BrandId == brandId.Value);
        }

        var totalCount = await query.CountAsync();
        var items = await query
            .OrderByDescending(c => c.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }
}
