using Concesionaria.Application.DTOs;

namespace Concesionaria.Application.Interfaces
{
    public interface IReservaService
    {
        ReservaResponse Crear(CrearReservaRequest request);

        IReadOnlyList<ReservaResponse> ObtenerTodas();

        ReservaResponse? ObtenerPorId(int id);

        ReservaResponse Confirmar(int id);

        ReservaResponse Cancelar(int id);
    }
}