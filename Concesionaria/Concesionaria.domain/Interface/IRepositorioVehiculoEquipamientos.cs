using Concesionaria.domain.Entities;

namespace Concesionaria.domain.Interfaces
{
    public interface IRepositorioVehiculoEquipamientos
    {
        void Agregar(VehiculoEquipamiento asignacion);

        void Quitar(VehiculoEquipamiento asignacion);

        VehiculoEquipamiento? ObtenerAsignacion(int vehiculoId, int equipamientoId);

        IReadOnlyList<Equipamiento> ObtenerEquipamientosDeVehiculo(int vehiculoId);

        void GuardarCambios();
    }
}