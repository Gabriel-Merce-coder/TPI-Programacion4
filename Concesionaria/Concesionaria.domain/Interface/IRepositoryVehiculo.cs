using Concesionaria.domain.Entities;

namespace Concesionaria.domain.Interfaces
{
    public interface IRepositorioVehiculos
    {
        void Agregar(Vehiculo vehiculo);

        IReadOnlyList<Vehiculo> ObtenerTodos();

        Vehiculo? ObtenerPorId(int id);

        void GuardarCambios();
    }
}
