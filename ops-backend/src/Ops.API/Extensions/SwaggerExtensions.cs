//using Microsoft.OpenApi;

//namespace Ops.API.Extensions;

//public static class SwaggerExtensions
//{
//    public static IServiceCollection AddSwaggerDocumentation(
//        this IServiceCollection services)
//    {
//        services.AddEndpointsApiExplorer();

//        services.AddSwaggerGen(options =>
//        {
//            options.SwaggerDoc(
//                "v1",
//                new OpenApiInfo
//                {
//                    Title = "OPS API",
//                    Version = "v1"
//                });

//            options.AddSecurityDefinition(
//                "Bearer",
//                new OpenApiSecurityScheme
//                {
//                    Name = "Authorization",
//                    Type = SecuritySchemeType.Http,
//                    Scheme = "bearer",
//                    BearerFormat = "JWT",
//                    In = ParameterLocation.Header,
//                    Description = "Enter JWT token in the format: Bearer {your token}"
//                });

//            options.AddSecurityRequirement(
//                new OpenApiSecurityRequirement
//                {
//                    {
//                        new OpenApiSecurityScheme
//                        {
//                            Reference = new OpenApiReference
//                            {
//                                Type = ReferenceType.SecurityScheme,
//                                Id = "Bearer"
//                            }
//                        },
//                        Array.Empty<string>()
//                    }
//                });
//        });

//        return services;
//    }
//}


using Microsoft.OpenApi.Models;

namespace Ops.API.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerDocumentation(
        this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Title = "OPS API",
                    Version = "v1"
                });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\""
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "bearer",
                        Name = "Authorization",
                        In = ParameterLocation.Header
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}