using Back_end.Domain.Entities;
using Back_end.Domain.Interfaces;
using Back_end.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Infrastructure.Repositories;

public class BrandRepository : Repository<Brand>, IBrandRepository
{
    public BrandRepository(AppDbContext context) : base(context) { }

    public async Task<Brand?> GetByIdWithCarsAsync(Guid id)
    {
        return await _dbSet
            .Include(b => b.Cars)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<(IEnumerable<Brand> Items, int TotalCount)> GetPagedFilteredAsync(
        int page,
        int pageSize,
        List<string>? countries = null)
    {
        var query = _dbSet.AsQueryable();

        if (countries != null && countries.Count > 0)
        {
            query = query.Where(b => countries.Contains(b.Country));
        }

        var totalCount = await query.CountAsync();
        var items = await query
            .OrderBy(b => b.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }
}
