using AutoMapper;
using Back_end.Application.DTOs;
using Back_end.Application.Interfaces;
using Back_end.Domain.Entities;
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

    public async Task<UserDto?> CreateAsync(CreateUserDto dto)
    {
        var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
        if (existingUser != null) return null;

        var role = await _roleRepository.GetByIdAsync(dto.RoleId);
        if (role == null) return null;

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            RoleId = dto.RoleId,
            CreatedAt = DateTime.UtcNow
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return await GetByIdAsync(user.Id);
    }
}
