
namespace Concesionaria.Application.DTOs
{
    public record CrearVehiculoRequest(
        string Marca,
        string Modelo,
        string Version,
        int Anio,
        string Color,
        int Kilometraje,
        decimal Precio,
        decimal Valuacion
    );
}
