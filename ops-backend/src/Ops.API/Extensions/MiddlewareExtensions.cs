using Ops.API.Middleware;

namespace Ops.API.Extensions;

public static class MiddlewareExtensions
{
    public static IServiceCollection AddCustomMiddlewares(
        this IServiceCollection services)
    {
        //services.AddTransient<RequestLoggingMiddleware>();  
        // It is not necessary to register RequestLoggingMiddleware as a service because it is not injected into other services.
        // It is used directly in the middleware pipeline.
        //RequestDelegate is not a DI service. It is supplied automatically by ASP.NET Core when you call UseMiddleware<T>().

        services.AddTransient<MyMiddlewareThreeDI>();               
        return services;
    }

    public static IApplicationBuilder UseApplicationPipeline(
        this IApplicationBuilder app)
    {
        var env =
            app.ApplicationServices
               .GetRequiredService<IWebHostEnvironment>();

        if (env.IsDevelopment())
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    "OPS API V1");

                c.RoutePrefix = string.Empty;
            });
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowAll");

        app.UseMiddleware<RequestLoggingMiddleware>();

        app.UseAuthentication();

        app.UseAuthorization();


        // First Inline Middleware Implementation
        app.Use(async (context, next) =>
        {
            // Logic BEFORE the next middleware (e.g., logging request)
            Console.WriteLine($"First Inline Middleware Before - Request Method: {context.Request.Method}");
            Console.WriteLine($"First Inline Middleware Before - Response Status: {context.Response.StatusCode}");

            // Call the next middleware in the pipeline
            await next(context); //

            // Logic AFTER the next middleware (e.g., logging response status)
            Console.WriteLine($"First Inline Middleware After - Response Status: {context.Response.StatusCode}");
        });

        app.UseMiddleware<MyMiddlewareTwo>();

        app.UseMiddleware<MyMiddlewareThreeDI>();

        // Second Inline Middleware Implementation
        app.Use(async (context, next) =>
        {
            Console.WriteLine($"Second Inline Middleware Before - Request Method: {context.Request.Method}");
            await next(context);
            Console.WriteLine($"Second Inline Middleware After - Response Status: {context.Response.StatusCode}");
        });

        return app;
    }
}