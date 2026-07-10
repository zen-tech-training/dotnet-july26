using Microsoft.EntityFrameworkCore;
using Ops.Application.Interfaces;
using Ops.Domain.Entities;
using Ops.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Infrastructure.Repositories
{
    public class UserRepository
    : GenericRepository<User>,
      IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        //GetByUserName
        //GetByUserName



    }
}
