using Concesionaria.domain.Entities;
using Concesionaria.domain.Enums;

namespace Concesionaria.Application.DTOs
{
    public record ReservaResponse(
        int Id,
        DateTime FechaReserva,
        EstadoReservaEnum Estado,
        int ClienteId,
        int VehiculoId
    )
    {
        public static ReservaResponse From(Reserva reserva)
        {
            return new ReservaResponse(
                reserva.Id,
                reserva.FechaReserva,
                reserva.Estado,
                reserva.ClienteId,
                reserva.VehiculoId
            );
        }
    }
}