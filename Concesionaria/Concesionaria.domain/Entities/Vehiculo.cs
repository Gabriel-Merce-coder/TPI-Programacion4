using Concesionaria.domain.Enums;
namespace Concesionaria.domain.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public int Anio { get; set; }
        public string Color { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public decimal Valuacion { get; set; }
        public int Kilometraje { get; set; }
        public EstadoVehiculoEnum Estado { get; set; }
        public DateTime? FechaBaja { get; set; }
        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
        public ICollection<VehiculoEquipamiento> VehiculoEquipamientos { get; set; } = new List<VehiculoEquipamiento>();
        public Vehiculo(string marca, string modelo, string version, int anio, string color, 
            decimal precio, decimal valuacion, int kilometraje)

        {

            if(string.IsNullOrWhiteSpace(marca))
            {
                throw new ArgumentException("La marca no puede estar vacía.", nameof(marca));
            }
            if(string.IsNullOrWhiteSpace(modelo))
            {
                throw new ArgumentException("El modelo no puede estar vacío.", nameof(modelo));
            }
            if(string.IsNullOrWhiteSpace(version))
            {
                throw new ArgumentException("La versión no puede estar vacía.", nameof(version));
            }
            if (anio < 0) 
            {
                throw new ArgumentOutOfRangeException(nameof(anio), "El año debe ser valido .");
            }
            if(string.IsNullOrWhiteSpace(color))
            {
                throw new ArgumentException("El color no puede estar vacío.", nameof(color));

            }
            if(precio < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(precio), "El precio debe ser mayor a cero.");
            }
            if (valuacion < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valuacion), "La valuación debe ser mayor a cero.");
            }
            if (kilometraje < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(kilometraje), "El kilometraje debe ser mayor a cero.");
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
            if(FechaBaja != null)
            {
                throw new InvalidOperationException("No se puede reservar un vehículo dado de baja.");
            }

            if(Estado != EstadoVehiculoEnum.Disponible)
            {
                throw new InvalidOperationException("El vehículo no está disponible para reservar.");
            }
            Estado = EstadoVehiculoEnum.Reservado;
        }

        public void CancelarReserva()
        {
            if(Estado != EstadoVehiculoEnum.Reservado)
            {
                throw new InvalidOperationException("El vehículo no está reservado.");
            }
            if(FechaBaja != null)
            {
                throw new InvalidOperationException("El vehiculo esta dado de baja.");
            }

            Estado = EstadoVehiculoEnum.Disponible;
        }
        public void Vender()
        {
            if(Estado != EstadoVehiculoEnum.Reservado)
            {
                throw new InvalidOperationException("El vehículo debe estar reservado para ser vendido");
            }
            if(FechaBaja != null)
            {
                throw new InvalidOperationException("El vehiculo esta dado de baja.");
            }
            Estado = EstadoVehiculoEnum.Vendido;
        }

        public void ActualizarPrecio(decimal nuevoPrecio)
        {
            if(nuevoPrecio < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(nuevoPrecio), "El precio debe ser mayor a cero.");
            }
            Precio = nuevoPrecio;
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
    
