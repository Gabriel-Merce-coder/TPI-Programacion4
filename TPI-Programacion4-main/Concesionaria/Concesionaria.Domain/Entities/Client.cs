namespace Concesionaria.Domain.Entities
{
    public class Client : User
    {
        public ICollection<Reservation> Reservas { get; set; } = new List<Reservation>();
    }
}
