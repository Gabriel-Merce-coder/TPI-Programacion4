
using Concesionaria.domain.Entities;

namespace Concesionaria.domain.Interfaces
{
    public interface IRepositorioVentas
    {
        void Agregar(Venta venta);

        Venta? ObtenerPorId(int id);

        IReadOnlyList<Venta> ObtenerTodas();

        bool ExisteVentaParaReserva(int reservaId);

        void GuardarCambios();
    }
}
