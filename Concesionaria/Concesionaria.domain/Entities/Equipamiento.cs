namespace Concesionaria.domain.Entities
{
    public class Equipamiento
    {
        private readonly List<VehiculoEquipamiento> vehiculoEquipamientos
            = new List<VehiculoEquipamiento>();

        public int Id { get; }

        public string Nombre { get; private set; }

        public string Descripcion { get; private set; }

        public IReadOnlyList<VehiculoEquipamiento> VehiculoEquipamientos
            => vehiculoEquipamientos.AsReadOnly();


        public Equipamiento(
            string nombre,
            string descripcion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException(
                    "El nombre no puede estar vacío.",
                    nameof(nombre));
            }

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException(
                    "La descripción no puede estar vacía.",
                    nameof(descripcion));
            }

            Nombre = nombre;
            Descripcion = descripcion;
        }


        public void ActualizarDatos(
            string nombre,
            string descripcion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException(
                    "El nombre no puede estar vacío.",
                    nameof(nombre));
            }

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException(
                    "La descripción no puede estar vacía.",
                    nameof(descripcion));
            }

            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}