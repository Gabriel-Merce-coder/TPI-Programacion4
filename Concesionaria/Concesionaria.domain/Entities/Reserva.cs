using Concesionaria.domain.Enums;

namespace Concesionaria.domain.Entities
{
    public  class Reserva
    {
        public int Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public EstadoReservaEnum Estado { get; set; }
        public int  ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public int VehiculoId{ get; set; }
        public Vehiculo Vehiculo  { get; set; } = null!;

        public Venta? Venta { get; set; }
    }
}
