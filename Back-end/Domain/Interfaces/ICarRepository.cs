using Back_end.Domain.Entities;

namespace Back_end.Domain.Interfaces;

public interface ICarRepository : IRepository<Car>
{
    Task<Car?> GetByIdWithDetailsAsync(Guid id);
    Task<(IEnumerable<Car> Items, int TotalCount)> GetPagedWithBrandAsync(int page, int pageSize, Guid? brandId = null);
}
