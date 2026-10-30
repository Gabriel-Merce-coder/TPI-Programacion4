
namespace Concesionaria.Application.DTOs
{
    public record ActualizarVehiculoRequest(
        decimal? Precio,
        int? Kilometraje
    );
}
