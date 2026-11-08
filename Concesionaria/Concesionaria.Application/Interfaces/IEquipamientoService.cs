using Concesionaria.Application.DTOs;

namespace Concesionaria.Application.Interfaces
{
    public interface IEquipamientoService
    {
        EquipamientoResponse Crear(CrearEquipamientoRequest request);

        IReadOnlyList<EquipamientoResponse> ObtenerTodos();

        EquipamientoResponse? ObtenerPorId(int id);

        EquipamientoResponse? Actualizar(int id, ActualizarEquipamientoRequest request);
    }
}