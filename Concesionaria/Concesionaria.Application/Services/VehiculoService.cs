
using Concesionaria.Application.DTOs;
using Concesionaria.Application.Interfaces;
using Concesionaria.domain.Entities;
using Concesionaria.domain.Interfaces;

namespace Concesionaria.Application.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IRepositorioVehiculos repositorioVehiculos;

        public VehiculoService(IRepositorioVehiculos repositorioVehiculos)
        {
            this.repositorioVehiculos = repositorioVehiculos;
        }

        public VehiculoResponse Crear(CrearVehiculoRequest request)
        {
            var vehiculo = new Vehiculo(
                request.Marca,
                request.Modelo,
                request.Version,
                request.Anio,
                request.Color,
                request.Precio,
                request.Valuacion,
                request.Kilometraje
            );

            repositorioVehiculos.Agregar(vehiculo);
            repositorioVehiculos.GuardarCambios();

            return VehiculoResponse.Desde(vehiculo);
        }

        public IReadOnlyList<VehiculoResponse> ObtenerTodos() =>
            repositorioVehiculos.ObtenerTodos()
                .Select(VehiculoResponse.Desde)
                .ToList();

        public VehiculoResponse? ObtenerPorId(int id)
        {
            var vehiculo = repositorioVehiculos.ObtenerPorId(id);

            return vehiculo == null
                ? null
                : VehiculoResponse.Desde(vehiculo);
        }

        public VehiculoResponse? Actualizar(
            int id,
            ActualizarVehiculoRequest request)
        {
            var vehiculo = repositorioVehiculos.ObtenerPorId(id);

            if (vehiculo == null)
            {
                return null;
            }

            if (request.Precio == null &&
                request.Kilometraje == null)
            {
                throw new ArgumentException(
                    "Debe proporcionar al menos un dato para actualizar.");
            }

            vehiculo.ActualizarDatosComerciales(
                request.Precio ?? vehiculo.Precio,
                request.Kilometraje ?? vehiculo.Kilometraje
            );

            repositorioVehiculos.GuardarCambios();

            return VehiculoResponse.Desde(vehiculo);
        }

        public bool DarDeBaja(int id)
        {
            var vehiculo = repositorioVehiculos.ObtenerPorId(id);

            if (vehiculo == null)
            {
                return false;
            }

            vehiculo.DarDeBaja();

            repositorioVehiculos.GuardarCambios();

            return true;
        }
    }
}
