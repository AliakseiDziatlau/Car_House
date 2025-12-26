using Back_end.Domain.Entities;
using Back_end.Domain.Interfaces;
using Back_end.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Infrastructure.Repositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context) { }

    public async Task<Role?> GetByNameAsync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(r => r.Name == name);
    }
}
