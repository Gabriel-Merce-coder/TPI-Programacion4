namespace Concesionaria.Domain.Entities
{
    public class VehicleEquipment
    {
        public int VehiculoId { get; set; }
        public Vehicle Vehiculo { get; set; } = null!;

        public int EquipamientoId { get; set; }
        public Equipment Equipamiento { get; set; } = null!;
    }
}
