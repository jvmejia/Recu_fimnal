using ProyectoLogin.Models;

namespace ProyectoLogin.Servicios.Contrato
{
    public interface IActivoEmpleadoService
    {
        public Task<List<ActivoEmpleado>> GetActivoEmpleado();
        public Task Crear(ActivoEmpleado i);
        public Task Editor(ActivoEmpleado i, int id);
        public Task Eliminar(int id);
    }
}
