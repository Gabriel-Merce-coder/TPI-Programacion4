using Concesionaria.Application.DTOs;
using Concesionaria.Application.Interfaces;
using Concesionaria.domain.Interfaces;

namespace Concesionaria.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepositorioUsuarios repositorioUsuarios;
        private readonly ITokenService tokenService;
        private readonly IPasswordHasher passwordHasher;

        public AuthService(
            IRepositorioUsuarios repositorioUsuarios,
            ITokenService tokenService,
            IPasswordHasher passwordHasher)
        {
            this.repositorioUsuarios = repositorioUsuarios;
            this.tokenService = tokenService;
            this.passwordHasher = passwordHasher;
        }

        public LoginResponse? Autenticar(LoginRequest request)
        {
            var usuario = repositorioUsuarios.ObtenerPorEmail(request.Email);

            if (usuario == null ||
                !passwordHasher.Verify(request.Contrasenia, usuario.Contrasenia))
            {
                return null;
            }

            var token = tokenService.GenerateToken(
                usuario.Id,
                usuario.Email,
                usuario.GetType().Name);

            return new LoginResponse(token);
        }
    }
}