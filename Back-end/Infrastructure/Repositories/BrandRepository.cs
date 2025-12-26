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
}
