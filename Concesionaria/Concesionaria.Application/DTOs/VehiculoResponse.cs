using Concesionaria.domain.Entities;
using Concesionaria.domain.Enums;

namespace Concesionaria.Application.DTOs
{
    public record VehiculoResponse(
        int Id,
        string Marca,
        string Modelo,
        string Version,
        int Anio,
        string Color,
        int Kilometraje,
        decimal Precio,
        decimal Valuacion,
        EstadoVehiculoEnum Estado,
        DateTime? FechaBaja
    )
    {
        public static VehiculoResponse Desde(Vehiculo vehiculo)
        {
            return new VehiculoResponse(
                vehiculo.Id,
                vehiculo.Marca,
                vehiculo.Modelo,
                vehiculo.Version,
                vehiculo.Anio,
                vehiculo.Color,
                vehiculo.Kilometraje,
                vehiculo.Precio,
                vehiculo.Valuacion,
                vehiculo.Estado,
                vehiculo.FechaBaja
            );
        }
    }
}