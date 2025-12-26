using Back_end.Application.DTOs;

namespace Back_end.Application.Interfaces;

public interface IBrandService
{
    Task<PagedResult<BrandDto>> GetAllAsync(int page, int pageSize);
    Task<BrandDetailDto?> GetByIdAsync(Guid id);
    Task<BrandDto> CreateAsync(CreateBrandDto dto);
    Task<BrandDto?> UpdateAsync(Guid id, UpdateBrandDto dto);
    Task<bool> DeleteAsync(Guid id);
}
