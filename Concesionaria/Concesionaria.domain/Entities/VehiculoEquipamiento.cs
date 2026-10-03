namespace Concesionaria.domain.Entities
{
    public class VehiculoEquipamiento
    {
        public int VehiculoId { get; private set; }

        public Vehiculo Vehiculo { get; private set; } = null!;

        public int EquipamientoId { get; private set; }

        public Equipamiento Equipamiento { get; private set; } = null!;


        private VehiculoEquipamiento()
        {
        }


        public VehiculoEquipamiento(
            int vehiculoId,
            int equipamientoId)
        {
            if (vehiculoId <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(vehiculoId),
                    "El vehículo asociado no es válido.");
            }

            if (equipamientoId <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(equipamientoId),
                    "El equipamiento asociado no es válido.");
            }

            VehiculoId = vehiculoId;
            EquipamientoId = equipamientoId;
        }
    }
}