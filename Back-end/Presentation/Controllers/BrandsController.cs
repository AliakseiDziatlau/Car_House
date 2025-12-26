using Back_end.Application.DTOs;
using Back_end.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<BrandDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _brandService.GetAllAsync(page, pageSize);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BrandDetailDto>> GetById(Guid id)
    {
        var brand = await _brandService.GetByIdAsync(id);
        if (brand == null) return NotFound();
        return Ok(brand);
    }

    [HttpPost]
    [Authorize(Policy = "RequireManager")]
    public async Task<ActionResult<BrandDto>> Create([FromBody] CreateBrandDto dto)
    {
        var brand = await _brandService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = brand.Id }, brand);
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "RequireManager")]
    public async Task<ActionResult<BrandDto>> Update(Guid id, [FromBody] UpdateBrandDto dto)
    {
        var brand = await _brandService.UpdateAsync(id, dto);
        if (brand == null) return NotFound();
        return Ok(brand);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "RequireManager")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _brandService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
