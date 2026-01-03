using Back_end.Application.DTOs;

namespace Back_end.Application.Interfaces;

public interface IUserService
{
    Task<PagedResult<UserDto>> GetAllAsync(int page, int pageSize);
    Task<UserDto?> GetByIdAsync(Guid id);
    Task<UserDto?> UpdateRoleAsync(Guid id, UpdateUserRoleDto dto);
    Task<UserDto?> CreateAsync(CreateUserDto dto);
}
