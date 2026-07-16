using Microsoft.AspNetCore.Identity;
using Ops.Application.Interfaces;
using Ops.Domain.Entities;

namespace Ops.Infrastructure.Security;

public class PasswordHasher : IPasswordHasher
{
    private readonly Microsoft.AspNetCore.Identity.PasswordHasher<User> _passwordHasher;

    public PasswordHasher()
    {
        _passwordHasher = new Microsoft.AspNetCore.Identity.PasswordHasher<User>();
    }

    public string HashPassword(string password)
    {
        var user = new User();

        return _passwordHasher.HashPassword(user, password);
    }

    public bool VerifyPassword(
        string hashedPassword,
        string providedPassword)
    {
        var user = new User();

        var result = _passwordHasher.VerifyHashedPassword(
            user,
            hashedPassword,
            providedPassword);

        return result == PasswordVerificationResult.Success
            || result == PasswordVerificationResult.SuccessRehashNeeded;
    }
}