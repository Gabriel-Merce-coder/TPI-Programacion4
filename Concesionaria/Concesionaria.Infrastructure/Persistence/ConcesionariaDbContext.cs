
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
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Administrador> Administradores => Set<Administrador>();
        public DbSet<Reserva> Reservas => Set<Reserva>();
        public DbSet<Venta> Ventas => Set<Venta>();
        public DbSet<Equipamiento> Equipamientos => Set<Equipamiento>();
        public DbSet<VehiculoEquipamiento> VehiculosEquipamientos => Set<VehiculoEquipamiento>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .UseTpcMappingStrategy();

            modelBuilder.Entity<Usuario>()
                .ToTable((string?)null);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reservas)
                .HasForeignKey(r => r.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Vehiculo)
                .WithMany(v => v.Reservas)
                .HasForeignKey(r => r.VehiculoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a uno: Reserva - Venta
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Reserva)
                .WithOne(r => r.Venta)
                .HasForeignKey<Venta>(v => v.ReservaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación muchos a muchos: Vehículo - Equipamiento (tabla intermedia explícita)
            modelBuilder.Entity<VehiculoEquipamiento>()
                .HasKey(ve => new { ve.VehiculoId, ve.EquipamientoId });

            modelBuilder.Entity<VehiculoEquipamiento>()
                .HasOne(ve => ve.Vehiculo)
                .WithMany(v => v.VehiculoEquipamientos)
                .HasForeignKey(ve => ve.VehiculoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VehiculoEquipamiento>()
                .HasOne(ve => ve.Equipamiento)
                .WithMany(e => e.VehiculoEquipamientos)
                .HasForeignKey(ve => ve.EquipamientoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehiculo>()
                .Property(v => v.Precio)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Vehiculo>()
                .Property(v => v.Valuacion)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Venta>()
                .Property(v => v.PrecioFinal)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}