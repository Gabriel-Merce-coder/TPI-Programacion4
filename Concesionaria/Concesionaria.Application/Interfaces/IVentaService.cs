
using Concesionaria.Application.DTOs;

namespace Concesionaria.Application.Interfaces
{
    public interface IVentaService
    {
        VentaResponse Crear(CrearVentaRequest request);

        VentaResponse? ObtenerPorId(int id);

        IReadOnlyList<VentaResponse> ObtenerTodas();
    }
}
