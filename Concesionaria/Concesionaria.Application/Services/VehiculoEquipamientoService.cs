using Concesionaria.Application.DTOs;
using Concesionaria.Application.Interfaces;
using Concesionaria.domain.Entities;
using Concesionaria.domain.Interfaces;

namespace Concesionaria.Application.Services
{
    public class VehiculoEquipamientoService : IVehiculoEquipamientoService
    {
        private readonly IRepositorioVehiculos repositorioVehiculos;
        private readonly IRepositorioEquipamientos repositorioEquipamientos;
        private readonly IRepositorioVehiculoEquipamientos repositorioAsignaciones;

        public VehiculoEquipamientoService(
            IRepositorioVehiculos repositorioVehiculos,
            IRepositorioEquipamientos repositorioEquipamientos,
            IRepositorioVehiculoEquipamientos repositorioAsignaciones)
        {
            this.repositorioVehiculos = repositorioVehiculos;
            this.repositorioEquipamientos = repositorioEquipamientos;
            this.repositorioAsignaciones = repositorioAsignaciones;
        }

        public IReadOnlyList<EquipamientoResponse> ObtenerEquipamientos(int vehiculoId)
        {
            ObtenerVehiculoOFallar(vehiculoId);

            return repositorioAsignaciones
                .ObtenerEquipamientosDeVehiculo(vehiculoId)
                .Select(EquipamientoResponse.From)
                .ToList();
        }

        public void Asignar(int vehiculoId, int equipamientoId)
        {
            var vehiculo = ObtenerVehiculoOFallar(vehiculoId);

            if (vehiculo.FechaBaja != null)
            {
                throw new InvalidOperationException(
                    "No se pueden modificar los equipamientos de un vehículo dado de baja.");
            }

            if (repositorioEquipamientos.ObtenerPorId(equipamientoId) == null)
            {
                throw new KeyNotFoundException(
                    $"No existe un equipamiento con el id {equipamientoId}.");
            }

            if (repositorioAsignaciones.ObtenerAsignacion(vehiculoId, equipamientoId) != null)
            {
                throw new InvalidOperationException(
                    "El vehículo ya tiene ese equipamiento asignado.");
            }

            repositorioAsignaciones.Agregar(
                new VehiculoEquipamiento(vehiculoId, equipamientoId));
            repositorioAsignaciones.GuardarCambios();
        }

        public void Quitar(int vehiculoId, int equipamientoId)
        {
            var vehiculo = ObtenerVehiculoOFallar(vehiculoId);

            if (vehiculo.FechaBaja != null)
            {
                throw new InvalidOperationException(
                    "No se pueden modificar los equipamientos de un vehículo dado de baja.");
            }

            var asignacion = repositorioAsignaciones.ObtenerAsignacion(vehiculoId, equipamientoId)
                ?? throw new KeyNotFoundException(
                    "El vehículo no tiene ese equipamiento asignado.");

            repositorioAsignaciones.Quitar(asignacion);
            repositorioAsignaciones.GuardarCambios();
        }

        private Vehiculo ObtenerVehiculoOFallar(int vehiculoId)
        {
            return repositorioVehiculos.ObtenerPorId(vehiculoId)
                ?? throw new KeyNotFoundException(
                    $"No existe un vehículo con el id {vehiculoId}.");
        }
    }
}