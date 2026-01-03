using AutoMapper;
using Back_end.Application.DTOs;
using Back_end.Application.Interfaces;
using Back_end.Domain.Entities;
using Back_end.Domain.Interfaces;

namespace Back_end.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, ICarRepository carRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<PagedResult<OrderListDto>> GetAllAsync(int page, int pageSize, Guid? userId = null)
    {
        var (items, totalCount) = await _orderRepository.GetPagedWithDetailsAsync(page, pageSize, userId);
        return new PagedResult<OrderListDto>
        {
            Items = _mapper.Map<IEnumerable<OrderListDto>>(items),
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }

    public async Task<OrderDetailDto?> GetByIdAsync(Guid id)
    {
        var order = await _orderRepository.GetByIdWithDetailsAsync(id);
        return order == null ? null : _mapper.Map<OrderDetailDto>(order);
    }

    public async Task<OrderDetailDto> CreateAsync(CreateOrderDto dto, Guid userId)
    {
        var car = await _carRepository.GetByIdAsync(dto.CarId);
        if (car == null) throw new ArgumentException("Car not found");

        var order = new Order
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            CarId = dto.CarId,
            OrderDate = DateTime.UtcNow,
            Status = "Pending",
            TotalPrice = car.Price,
            Notes = dto.Notes
        };

        await _orderRepository.AddAsync(order);
        await _orderRepository.SaveChangesAsync();

        return (await GetByIdAsync(order.Id))!;
    }

    public async Task<OrderDetailDto?> UpdateStatusAsync(Guid id, UpdateOrderStatusDto dto)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order == null) return null;

        order.Status = dto.Status;
        _orderRepository.Update(order);

        var car = await _carRepository.GetByIdAsync(order.CarId);
        if (car != null)
        {
            if (dto.Status == "Completed")
            {
                car.IsAvailable = false;
                _carRepository.Update(car);
            }
            else if (dto.Status == "Cancelled")
            {
                car.IsAvailable = true;
                _carRepository.Update(car);
            }
        }

        await _orderRepository.SaveChangesAsync();

        return await GetByIdAsync(id);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order == null) return false;

        _orderRepository.Delete(order);
        await _orderRepository.SaveChangesAsync();
        return true;
    }
}
