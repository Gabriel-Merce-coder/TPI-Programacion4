using Concesionaria.Application.DTOs;

namespace Concesionaria.Application.Interfaces
{
    public interface IVehiculoEquipamientoService
    {
        IReadOnlyList<EquipamientoResponse> ObtenerEquipamientos(int vehiculoId);

        void Asignar(int vehiculoId, int equipamientoId);

        void Quitar(int vehiculoId, int equipamientoId);
    }
}