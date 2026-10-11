using Concesionaria.Application.DTOs;

namespace Concesionaria.Application.Interfaces
{
    public interface IAdministradorService
    {
        AdministradorResponse Crear(CrearAdministradorRequest request);

        IReadOnlyList<AdministradorResponse> ObtenerTodos();

        AdministradorResponse? ObtenerPorId(int id);
    }
}