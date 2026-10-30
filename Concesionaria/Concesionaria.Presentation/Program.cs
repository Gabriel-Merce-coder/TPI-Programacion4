
using Concesionaria.Application.Interfaces;
using Concesionaria.Application.Services;
using Concesionaria.domain.Interfaces;
using Concesionaria.Infrastructure.ExternalServices;
using Concesionaria.Infrastructure.Persistence;
using Concesionaria.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Concesionaria.domain.Entities;
using Concesionaria.Presentation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// OpenAPI
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

// Base de datos
builder.Services.AddDbContext<ConcesionariaDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DevelopmentConnection")
    )
);

// Inyección de dependencias

// Vehículos
builder.Services.AddScoped<IVehiculoService, VehiculoService>();
builder.Services.AddScoped<IRepositorioVehiculos, RepositorioVehiculos>();

// Reservas
builder.Services.AddScoped<IReservaService, ReservaService>();
builder.Services.AddScoped<IRepositorioReservas, RepositorioReservas>();
builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();

// Ventas
builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<IRepositorioVentas, RepositorioVentas>();

// Usuarios
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IAdministradorService, AdministradorService>();
builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();

// Autenticación
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, JwtTokenService>();

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection(JwtSettings.SectionName));

var jwtSettings = builder.Configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>()
    ?? throw new InvalidOperationException("Falta la sección 'Jwt' en la configuración.");

if (string.IsNullOrWhiteSpace(jwtSettings.Key))
{
    throw new InvalidOperationException(
        "Falta la clave 'Jwt:Key'. Definila en appsettings.Development.json o en la variable de entorno Jwt__Key.");
}

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,

            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Policies.AdminsOnly, policy =>
        policy.RequireRole(nameof(Administrador)));

    options.AddPolicy(Policies.Reservas, policy =>
        policy.RequireRole(nameof(Administrador), nameof(Cliente)));
});

var app = builder.Build();

// OpenAPI solamente en desarrollo
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
