
namespace Concesionaria.domain.Entities
{
    public class Cliente : Usuario
    {
        public ICollection<Reserva> Reservas { get; set; } 
            = new List<Reserva>();
    }
}
