namespace Concesionaria.Application.DTOs
{
    public record RegistrarAdministradorRequest(
        string Nombre,
        string Apellido,
        string Email,
        string Contrasenia,
        string Telefono,
        string Cargo
    );
}