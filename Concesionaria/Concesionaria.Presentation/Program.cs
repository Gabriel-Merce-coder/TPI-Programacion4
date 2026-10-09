using Concesionaria.Application.Interfaces;
using Concesionaria.Application.Services;
using Concesionaria.domain.Interfaces;
using Concesionaria.Infrastructure.Persistence;
using Concesionaria.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// OpenAPI
builder.Services.AddOpenApi();

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

var app = builder.Build();

// OpenAPI solamente en desarrollo
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();