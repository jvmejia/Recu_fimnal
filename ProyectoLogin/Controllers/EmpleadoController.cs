using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;
using ProyectoLogin.Servicios.Contrato;
using ProyectoLogin.Servicios.Implementacion;

namespace ProyectoLogin.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly DbpruebaContext _dbContext;
        private readonly IEmpleadoService _Iempleado;
        public EmpleadoController(IEmpleadoService empleadoService, DbpruebaContext dbContext)
        {
            _dbContext = dbContext;
            _Iempleado = empleadoService;
        }
        // GET: EmpleadoController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _Iempleado.GetEmpleados();
            return View(response);
        }
        [HttpGet]
        public IActionResult VistaCrear()
        {
            return View();
        }
        [HttpGet]
        public IActionResult VistaEmpleado()
        {
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult VistaActivo()
        {
            return Redirect("/Activo/Index");

        }
        [HttpGet]
        public IActionResult VistaActivoEmpleado()
        {
            return Redirect("/ActivoEmpleado/Index");

        }
        [HttpPost]
        public async Task<IActionResult> Crear(Empleado i)
        {
            await _Iempleado.Crear(i);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            { return NotFound(); }
            var empleado = _dbContext.Empleados.Find(id);
            if (empleado == null)
            { return NotFound(); }
            return View(empleado);
        }
        [HttpPost]
        public async Task<RedirectToActionResult> Editor(Empleado i, int id)
        {
            
            await _Iempleado.Editor(i, id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _Iempleado.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
    
