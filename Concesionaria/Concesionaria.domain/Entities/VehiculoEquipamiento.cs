namespace Concesionaria.domain.Entities
{
    public class VehiculoEquipamiento
    {
        public int VehiculoId { get; }

        public Vehiculo Vehiculo { get; } = null!;

        public int EquipamientoId { get; }

        public Equipamiento Equipamiento { get; } = null!;


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