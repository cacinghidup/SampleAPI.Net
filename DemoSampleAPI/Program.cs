using System.Text;
using DemoSampleAPI.Auth;
using DemoSampleAPI.Helpers.DbConnection.Services;
using DemoSampleAPI.User;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

DotEnv.Load();

var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

// MySql Connection
builder.Services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();

// JWT
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],               
        ValidAudience = builder.Configuration["Jwt:Audience"], 
        IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey!)) 
    };
});

// Dependency Injection
builder.Services.AddAuthModule();
builder.Services.AddUserModule();

// Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Handle Exceptions
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new
        {
            statusCode = 500,
            message = "Terjadi kesalahan pada server. Silakan coba lagi nanti.",
            data = new { }
        }));
    });
});

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();
