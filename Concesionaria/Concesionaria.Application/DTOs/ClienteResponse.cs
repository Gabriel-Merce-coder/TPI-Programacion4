using Concesionaria.domain.Entities;

namespace Concesionaria.Application.DTOs
{
    public record ClienteResponse(
        int Id,
        string Nombre,
        string Apellido,
        string Email,
        string Telefono
    )
    {
        public static ClienteResponse From(Cliente cliente)
        {
            return new ClienteResponse(
                cliente.Id,
                cliente.Nombre,
                cliente.Apellido,
                cliente.Email,
                cliente.Telefono
            );
        }
    }
}