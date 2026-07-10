//File path: Ops.Infrastructure/Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using Ops.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();                
        public DbSet<User> Users => Set<User>();
        //Add your entity


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
