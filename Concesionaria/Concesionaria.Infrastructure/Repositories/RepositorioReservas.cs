using Concesionaria.domain.Entities;
using Concesionaria.domain.Enums;
using Concesionaria.domain.Interfaces;
using Concesionaria.Infrastructure.Persistence;

namespace Concesionaria.Infrastructure.Repositories
{
    public class RepositorioReservas : IRepositorioReservas
    {
        private readonly ConcesionariaDbContext context;

        public RepositorioReservas(ConcesionariaDbContext context)
        {
            this.context = context;
        }

        public void Agregar(Reserva reserva)
        {
            context.Reservas.Add(reserva);
        }

        public Reserva? ObtenerPorId(int id)
        {
            return context.Reservas
                .FirstOrDefault(r => r.Id == id);
        }

        public IReadOnlyList<Reserva> ObtenerTodas()
        {
            return context.Reservas.ToList();
        }

        public bool ExisteReservaActivaParaVehiculo(int vehiculoId)
        {
            return context.Reservas.Any(r =>
                r.VehiculoId == vehiculoId &&
                (r.Estado == EstadoReservaEnum.Pendiente ||
                 r.Estado == EstadoReservaEnum.Confirmada));
        }

        public void GuardarCambios()
        {
            context.SaveChanges();
        }
    }
}