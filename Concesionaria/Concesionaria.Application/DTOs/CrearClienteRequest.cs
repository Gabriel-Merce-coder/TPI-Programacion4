namespace Concesionaria.Application.DTOs
{
    public record CrearClienteRequest(
        string Nombre,
        string Apellido,
        string Email,
        string Contrasenia,
        string Telefono
    );
}