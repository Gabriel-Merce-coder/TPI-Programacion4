

namespace Concesionaria.domain.Entities
{
    public  class Administrador : Usuario
    {
        public string Cargo { get; set; } = string.Empty;

        public Administrador(string nombre, string apellido, string email, string contrasenia, string telefono, string cargo)
            : base(nombre, apellido, email, contrasenia, telefono)
        {
            if (string.IsNullOrWhiteSpace(cargo))
            {
                throw new ArgumentException("El cargo no puede estar vacío.", nameof(cargo));
            }
            Cargo = cargo;
        }
    }
    
}
