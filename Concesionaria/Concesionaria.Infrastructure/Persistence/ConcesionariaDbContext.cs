using Concesionaria.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Concesionaria.Infrastructure.Persistence
{
    public class ConcesionariaDbContext : DbContext
    {
        public ConcesionariaDbContext(
            DbContextOptions<ConcesionariaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Reserva>();
            modelBuilder.Ignore<VehiculoEquipamiento>();

            base.OnModelCreating(modelBuilder);
        }
    }
}