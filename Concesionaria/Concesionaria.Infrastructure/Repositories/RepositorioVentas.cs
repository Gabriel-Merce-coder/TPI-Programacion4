
using Concesionaria.domain.Entities;
using Concesionaria.domain.Interfaces;
using Concesionaria.Infrastructure.Persistence;

namespace Concesionaria.Infrastructure.Repositories
{
    public class RepositorioVentas : IRepositorioVentas
    {
        private readonly ConcesionariaDbContext context;

        public RepositorioVentas(ConcesionariaDbContext context)
        {
            this.context = context;
        }

        public void Agregar(Venta venta)
        {
            context.Ventas.Add(venta);
        }

        public Venta? ObtenerPorId(int id)
        {
            return context.Ventas
                .FirstOrDefault(v => v.Id == id);
        }

        public IReadOnlyList<Venta> ObtenerTodas()
        {
            return context.Ventas.ToList();
        }

        public bool ExisteVentaParaReserva(int reservaId)
        {
            return context.Ventas
                .Any(v => v.ReservaId == reservaId);
        }

        public void GuardarCambios()
        {
            context.SaveChanges();
        }
    }
}
