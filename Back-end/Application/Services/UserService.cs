using AutoMapper;
using Back_end.Application.DTOs;
using Back_end.Application.Interfaces;
using Back_end.Domain.Interfaces;

namespace Back_end.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<PagedResult<UserDto>> GetAllAsync(int page, int pageSize)
    {
        var (items, totalCount) = await _userRepository.GetPagedWithRoleAsync(page, pageSize);
        return new PagedResult<UserDto>
        {
            Items = _mapper.Map<IEnumerable<UserDto>>(items),
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }

    public async Task<UserDto?> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdWithRoleAsync(id);
        return user == null ? null : _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto?> UpdateRoleAsync(Guid id, UpdateUserRoleDto dto)
    {
        var user = await _userRepository.GetByIdWithRoleAsync(id);
        if (user == null) return null;

        var role = await _roleRepository.GetByIdAsync(dto.RoleId);
        if (role == null) return null;

        user.RoleId = dto.RoleId;
        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync();

        return await GetByIdAsync(id);
    }
}
