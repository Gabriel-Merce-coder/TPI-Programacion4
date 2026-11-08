using Concesionaria.domain.Entities;

namespace Concesionaria.Application.DTOs
{
    public record EquipamientoResponse(
        int Id,
        string Nombre,
        string Descripcion
    )
    {
        public static EquipamientoResponse From(Equipamiento equipamiento)
        {
            return new EquipamientoResponse(
                equipamiento.Id,
                equipamiento.Nombre,
                equipamiento.Descripcion
            );
        }
    }
}
