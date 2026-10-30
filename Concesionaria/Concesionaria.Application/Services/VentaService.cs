
using Concesionaria.Application.DTOs;
using Concesionaria.Application.Interfaces;
using Concesionaria.domain.Entities;
using Concesionaria.domain.Enums;
using Concesionaria.domain.Interfaces;

namespace Concesionaria.Application.Services
{
    public class VentaService : IVentaService
    {
        private readonly IRepositorioVentas repositorioVentas;
        private readonly IRepositorioReservas repositorioReservas;
        private readonly IRepositorioVehiculos repositorioVehiculos;

        public VentaService(
            IRepositorioVentas repositorioVentas,
            IRepositorioReservas repositorioReservas,
            IRepositorioVehiculos repositorioVehiculos)
        {
            this.repositorioVentas = repositorioVentas;
            this.repositorioReservas = repositorioReservas;
            this.repositorioVehiculos = repositorioVehiculos;
        }

        public VentaResponse Crear(CrearVentaRequest request)
        {
            var reserva = repositorioReservas.ObtenerPorId(request.ReservaId)
                ?? throw new KeyNotFoundException(
                    $"No existe una reserva con el id {request.ReservaId}.");

            if (reserva.Estado != EstadoReservaEnum.Confirmada)
            {
                throw new InvalidOperationException(
                    "Solo se puede vender una reserva confirmada.");
            }

            if (repositorioVentas.ExisteVentaParaReserva(reserva.Id))
            {
                throw new InvalidOperationException(
                    "La reserva ya tiene una venta registrada.");
            }

            var vehiculo = repositorioVehiculos.ObtenerPorId(reserva.VehiculoId)
                ?? throw new KeyNotFoundException(
                    $"No existe un vehículo con el id {reserva.VehiculoId}.");

            if (vehiculo.FechaBaja != null ||
                vehiculo.Estado != EstadoVehiculoEnum.Reservado)
            {
                throw new InvalidOperationException(
                    "El vehículo no está habilitado para la venta.");
            }

            var venta = new Venta(
                DateTime.Now,
                request.PrecioFinal,
                reserva.Id
            );

            reserva.Concretar();
            vehiculo.Vender();

            repositorioVentas.Agregar(venta);
            repositorioVentas.GuardarCambios();

            return new VentaResponse(
                venta.Id,
                venta.FechaVenta,
                venta.PrecioFinal,
                venta.ReservaId
            );
        }

        public VentaResponse? ObtenerPorId(int id)
        {
            var venta = repositorioVentas.ObtenerPorId(id);

            if (venta == null)
            {
                return null;
            }

            return new VentaResponse(
                venta.Id,
                venta.FechaVenta,
                venta.PrecioFinal,
                venta.ReservaId
            );
        }

        public IReadOnlyList<VentaResponse> ObtenerTodas()
        {
            return repositorioVentas.ObtenerTodas()
                .Select(venta => new VentaResponse(
                    venta.Id,
                    venta.FechaVenta,
                    venta.PrecioFinal,
                    venta.ReservaId
                ))
                .ToList();
        }
    }
}
