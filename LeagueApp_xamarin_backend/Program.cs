using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using LeagueApp_xamarin_backend.Data;
using LeagueApp_xamarin_backend.Helpers;
using LeagueApp_xamarin_backend.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();

// Add Application Insights
builder.Services.AddApplicationInsightsTelemetry(options =>
{
    options.ConnectionString = "InstrumentationKey=6bd4a237-69f0-4032-b032-6b8c45b44bc0";
});

//add the JWT authentication configuration:
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var secretKey = "ThisIsMySecret_TEMP_KeyForHS256Algorithm_12345"; // Replace with your secret key
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key,
        ValidateIssuer = true,
        ValidIssuer = "https://leagueapp.azurewebsites.net/", // Replace with your issuer
        ValidateAudience = true,
        ValidAudience = "https://api.your-backend.com/api/login", // Replace with your audience
        ValidateLifetime = true
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the UniqueCodeGenerator
builder.Services.AddScoped<UniqueCodeGenerator>();

var app = builder.Build();

// Add a logger to log the start of the application
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application started.");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add the authentication middleware to the request pipeline
app.UseAuthentication();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
