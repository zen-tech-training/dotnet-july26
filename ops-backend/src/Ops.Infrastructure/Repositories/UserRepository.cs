using Microsoft.EntityFrameworkCore;
using Ops.Application.Interfaces;
using Ops.Domain.Entities;
using Ops.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserName == userName, cancellationToken);
        }
        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<User?> GetByMobileNumberAsync(string mobileNumber, CancellationToken cancellationToken = default)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.MobileNumber == mobileNumber, cancellationToken);
        }
    }
}
