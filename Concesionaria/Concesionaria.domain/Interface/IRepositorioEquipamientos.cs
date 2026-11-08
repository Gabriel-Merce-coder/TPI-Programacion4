using Concesionaria.domain.Entities;

namespace Concesionaria.domain.Interfaces
{
    public interface IRepositorioEquipamientos
    {
        void Agregar(Equipamiento equipamiento);

        IReadOnlyList<Equipamiento> ObtenerTodos();

        Equipamiento? ObtenerPorId(int id);

        void GuardarCambios();
    }
}