using Concesionaria.Application.DTOs;

namespace Concesionaria.Application.Interfaces
{
    public interface IClienteService
    {
        ClienteResponse Crear(CrearClienteRequest request);

        IReadOnlyList<ClienteResponse> ObtenerTodos();

        ClienteResponse? ObtenerPorId(int id);
    }
}