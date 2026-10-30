
namespace Concesionaria.Application.DTOs
{
    public record VentaResponse(
        int Id,
        DateTime FechaVenta,
        decimal PrecioFinal,
        int ReservaId);
}
