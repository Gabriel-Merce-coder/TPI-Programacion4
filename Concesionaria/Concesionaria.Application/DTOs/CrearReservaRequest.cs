namespace Concesionaria.Application.DTOs
{
    public record CrearReservaRequest(
        int ClienteId,
        int VehiculoId
    );
}