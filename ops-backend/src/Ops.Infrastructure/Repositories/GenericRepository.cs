using Microsoft.EntityFrameworkCore;
using Ops.Application.Interfaces;
using Ops.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
    where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Remove(entity);
        }
    }

}
