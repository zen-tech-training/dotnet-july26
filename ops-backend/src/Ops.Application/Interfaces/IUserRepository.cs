using Ops.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Application.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        //Task<User?> GetByUserName(string userName, CancellationToken cancellationToken);
        //Task<User?>  (string email, CancellationToken cancellationToken);
        //Task<User?> GetByMobileNumber(string mobileNumber, CancellationToken cancellationToken);
    }
}