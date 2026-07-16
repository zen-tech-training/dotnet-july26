using Ops.Application.Interfaces;
using Ops.Domain.Entities;

namespace Ops.Infrastructure.Security;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(User user)
    {
        throw new NotImplementedException();
    }
}