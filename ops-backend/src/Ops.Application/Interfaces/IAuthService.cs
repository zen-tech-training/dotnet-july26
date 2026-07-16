using Ops.Application.DTOs.Auth;

namespace Ops.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(
        LoginRequestDto dto,
        CancellationToken cancellationToken = default);
}