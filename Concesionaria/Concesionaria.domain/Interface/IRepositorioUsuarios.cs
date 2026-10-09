using Concesionaria.domain.Entities;

namespace Concesionaria.domain.Interfaces
{
    public interface IRepositorioUsuarios
    {
        Cliente? ObtenerClientePorId(int id);
    }
}