using Back_end.Application.DTOs;

namespace Back_end.Application.Interfaces;

public interface ICarService
{
    Task<PagedResult<CarListDto>> GetAllAsync(int page, int pageSize, Guid? brandId = null);
    Task<CarDetailDto?> GetByIdAsync(Guid id);
    Task<CarDetailDto> CreateAsync(CreateCarDto dto);
    Task<CarDetailDto?> UpdateAsync(Guid id, UpdateCarDto dto);
    Task<bool> DeleteAsync(Guid id);
}
