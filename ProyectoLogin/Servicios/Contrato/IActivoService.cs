using ProyectoLogin.Models;

namespace ProyectoLogin.Servicios.Contrato
{
    public interface IActivoService
    {
        public Task<List<Activo>> GetActivos();
        public Task Crear(Activo i);
        public Task Editor(Activo i, int id);
        public Task Eliminar(int id);
    }
}
