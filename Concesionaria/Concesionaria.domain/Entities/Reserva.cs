using Concesionaria.domain.Enums;

namespace Concesionaria.domain.Entities
{
    public class Reserva
    {
        public int Id { get; private set; }

        public DateTime FechaReserva { get; private set; }

        public EstadoReservaEnum Estado { get; private set; }

        public int ClienteId { get; private set; }

        public Cliente Cliente { get; private set;  } = null!;

        public int VehiculoId { get; private set;}

        public Vehiculo Vehiculo { get; private set; } = null!;

        public Venta? Venta { get; private set; }

        private Reserva()
        {
        }
        public Reserva(
            DateTime fechaReserva,
            int clienteId,
            int vehiculoId)
        {
            if (fechaReserva == default)
            {
                throw new ArgumentException(
                    "La fecha de reserva no es válida.",
                    nameof(fechaReserva));
            }

            if (clienteId <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(clienteId),
                    "El cliente asociado no es válido.");
            }

            if (vehiculoId <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(vehiculoId),
                    "El vehículo asociado no es válido.");
            }

            FechaReserva = fechaReserva;
            ClienteId = clienteId;
            VehiculoId = vehiculoId;

            Estado = EstadoReservaEnum.Pendiente;
        }


        public void Confirmar()
        {
            if (Estado != EstadoReservaEnum.Pendiente)
            {
                throw new InvalidOperationException(
                    "Solo se puede confirmar una reserva pendiente.");
            }

            Estado = EstadoReservaEnum.Confirmada;
        }


        public void Cancelar()
        {
            if (Estado != EstadoReservaEnum.Confirmada)
            {
                throw new InvalidOperationException(
                    "Solo se puede cancelar una reserva confirmada.");
            }

            Estado = EstadoReservaEnum.Cancelada;
        }


        public void Concretar()
        {
            if (Estado != EstadoReservaEnum.Confirmada)
            {
                throw new InvalidOperationException(
                    "Solo se puede concretar una reserva confirmada.");
            }

            Estado = EstadoReservaEnum.Concretada;
        }
    }
}