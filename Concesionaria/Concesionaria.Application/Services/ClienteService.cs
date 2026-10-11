using Concesionaria.Application.DTOs;
using Concesionaria.Application.Interfaces;
using Concesionaria.domain.Entities;
using Concesionaria.domain.Interfaces;

namespace Concesionaria.Application.Services
{
    public class ClienteService : IClienteService
    {
        private const int LargoMinimoContrasenia = 8;

        private readonly IRepositorioUsuarios repositorioUsuarios;
        private readonly IPasswordHasher passwordHasher;

        public ClienteService(
            IRepositorioUsuarios repositorioUsuarios,
            IPasswordHasher passwordHasher)
        {
            this.repositorioUsuarios = repositorioUsuarios;
            this.passwordHasher = passwordHasher;
        }

        public ClienteResponse Crear(CrearClienteRequest request)
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

            var cliente = new Cliente(
                request.Nombre,
                request.Apellido,
                request.Email,
                passwordHasher.Hash(request.Contrasenia),
                request.Telefono
            );

            repositorioUsuarios.Agregar(cliente);
            repositorioUsuarios.GuardarCambios();

            return ClienteResponse.From(cliente);
        }

        public IReadOnlyList<ClienteResponse> ObtenerTodos() =>
            repositorioUsuarios.ObtenerClientes().Select(ClienteResponse.From).ToList();

        public ClienteResponse? ObtenerPorId(int id)
        {
            var cliente = repositorioUsuarios.ObtenerClientePorId(id);

            return cliente == null ? null : ClienteResponse.From(cliente);
        }
    }
}