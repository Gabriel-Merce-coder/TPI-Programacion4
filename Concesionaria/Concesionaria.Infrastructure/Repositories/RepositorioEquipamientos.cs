using Concesionaria.domain.Entities;
using Concesionaria.domain.Interfaces;
using Concesionaria.Infrastructure.Persistence;

namespace Concesionaria.Infrastructure.Repositories
{
    public class RepositorioEquipamientos : IRepositorioEquipamientos
    {
        private readonly ConcesionariaDbContext context;

        public RepositorioEquipamientos(ConcesionariaDbContext context)
        {
            this.context = context;
        }

        public void Agregar(Equipamiento equipamiento)
        {
            context.Equipamientos.Add(equipamiento);
        }

        public IReadOnlyList<Equipamiento> ObtenerTodos()
        {
            return context.Equipamientos.ToList();
        }

        public Equipamiento? ObtenerPorId(int id)
        {
            return context.Equipamientos.FirstOrDefault(e => e.Id == id);
        }

        public void GuardarCambios()
        {
            context.SaveChanges();
        }
    }
}
