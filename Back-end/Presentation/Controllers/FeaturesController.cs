using Back_end.Application.DTOs;
using Back_end.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeaturesController : ControllerBase
{
    private readonly IFeatureService _featureService;

    public FeaturesController(IFeatureService featureService)
    {
        _featureService = featureService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<FeatureDto>>> GetAll(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] List<string>? categories = null)
    {
        var result = await _featureService.GetAllAsync(page, pageSize, categories);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FeatureDto>> GetById(Guid id)
    {
        var feature = await _featureService.GetByIdAsync(id);
        if (feature == null) return NotFound();
        return Ok(feature);
    }

    [HttpPost]
    [Authorize(Policy = "RequireManager")]
    public async Task<ActionResult<FeatureDto>> Create([FromBody] CreateFeatureDto dto)
    {
        var feature = await _featureService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = feature.Id }, feature);
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "RequireManager")]
    public async Task<ActionResult<FeatureDto>> Update(Guid id, [FromBody] UpdateFeatureDto dto)
    {
        var feature = await _featureService.UpdateAsync(id, dto);
        if (feature == null) return NotFound();
        return Ok(feature);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "RequireManager")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _featureService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
