using Back_end.Domain.Entities;

namespace Back_end.Domain.Interfaces;

public interface ICarRepository : IRepository<Car>
{
    Task<Car?> GetByIdWithDetailsAsync(Guid id);
    Task<(IEnumerable<Car> Items, int TotalCount)> GetPagedWithBrandAsync(
        int page,
        int pageSize,
        List<Guid>? brandIds = null,
        List<string>? countries = null,
        List<Guid>? featureIds = null,
        bool? isAvailable = null);
}
