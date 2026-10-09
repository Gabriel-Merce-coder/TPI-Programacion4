using Concesionaria.domain.Entities;

namespace Concesionaria.domain.Interfaces
{
    public interface IRepositorioReservas
    {
        void Agregar(Reserva reserva);

        Reserva? ObtenerPorId(int id);

        IReadOnlyList<Reserva> ObtenerTodas();

        bool ExisteReservaActivaParaVehiculo(int vehiculoId);

        void GuardarCambios();
    }
}