using Concesionaria.domain.Entities;

namespace Concesionaria.domain.Interfaces
{
    public interface IRepositorioUsuarios
    {
        void Agregar(Usuario usuario);

        Cliente? ObtenerClientePorId(int id);

        Administrador? ObtenerAdministradorPorId(int id);

        IReadOnlyList<Cliente> ObtenerClientes();

        IReadOnlyList<Administrador> ObtenerAdministradores();

        Usuario? ObtenerPorEmail(string email);

        bool ExisteEmail(string email);

        void GuardarCambios();
    }
}