

namespace Concesionaria.domain.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal PrecioFinal { get; set; }
        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; } = null!;


    }
}
