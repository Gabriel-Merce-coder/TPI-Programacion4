using Concesionaria.Application.DTOs;

namespace Concesionaria.Application.Interfaces
{
    public interface IAuthService
    {
        LoginResponse? Autenticar(LoginRequest request);
    }
}