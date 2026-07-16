using Ops.Application.DTOs.Auth;
using Ops.Application.Interfaces;

namespace Ops.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwt;

    public AuthService(
        IUserRepository repository,
        IPasswordHasher passwordHasher,
        IJwtTokenGenerator jwt)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
        _jwt = jwt;
    }

    public async Task<LoginResponseDto> LoginAsync(
        LoginRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        var user = await _repository.GetByUserNameAsync(
            dto.UserName,
            cancellationToken);

        if (user == null)
            throw new UnauthorizedAccessException("Invalid username or password.");

        bool valid = _passwordHasher.VerifyPassword(
            user.PasswordHash,
            dto.Password);

        if (!valid)
            throw new UnauthorizedAccessException("Invalid username or password.");

        var token = _jwt.GenerateToken(user);

        return new LoginResponseDto
        {
            UserId = user.Id,
            UserName = user.UserName!,
            Role = user.Role.ToString(),
            Token = token,
            Expiration = DateTime.UtcNow.AddHours(1)
        };
    }
}