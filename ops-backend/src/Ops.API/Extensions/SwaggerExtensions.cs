using Microsoft.OpenApi;
//using Microsoft.OpenApi.Models;

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
        });

        return services;
    }
}