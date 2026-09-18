using Concesionaria.Application.DTOs;

namespace Concesionaria.Application.Interfaces
{
    public interface IVehiculoService
    {
        VehiculoResponse Crear(CrearVehiculoRequest request);

        IReadOnlyList<VehiculoResponse> ObtenerTodos();

        VehiculoResponse? ObtenerPorId(int id);

        VehiculoResponse? Actualizar(
            int id,
            ActualizarVehiculoRequest request
        );

        bool DarDeBaja(int id);
    }
}