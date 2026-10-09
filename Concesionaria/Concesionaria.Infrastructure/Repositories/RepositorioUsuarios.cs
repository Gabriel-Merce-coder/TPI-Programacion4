using Concesionaria.domain.Entities;
using Concesionaria.domain.Interfaces;
using Concesionaria.Infrastructure.Persistence;


namespace Concesionaria.Infrastructure.Repositories
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly ConcesionariaDbContext context;

        public RepositorioUsuarios(ConcesionariaDbContext context)
        {
            this.context = context;
        }

        public Cliente? ObtenerClientePorId(int id)
        {
            return context.Clientes
                .FirstOrDefault(c => c.Id == id);
        }
    }
}