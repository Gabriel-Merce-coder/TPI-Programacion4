using Concesionaria.Application.DTOs;
using Concesionaria.Application.Interfaces;
using Concesionaria.domain.Entities;
using Concesionaria.domain.Interfaces;

namespace Concesionaria.Application.Services
{
    public class EquipamientoService : IEquipamientoService
    {
        private readonly IRepositorioEquipamientos repositorioEquipamientos;

        public EquipamientoService(IRepositorioEquipamientos repositorioEquipamientos)
        {
            this.repositorioEquipamientos = repositorioEquipamientos;
        }

        public EquipamientoResponse Crear(CrearEquipamientoRequest request)
        {
            var equipamiento = new Equipamiento(
                request.Nombre,
                request.Descripcion
            );

            repositorioEquipamientos.Agregar(equipamiento);
            repositorioEquipamientos.GuardarCambios();

            return EquipamientoResponse.From(equipamiento);
        }

        public IReadOnlyList<EquipamientoResponse> ObtenerTodos() =>
            repositorioEquipamientos.ObtenerTodos().Select(EquipamientoResponse.From).ToList();

        public EquipamientoResponse? ObtenerPorId(int id)
        {
            var equipamiento = repositorioEquipamientos.ObtenerPorId(id);

            return equipamiento == null ? null : EquipamientoResponse.From(equipamiento);
        }

        public EquipamientoResponse? Actualizar(int id, ActualizarEquipamientoRequest request)
        {
            var equipamiento = repositorioEquipamientos.ObtenerPorId(id);

            if (equipamiento == null)
            {
                return null;
            }

            equipamiento.ActualizarDatos(
                request.Nombre,
                request.Descripcion
            );

            repositorioEquipamientos.GuardarCambios();

            return EquipamientoResponse.From(equipamiento);
        }
    }
}
