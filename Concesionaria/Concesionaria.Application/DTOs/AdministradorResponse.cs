using Concesionaria.domain.Entities;

namespace Concesionaria.Application.DTOs
{
    public record AdministradorResponse(
        int Id,
        string Nombre,
        string Apellido,
        string Email,
        string Telefono,
        string Cargo
    )
    {
        public static AdministradorResponse From(Administrador administrador)
        {
            return new AdministradorResponse(
                administrador.Id,
                administrador.Nombre,
                administrador.Apellido,
                administrador.Email,
                administrador.Telefono,
                administrador.Cargo
            );
        }
    }
}