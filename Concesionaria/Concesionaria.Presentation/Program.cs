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

// Entity Framework Core + SQL Server
builder.Services.AddDbContext<ConcesionariaDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DevelopmentConnection")
    )
);

// Inyección de dependencias
builder.Services.AddScoped<IVehiculoService, VehiculoService>();
builder.Services.AddScoped<IRepositorioVehiculos, RepositorioVehiculos>();

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