using Ops.Domain.Entities;
namespace Ops.Application.Interfaces;
public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}