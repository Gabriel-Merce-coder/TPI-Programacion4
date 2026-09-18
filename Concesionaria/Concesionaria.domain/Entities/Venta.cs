namespace Concesionaria.domain.Entities
{
    public class Venta
    {
        public int Id { get; }

        public DateTime FechaVenta { get; }

        public decimal PrecioFinal { get; private set; }

        public int ReservaId { get; }

        public Reserva Reserva { get; } = null!;


        public Venta(
            DateTime fechaVenta,
            decimal precioFinal,
            int reservaId)
        {
            if (fechaVenta == default)
            {
                throw new ArgumentException(
                    "La fecha de venta no es válida.",
                    nameof(fechaVenta));
            }

            if (precioFinal <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(precioFinal),
                    "El precio final debe ser mayor a cero.");
            }

            if (reservaId <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(reservaId),
                    "La reserva asociada no es válida.");
            }

            FechaVenta = fechaVenta;
            PrecioFinal = precioFinal;
            ReservaId = reservaId;
        }
    }
}