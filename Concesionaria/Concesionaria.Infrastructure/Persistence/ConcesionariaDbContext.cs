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

            modelBuilder.Entity<Vehiculo>()
                .Property(v => v.Precio)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Vehiculo>()
                .Property(v => v.Valuacion)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}