using Concesionaria.domain.Entities;
using Concesionaria.domain.Interfaces;
using Concesionaria.Infrastructure.Persistence;

namespace Concesionaria.Infrastructure.Repositories
{
    public class RepositorioVehiculoEquipamientos : IRepositorioVehiculoEquipamientos
    {
        private readonly ConcesionariaDbContext context;

        public RepositorioVehiculoEquipamientos(ConcesionariaDbContext context)
        {
            this.context = context;
        }

        public void Agregar(VehiculoEquipamiento asignacion)
        {
            context.VehiculosEquipamientos.Add(asignacion);
        }

        public void Quitar(VehiculoEquipamiento asignacion)
        {
            context.VehiculosEquipamientos.Remove(asignacion);
        }

        public VehiculoEquipamiento? ObtenerAsignacion(int vehiculoId, int equipamientoId)
        {
            return context.VehiculosEquipamientos.FirstOrDefault(
                ve => ve.VehiculoId == vehiculoId && ve.EquipamientoId == equipamientoId);
        }

        public IReadOnlyList<Equipamiento> ObtenerEquipamientosDeVehiculo(int vehiculoId)
        {
            return context.VehiculosEquipamientos
                .Where(ve => ve.VehiculoId == vehiculoId)
                .Select(ve => ve.Equipamiento)
                .ToList();
        }

        public void GuardarCambios()
        {
            context.SaveChanges();
        }
    }
}