namespace Ops.API.Extensions;

public static class EndpointExtensions
{
    public static IEndpointRouteBuilder MapApplicationEndpoints(
        this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapControllers();

        endpoints.MapGet("/", () => "OPS API is running...");

        endpoints.MapGet("/health", () =>
        {
            return Results.Ok(new
            {
                Status = "Healthy",

                Time = DateTime.UtcNow
            });
        });

        endpoints.MapGet("/v2Get", () => new { message = "Hello World! " });

        endpoints.MapGet("/v3Get", () => new { message = "Hello World! ", key = 123, key2 = "Some String" });

        endpoints.MapGet("/v4Get", (HttpContext context) =>
        {
            // 1. Create options for the cookie (Security settings)
            CookieOptions options = new CookieOptions
            {
                HttpOnly = true,       // Prevents JavaScript from reading the cookie (protects against XSS)
                                       //Secure = true,         // Ensures cookie is only sent over HTTPS
                Secure = false,        // http://localhost:4200
                SameSite = SameSiteMode.Lax, // Allows cookie to be sent on standard cross-site navigations
                Expires = DateTimeOffset.UtcNow.AddMinutes(1) // Cookie lifespan
            };

            // 2. Append the cookie to the HTTP response headers
            context.Response.Cookies.Append("MyUserToken", "SecureValue123", options);

            // 3. Return your JSON payload
            return Results.Ok(new { message = "Hello World! ", key = 123, key2 = "Some String from v4" });
        });


        return endpoints;
    }
}