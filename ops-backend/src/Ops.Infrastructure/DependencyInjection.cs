using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Ops.Application.Interfaces;
using Ops.Infrastructure.Data;
using Ops.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Infrastructure
{
    //Extension method, I am extending IServiceCollection
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(
                typeof(IGenericRepository<>),
                typeof(GenericRepository<>));

            services.AddScoped<IProductRepository,
                               ProductRepository>();

            services.AddScoped<IUserRepository,
                               UserRepository>();

            //Add you newly created Entity Repository as a Scoped Service

            services.AddScoped<IUnitOfWork,
                               UnitOfWork>();

            return services;
        }
    }
}
