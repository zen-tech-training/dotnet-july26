using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Ops.Application.Interfaces;
using Ops.Application.Mapping;
using Ops.Application.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
//using AutoMapper;

namespace Ops.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            //var mapperConfig = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<AutoMapperProfile>();
            //});

            //mapperConfig.AssertConfigurationIsValid();

            //IMapper mapper = mapperConfig.CreateMapper();

            //services.AddSingleton(mapper);

            services.AddAutoMapper(typeof(AutoMapperProfile)); //For AutoMapper 12.0.0 and later, you can use this line instead of the previous lines to register AutoMapper with the DI container.

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}