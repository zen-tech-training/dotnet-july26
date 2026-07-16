namespace Ops.API.Extensions;

public static class CorsExtensions
{
    public static IServiceCollection AddCorsConfiguration(
        this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.WithOrigins(
                        "http://127.0.0.1:5500",
                        "http://localhost:5500",
                        "http://localhost:4200")
                //policy.AllowAnyOrigin()
                    .AllowAnyHeader()

                    .AllowAnyMethod()

                    .AllowCredentials(); // Required to read the HttpOnly cookie from /v4Get
            });
        });

        return services;
    }
}