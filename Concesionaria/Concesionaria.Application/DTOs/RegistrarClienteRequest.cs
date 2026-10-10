namespace Concesionaria.Application.DTOs
{
    public record RegistrarClienteRequest(
        string Nombre,
        string Apellido,
        string Email,
        string Contrasenia,
        string Telefono
    );
}