using Microsoft.AspNetCore.Mvc;
using ProyectoLogin.Models;

namespace ProyectoLogin.Servicios.Contrato
{
    public interface IEmpleadoService
    {
        public Task<List<Empleado>> GetEmpleados();
        public Task Crear(Empleado i);
        public Task Editor(Empleado i, int id);
        public Task Eliminar(int id);


    }
}
