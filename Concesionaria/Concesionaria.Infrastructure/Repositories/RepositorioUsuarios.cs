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

        public void Agregar(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
        }

        public Cliente? ObtenerClientePorId(int id)
        {
            return context.Clientes
                .FirstOrDefault(c => c.Id == id);
        }

        public Administrador? ObtenerAdministradorPorId(int id)
        {
            return context.Administradores
                .FirstOrDefault(a => a.Id == id);
        }

        public IReadOnlyList<Cliente> ObtenerClientes()
        {
            return context.Clientes.ToList();
        }

        public IReadOnlyList<Administrador> ObtenerAdministradores()
        {
            return context.Administradores.ToList();
        }

        public Usuario? ObtenerPorEmail(string email)
        {
            return context.Usuarios
                .FirstOrDefault(u => u.Email == email);
        }

        public bool ExisteEmail(string email)
        {
            return context.Usuarios
                .Any(u => u.Email == email);
        }

        public void GuardarCambios()
        {
            context.SaveChanges();
        }
    }
}