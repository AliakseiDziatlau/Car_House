using AutoMapper;
using Back_end.Application.DTOs;
using Back_end.Application.Interfaces;
using Back_end.Domain.Entities;
using Back_end.Domain.Interfaces;

namespace Back_end.Application.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public CarService(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<PagedResult<CarListDto>> GetAllAsync(int page, int pageSize, Guid? brandId = null)
    {
        var (items, totalCount) = await _carRepository.GetPagedWithBrandAsync(page, pageSize, brandId);
        return new PagedResult<CarListDto>
        {
            Items = _mapper.Map<IEnumerable<CarListDto>>(items),
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }

    public async Task<CarDetailDto?> GetByIdAsync(Guid id)
    {
        var car = await _carRepository.GetByIdWithDetailsAsync(id);
        return car == null ? null : _mapper.Map<CarDetailDto>(car);
    }

    public async Task<CarDetailDto> CreateAsync(CreateCarDto dto)
    {
        var car = new Car
        {
            Id = Guid.NewGuid(),
            BrandId = dto.BrandId,
            Model = dto.Model,
            Year = dto.Year,
            Price = dto.Price,
            Mileage = dto.Mileage,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            IsAvailable = dto.IsAvailable,
            CreatedAt = DateTime.UtcNow
        };

        foreach (var featureDto in dto.Features)
        {
            car.CarFeatures.Add(new CarFeature
            {
                CarId = car.Id,
                FeatureId = featureDto.FeatureId,
                IsStandard = featureDto.IsStandard,
                AdditionalPrice = featureDto.AdditionalPrice
            });
        }

        await _carRepository.AddAsync(car);
        await _carRepository.SaveChangesAsync();

        return (await GetByIdAsync(car.Id))!;
    }

    public async Task<CarDetailDto?> UpdateAsync(Guid id, UpdateCarDto dto)
    {
        var car = await _carRepository.GetByIdWithDetailsAsync(id);
        if (car == null) return null;

        car.BrandId = dto.BrandId;
        car.Model = dto.Model;
        car.Year = dto.Year;
        car.Price = dto.Price;
        car.Mileage = dto.Mileage;
        car.Description = dto.Description;
        car.ImageUrl = dto.ImageUrl;
        car.IsAvailable = dto.IsAvailable;

        car.CarFeatures.Clear();
        foreach (var featureDto in dto.Features)
        {
            car.CarFeatures.Add(new CarFeature
            {
                CarId = car.Id,
                FeatureId = featureDto.FeatureId,
                IsStandard = featureDto.IsStandard,
                AdditionalPrice = featureDto.AdditionalPrice
            });
        }

        _carRepository.Update(car);
        await _carRepository.SaveChangesAsync();

        return (await GetByIdAsync(car.Id))!;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var car = await _carRepository.GetByIdAsync(id);
        if (car == null) return false;

        _carRepository.Delete(car);
        await _carRepository.SaveChangesAsync();
        return true;
    }
}
