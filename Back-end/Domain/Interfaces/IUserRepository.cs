using Back_end.Domain.Entities;

namespace Back_end.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdWithRoleAsync(Guid id);
    Task<(IEnumerable<User> Items, int TotalCount)> GetPagedWithRoleAsync(int page, int pageSize);
}
