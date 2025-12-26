using Back_end.Application.DTOs;

namespace Back_end.Application.Interfaces;

public interface IFeatureService
{
    Task<PagedResult<FeatureDto>> GetAllAsync(int page, int pageSize);
    Task<FeatureDto?> GetByIdAsync(Guid id);
    Task<FeatureDto> CreateAsync(CreateFeatureDto dto);
    Task<FeatureDto?> UpdateAsync(Guid id, UpdateFeatureDto dto);
    Task<bool> DeleteAsync(Guid id);
}
