using Ops.API.Extensions;
using Ops.API.Middleware;
using Ops.Application;
using Ops.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddSwaggerDocumentation();

builder.Services.AddCorsConfiguration();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddCustomMiddlewares();

var app = builder.Build();

app.UseApplicationPipeline();

app.MapApplicationEndpoints();

app.Run();


//using Ops.API.Middleware;
//using Ops.Application;
//using Ops.Infrastructure;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using Ops.Infrastructure.Security;
//using System.Text;


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddApplication();

//builder.Services.AddInfrastructure(builder.Configuration);

//builder.Services
//.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//.AddJwtBearer(options =>
//{
//    var jwt = builder.Configuration
//        .GetSection(JwtSettings.SectionName);

//    options.TokenValidationParameters =
//        new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,

//            ValidIssuer = jwt["Issuer"],
//            ValidAudience = jwt["Audience"],

//            IssuerSigningKey =
//                new SymmetricSecurityKey(
//                    Encoding.UTF8.GetBytes(jwt["SecretKey"]!))
//        };
//});


//builder.Services.AddControllers();
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();

//// 1. Add CORS services and define an "AllowAll" policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", policy =>
//    {
//        policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500", "http://localhost:4200")
//             //policy.AllowAnyOrigin()
//             .AllowAnyMethod()
//              .AllowAnyHeader()
//              .AllowCredentials();  // Required to read the HttpOnly cookie from /v4Get
//    });
//});

//builder.Services.AddTransient<MyMiddlewareThreeDI>();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//    app.UseSwagger();

//    app.UseSwaggerUI(options =>
//    {
//        options.SwaggerEndpoint(
//            "/swagger/v1/swagger.json",
//            "Ops API V1");

//        options.RoutePrefix = string.Empty;
//    });
//}

//app.UseHttpsRedirection();
//app.UseCors("AllowAll");
//app.UseAuthentication();
//app.UseAuthorization();



//app.UseMiddleware<MyMiddlewareTwo>();

//app.UseMiddleware<MyMiddlewareThreeDI>();



//app.MapControllers();


//app.Run();