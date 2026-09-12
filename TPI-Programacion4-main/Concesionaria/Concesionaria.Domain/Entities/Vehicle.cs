namespace Concesionaria.Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Version { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
        public int Kilometraje { get; set; }
        public decimal Precio { get; set; }
        public decimal Valuacion { get; set; }
        public EstadoVehiculoEnum Estado { get; set; }
        public DateTime? FechaBaja { get; set; }

        public ICollection<Reservation> Reservas { get; set; } = new List<Reservation>();
        public ICollection<VehicleEquipment> VehiculoEquipamientos { get; set; }
            = new List<VehicleEquipment>();
    }
}
