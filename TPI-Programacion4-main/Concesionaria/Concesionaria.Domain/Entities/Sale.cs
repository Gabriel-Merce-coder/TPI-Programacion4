namespace Concesionaria.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal PrecioFinal { get; set; }

        public int ReservaId { get; set; }
        public Reservation Reserva { get; set; } = null!;
    }
}
