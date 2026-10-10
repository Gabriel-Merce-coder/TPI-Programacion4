using Concesionaria.Application.DTOs;
using Concesionaria.Application.Interfaces;
using Concesionaria.domain.Entities;
using Concesionaria.domain.Interfaces;

namespace Concesionaria.Application.Services
{
    public class AdministradorService : IAdministradorService
    {
        private const int LargoMinimoContrasenia = 8;

        private readonly IRepositorioUsuarios repositorioUsuarios;
        private readonly IPasswordHasher passwordHasher;

        public AdministradorService(
            IRepositorioUsuarios repositorioUsuarios,
            IPasswordHasher passwordHasher)
        {
            this.repositorioUsuarios = repositorioUsuarios;
            this.passwordHasher = passwordHasher;
        }

        public AdministradorResponse Crear(CrearAdministradorRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Contrasenia) ||
                request.Contrasenia.Length < LargoMinimoContrasenia)
            {
                throw new ArgumentException(
                    $"La contraseña debe tener al menos {LargoMinimoContrasenia} caracteres.",
                    nameof(request.Contrasenia));
            }

            if (repositorioUsuarios.ExisteEmail(request.Email))
            {
                throw new InvalidOperationException(
                    "Ya existe un usuario registrado con ese email.");
            }

            var administrador = new Administrador(
                request.Nombre,
                request.Apellido,
                request.Email,
                passwordHasher.Hash(request.Contrasenia),
                request.Telefono,
                request.Cargo
            );

            repositorioUsuarios.Agregar(administrador);
            repositorioUsuarios.GuardarCambios();

            return AdministradorResponse.From(administrador);
        }

        public IReadOnlyList<AdministradorResponse> ObtenerTodos() =>
            repositorioUsuarios.ObtenerAdministradores().Select(AdministradorResponse.From).ToList();

        public AdministradorResponse? ObtenerPorId(int id)
        {
            var administrador = repositorioUsuarios.ObtenerAdministradorPorId(id);

            return administrador == null ? null : AdministradorResponse.From(administrador);
        }
    }
}