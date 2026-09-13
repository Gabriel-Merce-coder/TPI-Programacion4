

namespace Concesionaria.domain.Entities
{
    public class Equipamiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty; 

        public ICollection<VehiculoEquipamiento> VehiculoEquipamientos { get; set; }
            = new List<VehiculoEquipamiento>();
    }
}
