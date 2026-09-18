
using Concesionaria.domain.Enums;

namespace Concesionaria.domain.Entities
{
    public class Vehiculo
    {
        private readonly List<Reserva> reservas = new List<Reserva>();
        private readonly List<VehiculoEquipamiento> vehiculoEquipamientos
            = new List<VehiculoEquipamiento>();

        public int Id { get; private set; }

        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Version { get; private set; }
        public int Anio { get; private set; }
        public string Color { get; private set; }
        public decimal Precio { get; private set; }
        public decimal Valuacion { get; private set; }
        public int Kilometraje { get; private set; }

        public EstadoVehiculoEnum Estado { get; private set; }

        public DateTime? FechaBaja { get; private set; }

        public IReadOnlyList<Reserva> Reservas
            => reservas.AsReadOnly();

        public IReadOnlyList<VehiculoEquipamiento> VehiculoEquipamientos
            => vehiculoEquipamientos.AsReadOnly();

        private Vehiculo()
        {
            Marca = null!;
            Modelo = null!;
            Version = null!;
            Color = null!;
        }
        public Vehiculo(
            string marca,
            string modelo,
            string version,
            int anio,
            string color,
            decimal precio,
            decimal valuacion,
            int kilometraje)
        {
            if (string.IsNullOrWhiteSpace(marca))
            {
                throw new ArgumentException(
                    "La marca no puede estar vacía.",
                    nameof(marca));
            }

            if (string.IsNullOrWhiteSpace(modelo))
            {
                throw new ArgumentException(
                    "El modelo no puede estar vacío.",
                    nameof(modelo));
            }

            if (string.IsNullOrWhiteSpace(version))
            {
                throw new ArgumentException(
                    "La versión no puede estar vacía.",
                    nameof(version));
            }

            if (anio <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(anio),
                    "El año debe ser válido.");
            }

            if (string.IsNullOrWhiteSpace(color))
            {
                throw new ArgumentException(
                    "El color no puede estar vacío.",
                    nameof(color));
            }

            if (precio <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(precio),
                    "El precio debe ser mayor a cero.");
            }

            if (valuacion <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(valuacion),
                    "La valuación debe ser mayor a cero.");
            }

            if (kilometraje < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(kilometraje),
                    "El kilometraje no puede ser negativo.");
            }

            Marca = marca;
            Modelo = modelo;
            Version = version;
            Anio = anio;
            Color = color;
            Precio = precio;
            Valuacion = valuacion;
            Kilometraje = kilometraje;

            Estado = EstadoVehiculoEnum.Disponible;
        }


        public void Reservar()
        {
            if (FechaBaja != null)
            {
                throw new InvalidOperationException(
                    "No se puede reservar un vehículo dado de baja.");
            }

            if (Estado != EstadoVehiculoEnum.Disponible)
            {
                throw new InvalidOperationException(
                    "El vehículo no está disponible para reservar.");
            }

            Estado = EstadoVehiculoEnum.Reservado;
        }


        public void CancelarReserva()
        {
            if (Estado != EstadoVehiculoEnum.Reservado)
            {
                throw new InvalidOperationException(
                    "El vehículo no está reservado.");
            }

            if (FechaBaja != null)
            {
                throw new InvalidOperationException(
                    "El vehículo está dado de baja.");
            }

            Estado = EstadoVehiculoEnum.Disponible;
        }


        public void Vender()
        {
            if (Estado != EstadoVehiculoEnum.Reservado)
            {
                throw new InvalidOperationException(
                    "El vehículo debe estar reservado para ser vendido.");
            }

            if (FechaBaja != null)
            {
                throw new InvalidOperationException(
                    "El vehículo está dado de baja.");
            }

            Estado = EstadoVehiculoEnum.Vendido;
        }



        public void ActualizarDatos(
            string marca,
            string modelo,
            string version,
            int anio,
            string color,
            decimal precio,
            decimal valuacion,
            int kilometraje)
        {
            if (string.IsNullOrWhiteSpace(marca))
            {
                throw new ArgumentException(
                    "La marca no puede estar vacía.",
                    nameof(marca));
            }

            if (string.IsNullOrWhiteSpace(modelo))
            {
                throw new ArgumentException(
                    "El modelo no puede estar vacío.",
                    nameof(modelo));
            }

            if (string.IsNullOrWhiteSpace(version))
            {
                throw new ArgumentException(
                    "La versión no puede estar vacía.",
                    nameof(version));
            }

            if (anio <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(anio),
                    "El año debe ser válido.");
            }

            if (string.IsNullOrWhiteSpace(color))
            {
                throw new ArgumentException(
                    "El color no puede estar vacío.",
                    nameof(color));
            }

            if (precio <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(precio),
                    "El precio debe ser mayor a cero.");
            }

            if (valuacion <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(valuacion),
                    "La valuación debe ser mayor a cero.");
            }

            if (kilometraje < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(kilometraje),
                    "El kilometraje no puede ser negativo.");
            }

            Marca = marca;
            Modelo = modelo;
            Version = version;
            Anio = anio;
            Color = color;
            Precio = precio;
            Valuacion = valuacion;
            Kilometraje = kilometraje;
        }


        public void DarDeBaja()
        {
            if (FechaBaja != null)
            {
                throw new InvalidOperationException(
                    "El vehículo ya está dado de baja.");
            }

            FechaBaja = DateTime.Now;
        }
    }
}