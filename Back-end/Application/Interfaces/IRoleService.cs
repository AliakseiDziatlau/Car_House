using Back_end.Application.DTOs;

namespace Back_end.Application.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAllAsync();
}
