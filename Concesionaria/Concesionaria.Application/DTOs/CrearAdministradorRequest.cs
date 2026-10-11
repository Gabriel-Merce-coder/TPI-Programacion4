namespace Concesionaria.Application.DTOs
{
    public record CrearAdministradorRequest(
        string Nombre,
        string Apellido,
        string Email,
        string Contrasenia,
        string Telefono,
        string Cargo
    );
}