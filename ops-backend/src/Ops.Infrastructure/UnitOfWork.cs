using Ops.Application.Interfaces;
using Ops.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IProductRepository Products { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(
            ApplicationDbContext context,
            IProductRepository productRepository,
            IUserRepository userRepository)
        {
            _context = context;
            Products = productRepository;
            Users = userRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
