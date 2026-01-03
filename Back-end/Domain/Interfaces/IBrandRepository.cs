using Back_end.Domain.Entities;

namespace Back_end.Domain.Interfaces;

public interface IBrandRepository : IRepository<Brand>
{
    Task<Brand?> GetByIdWithCarsAsync(Guid id);
    Task<(IEnumerable<Brand> Items, int TotalCount)> GetPagedFilteredAsync(
        int page,
        int pageSize,
        List<string>? countries = null);
}
