using Concesionaria.domain.Entities;
using Concesionaria.domain.Interfaces;
using Concesionaria.Infrastructure.Persistence;

namespace Concesionaria.Infrastructure.Repositories
{
    public class RepositorioVehiculos : IRepositorioVehiculos
    {
        private readonly ConcesionariaDbContext context;

        public RepositorioVehiculos(ConcesionariaDbContext context)
        {
            this.context = context;
        }

        public void Agregar(Vehiculo vehiculo)
        {
            context.Vehiculos.Add(vehiculo);
        }

        public IReadOnlyList<Vehiculo> ObtenerTodos()
        {
            return context.Vehiculos.ToList();
        }

        public Vehiculo? ObtenerPorId(int id)
        {
            return context.Vehiculos.FirstOrDefault(v => v.Id == id);
        }

        public void GuardarCambios()
        {
            context.SaveChanges();
        }
    }
}