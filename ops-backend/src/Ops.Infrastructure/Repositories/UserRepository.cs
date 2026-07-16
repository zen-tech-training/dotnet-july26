// File path: Ops.Infrastructure/Repositories/UserRepository.cs

using Microsoft.EntityFrameworkCore;
using Ops.Application.Interfaces;
using Ops.Domain.Entities;
using Ops.Infrastructure.Data;

namespace Ops.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Users.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName, cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Users.AnyAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<bool> ExistsUserNameAsync(string userName, CancellationToken cancellationToken = default)
    {
        return await _context.Users.AnyAsync(x => x.UserName == userName, cancellationToken);
    }

    public async Task<bool> ExistsEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Users.AnyAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<bool> ExistsMobileNumberAsync(string mobileNumber, CancellationToken cancellationToken = default)
    {
        return await _context.Users.AnyAsync(x => x.MobileNumber == mobileNumber, cancellationToken);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await _context.Users.AddAsync(user, cancellationToken);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Delete(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
