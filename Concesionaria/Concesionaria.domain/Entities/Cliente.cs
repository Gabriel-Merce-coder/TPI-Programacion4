namespace Concesionaria.domain.Entities
{
    public class Cliente : Usuario
    {
        public List<Reserva> Reservas { get; private set; } = new List<Reserva>();

        private Cliente()
        {
        }

        public Cliente(string nombre, string apellido, string email, string contrasenia, string telefono)
            : base(nombre, apellido, email, contrasenia, telefono)
        {
        }
    }
}