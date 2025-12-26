using System.Security.Claims;
using Back_end.Application.DTOs;
using Back_end.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<OrderListDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var userId = GetCurrentUserId();
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        Guid? filterUserId = role == "Admin" || role == "Manager" ? null : userId;
        var result = await _orderService.GetAllAsync(page, pageSize, filterUserId);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDetailDto>> GetById(Guid id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null) return NotFound();

        var userId = GetCurrentUserId();
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        if (role != "Admin" && role != "Manager" && order.UserId != userId)
            return Forbid();

        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult<OrderDetailDto>> Create([FromBody] CreateOrderDto dto)
    {
        var userId = GetCurrentUserId();
        var order = await _orderService.CreateAsync(dto, userId);
        return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
    }

    [HttpPut("{id}/status")]
    [Authorize(Policy = "RequireManager")]
    public async Task<ActionResult<OrderDetailDto>> UpdateStatus(Guid id, [FromBody] UpdateOrderStatusDto dto)
    {
        var order = await _orderService.UpdateStatusAsync(id, dto);
        if (order == null) return NotFound();
        return Ok(order);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (order == null) return NotFound();

        var userId = GetCurrentUserId();
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        if (role != "Admin" && order.UserId != userId)
            return Forbid();

        var result = await _orderService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }

    private Guid GetCurrentUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.Parse(userIdClaim!);
    }
}
