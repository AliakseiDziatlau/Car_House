using Back_end.Domain.Entities;

namespace Back_end.Domain.Interfaces;

public interface IFeatureRepository : IRepository<Feature>
{
    Task<(IEnumerable<Feature> Items, int TotalCount)> GetPagedFilteredAsync(
        int page,
        int pageSize,
        List<string>? categories = null);
}
