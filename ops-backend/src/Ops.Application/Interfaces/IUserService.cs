// File path: Ops.Application/Interfaces/IUserService.cs

using Ops.Application.DTOs.User;

namespace Ops.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<UserDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<UserDto> CreateAsync(
        CreateUserDto dto,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        int id,
        UpdateUserDto dto,
        CancellationToken cancellationToken = default);

    Task PatchAsync(
        int id,
        PatchUserDto dto,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);
}
