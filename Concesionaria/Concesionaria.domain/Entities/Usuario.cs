

using System.Text.RegularExpressions;

namespace Concesionaria.domain.Entities
{
    public  class Usuario
    {
        private const string PatronTelefono = @"^\d{10}$";
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;


        public Usuario(string nombre, string apellido, string email, string contrasenia, string telefono)
        {

            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));
            }
            if (string.IsNullOrWhiteSpace(apellido))
            {
                throw new ArgumentException("El apellido no puede estar vacío.", nameof(apellido));
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("El email no puede estar vacío.", nameof(email));
            }
            if (string.IsNullOrWhiteSpace(contrasenia))
            {
                throw new ArgumentException("La contraseña no puede estar vacía.", nameof(contrasenia));
            }
            if (string.IsNullOrWhiteSpace(telefono))
            {
                throw new ArgumentException("El teléfono no puede estar vacío.", nameof(telefono));
            } 
            if(!Regex.IsMatch(telefono, PatronTelefono))
            {
                throw new ArgumentException("El teléfono debe tener 10 dígitos.", nameof(telefono));
            }

            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Contrasenia = contrasenia;
            Telefono = telefono;
        }
    }
}
