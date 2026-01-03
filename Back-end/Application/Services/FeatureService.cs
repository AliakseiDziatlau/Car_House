using AutoMapper;
using Back_end.Application.DTOs;
using Back_end.Application.Interfaces;
using Back_end.Domain.Entities;
using Back_end.Domain.Interfaces;

namespace Back_end.Application.Services;

public class FeatureService : IFeatureService
{
    private readonly IFeatureRepository _featureRepository;
    private readonly IMapper _mapper;

    public FeatureService(IFeatureRepository featureRepository, IMapper mapper)
    {
        _featureRepository = featureRepository;
        _mapper = mapper;
    }

    public async Task<PagedResult<FeatureDto>> GetAllAsync(int page, int pageSize, List<string>? categories = null)
    {
        var (items, totalCount) = await _featureRepository.GetPagedFilteredAsync(page, pageSize, categories);
        return new PagedResult<FeatureDto>
        {
            Items = _mapper.Map<IEnumerable<FeatureDto>>(items),
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }

    public async Task<FeatureDto?> GetByIdAsync(Guid id)
    {
        var feature = await _featureRepository.GetByIdAsync(id);
        return feature == null ? null : _mapper.Map<FeatureDto>(feature);
    }

    public async Task<FeatureDto> CreateAsync(CreateFeatureDto dto)
    {
        var feature = _mapper.Map<Feature>(dto);
        feature.Id = Guid.NewGuid();
        await _featureRepository.AddAsync(feature);
        await _featureRepository.SaveChangesAsync();
        return _mapper.Map<FeatureDto>(feature);
    }

    public async Task<FeatureDto?> UpdateAsync(Guid id, UpdateFeatureDto dto)
    {
        var feature = await _featureRepository.GetByIdAsync(id);
        if (feature == null) return null;

        _mapper.Map(dto, feature);
        _featureRepository.Update(feature);
        await _featureRepository.SaveChangesAsync();
        return _mapper.Map<FeatureDto>(feature);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var feature = await _featureRepository.GetByIdAsync(id);
        if (feature == null) return false;

        _featureRepository.Delete(feature);
        await _featureRepository.SaveChangesAsync();
        return true;
    }
}
