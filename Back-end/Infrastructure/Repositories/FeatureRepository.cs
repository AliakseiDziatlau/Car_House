using Back_end.Domain.Entities;
using Back_end.Domain.Interfaces;
using Back_end.Infrastructure.Data;

namespace Back_end.Infrastructure.Repositories;

public class FeatureRepository : Repository<Feature>, IFeatureRepository
{
    public FeatureRepository(AppDbContext context) : base(context) { }
}
