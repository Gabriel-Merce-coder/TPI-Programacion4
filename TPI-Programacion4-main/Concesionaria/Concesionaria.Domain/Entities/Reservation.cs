namespace Concesionaria.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public EstadoReservaEnum Estado { get; set; }

        public int ClienteId { get; set; }
        public Client Cliente { get; set; } = null!;

        public int VehiculoId { get; set; }
        public Vehicle Vehiculo { get; set; } = null!;

        public Sale? Sale { get; set; }
    }
}
