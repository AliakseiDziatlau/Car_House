using Back_end.Domain.Entities;
using Back_end.Domain.Interfaces;
using Back_end.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Infrastructure.Repositories;

public class FeatureRepository : Repository<Feature>, IFeatureRepository
{
    public FeatureRepository(AppDbContext context) : base(context) { }

    public async Task<(IEnumerable<Feature> Items, int TotalCount)> GetPagedFilteredAsync(
        int page,
        int pageSize,
        List<string>? categories = null)
    {
        var query = _dbSet.AsQueryable();

        if (categories != null && categories.Count > 0)
        {
            query = query.Where(f => categories.Contains(f.Category));
        }

        var totalCount = await query.CountAsync();
        var items = await query
            .OrderBy(f => f.Category)
            .ThenBy(f => f.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }
}
