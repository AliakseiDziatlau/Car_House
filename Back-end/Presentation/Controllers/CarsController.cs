using Back_end.Application.DTOs;
using Back_end.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<CarListDto>>> GetAll(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] List<Guid>? brandIds = null,
        [FromQuery] List<string>? countries = null,
        [FromQuery] List<Guid>? featureIds = null,
        [FromQuery] bool? isAvailable = null)
    {
        var result = await _carService.GetAllAsync(page, pageSize, brandIds, countries, featureIds, isAvailable);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CarDetailDto>> GetById(Guid id)
    {
        var car = await _carService.GetByIdAsync(id);
        if (car == null) return NotFound();
        return Ok(car);
    }

    [HttpPost]
    [Authorize(Policy = "RequireManager")]
    public async Task<ActionResult<CarDetailDto>> Create([FromBody] CreateCarDto dto)
    {
        var car = await _carService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = car.Id }, car);
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "RequireManager")]
    public async Task<ActionResult<CarDetailDto>> Update(Guid id, [FromBody] UpdateCarDto dto)
    {
        var car = await _carService.UpdateAsync(id, dto);
        if (car == null) return NotFound();
        return Ok(car);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "RequireManager")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _carService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
