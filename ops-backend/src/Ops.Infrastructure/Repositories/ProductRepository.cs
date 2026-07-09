using Microsoft.EntityFrameworkCore;
using Ops.Application.Interfaces;
using Ops.Domain.Entities;
using Ops.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Infrastructure.Repositories
{
    public class ProductRepository
    : GenericRepository<Product>,
      IProductRepository
    {
        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Product?> GetBySkuAsync(string sku, CancellationToken cancellationToken)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.SKU == sku);
        }
    }
}
