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

    public async Task<(IEnumerable<Car> Items, int TotalCount)> GetPagedWithBrandAsync(
        int page,
        int pageSize,
        List<Guid>? brandIds = null,
        List<string>? countries = null,
        List<Guid>? featureIds = null,
        bool? isAvailable = null)
    {
        var query = _dbSet.Include(c => c.Brand).AsQueryable();

        if (isAvailable.HasValue)
        {
            query = query.Where(c => c.IsAvailable == isAvailable.Value);
        }

        if (brandIds != null && brandIds.Count > 0)
        {
            query = query.Where(c => brandIds.Contains(c.BrandId));
        }

        if (countries != null && countries.Count > 0)
        {
            query = query.Where(c => countries.Contains(c.Brand.Country));
        }

        if (featureIds != null && featureIds.Count > 0)
        {
            query = query.Where(c => c.CarFeatures.Any(cf => featureIds.Contains(cf.FeatureId)));
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
