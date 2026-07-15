using Ops.Application;
using Ops.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// 1. Add CORS services and define an "AllowAll" policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500", "http://localhost:4200")
             //"file:///D:/Projects/DotNetProjects/OPS-july2026/ops-frontend/basics/")
             //policy.WithOrigins("http://127.0.0.1:5500") // Replace with your EXACT frontend URL (No trailing slash)
             //policy.AllowAnyOrigin()
             .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();  // Required to read the HttpOnly cookie from /v4Get
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "Ops API V1");

        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

//https://localhost:6004/
app.MapGet("/", () => "Hello World! "); //HTTP GET - Root Route // Minimal API
//This get request will be accessible from the browser/ JS/ swagger / Postman API/ Thunder Client
//To access this web api from the frontend application we need to add CORS in Program.cs file

app.MapGet("/v2Get", () => new { message = "Hello World! " });

app.MapGet("/v3Get", () => new { message = "Hello World! ", key = 123, key2 = "Some String" });

app.MapGet("/v4Get", (HttpContext context) =>
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


app.Run();
