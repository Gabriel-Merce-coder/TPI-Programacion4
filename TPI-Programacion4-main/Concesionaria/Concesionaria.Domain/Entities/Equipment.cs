namespace Concesionaria.Domain.Entities
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<VehicleEquipment> VehiculoEquipamientos { get; set; }
        = new List<VehicleEquipment>();
    }
}
