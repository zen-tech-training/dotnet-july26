using Ops.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Application.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<User?> GetByMobileNumberAsync(string mobileNumber, CancellationToken cancellationToken = default);
    }
}