

namespace Concesionaria.domain.Entities
{
    public class VehiculoEquipamiento
    {
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; } = null!;
        public int EquipamientoId { get; set; }
        public Equipamiento Equipamiento { get; set; } =  null!;
    }
}
