namespace Concesionaria.Application.DTOs
{
    public record ActualizarVehiculoRequest(
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