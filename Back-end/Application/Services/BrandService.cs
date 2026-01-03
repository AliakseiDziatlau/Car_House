using AutoMapper;
using Back_end.Application.DTOs;
using Back_end.Application.Interfaces;
using Back_end.Domain.Entities;
using Back_end.Domain.Interfaces;

namespace Back_end.Application.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public BrandService(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<PagedResult<BrandDto>> GetAllAsync(int page, int pageSize, List<string>? countries = null)
    {
        var (items, totalCount) = await _brandRepository.GetPagedFilteredAsync(page, pageSize, countries);
        return new PagedResult<BrandDto>
        {
            Items = _mapper.Map<IEnumerable<BrandDto>>(items),
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }

    public async Task<BrandDetailDto?> GetByIdAsync(Guid id)
    {
        var brand = await _brandRepository.GetByIdWithCarsAsync(id);
        return brand == null ? null : _mapper.Map<BrandDetailDto>(brand);
    }

    public async Task<BrandDto> CreateAsync(CreateBrandDto dto)
    {
        var brand = _mapper.Map<Brand>(dto);
        brand.Id = Guid.NewGuid();
        await _brandRepository.AddAsync(brand);
        await _brandRepository.SaveChangesAsync();
        return _mapper.Map<BrandDto>(brand);
    }

    public async Task<BrandDto?> UpdateAsync(Guid id, UpdateBrandDto dto)
    {
        var brand = await _brandRepository.GetByIdAsync(id);
        if (brand == null) return null;

        _mapper.Map(dto, brand);
        _brandRepository.Update(brand);
        await _brandRepository.SaveChangesAsync();
        return _mapper.Map<BrandDto>(brand);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var brand = await _brandRepository.GetByIdAsync(id);
        if (brand == null) return false;

        _brandRepository.Delete(brand);
        await _brandRepository.SaveChangesAsync();
        return true;
    }
}
