using Concesionaria.Application.DTOs;
using Concesionaria.Application.Interfaces;
using Concesionaria.domain.Entities;
using Concesionaria.domain.Enums;
using Concesionaria.domain.Interfaces;

namespace Concesionaria.Application.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IRepositorioReservas repositorioReservas;
        private readonly IRepositorioUsuarios repositorioUsuarios;
        private readonly IRepositorioVehiculos repositorioVehiculos;

        public ReservaService(
            IRepositorioReservas repositorioReservas,
            IRepositorioUsuarios repositorioUsuarios,
            IRepositorioVehiculos repositorioVehiculos)
        {
            this.repositorioReservas = repositorioReservas;
            this.repositorioUsuarios = repositorioUsuarios;
            this.repositorioVehiculos = repositorioVehiculos;
        }

        public ReservaResponse Crear(CrearReservaRequest request)
        {
            var cliente = repositorioUsuarios.ObtenerClientePorId(request.ClienteId)
                ?? throw new KeyNotFoundException(
                    $"No existe un cliente con el id {request.ClienteId}.");

            var vehiculo = repositorioVehiculos.ObtenerPorId(request.VehiculoId)
                ?? throw new KeyNotFoundException(
                    $"No existe un vehículo con el id {request.VehiculoId}.");

            if (vehiculo.FechaBaja != null ||
                vehiculo.Estado != EstadoVehiculoEnum.Disponible)
            {
                throw new InvalidOperationException(
                    "El vehículo no está disponible para reservar.");
            }

            if (repositorioReservas.ExisteReservaActivaParaVehiculo(request.VehiculoId))
            {
                throw new InvalidOperationException(
                    "El vehículo ya tiene una reserva activa.");
            }

            var reserva = new Reserva(
                DateTime.Now,
                request.ClienteId,
                request.VehiculoId
            );

            repositorioReservas.Agregar(reserva);
            repositorioReservas.GuardarCambios();

            return ReservaResponse.From(reserva);
        }

        public IReadOnlyList<ReservaResponse> ObtenerTodas() =>
            repositorioReservas.ObtenerTodas()
                .Select(ReservaResponse.From)
                .ToList();

        public ReservaResponse? ObtenerPorId(int id)
        {
            var reserva = repositorioReservas.ObtenerPorId(id);

            return reserva == null ? null : ReservaResponse.From(reserva);
        }

        public ReservaResponse Confirmar(int id)
        {
            var reserva = repositorioReservas.ObtenerPorId(id)
                ?? throw new KeyNotFoundException(
                    $"No existe una reserva con el id {id}.");

            var vehiculo = repositorioVehiculos.ObtenerPorId(reserva.VehiculoId)
                ?? throw new KeyNotFoundException(
                    $"No existe un vehículo con el id {reserva.VehiculoId}.");

            // Validamos el estado antes de modificar el vehículo.
            if (reserva.Estado != EstadoReservaEnum.Pendiente)
            {
                throw new InvalidOperationException(
                    "Solo se puede confirmar una reserva pendiente.");
            }

            vehiculo.Reservar();
            reserva.Confirmar();

            repositorioReservas.GuardarCambios();

            return ReservaResponse.From(reserva);
        }

        public ReservaResponse Cancelar(int id)
        {
            var reserva = repositorioReservas.ObtenerPorId(id)
                ?? throw new KeyNotFoundException(
                    $"No existe una reserva con el id {id}.");

            var vehiculo = repositorioVehiculos.ObtenerPorId(reserva.VehiculoId)
                ?? throw new KeyNotFoundException(
                    $"No existe un vehículo con el id {reserva.VehiculoId}.");

            if (reserva.Estado != EstadoReservaEnum.Confirmada)
            {
                throw new InvalidOperationException(
                    "Solo se puede cancelar una reserva confirmada.");
            }

            vehiculo.CancelarReserva();
            reserva.Cancelar();

            repositorioReservas.GuardarCambios();

            return ReservaResponse.From(reserva);
        }
    }
}