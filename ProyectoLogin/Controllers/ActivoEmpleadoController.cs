using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;
using ProyectoLogin.Servicios.Contrato;
using ProyectoLogin.Servicios.Implementacion;

namespace ProyectoLogin.Controllers
{
    public class ActivoEmpleadoController : Controller
    {
        private readonly DbpruebaContext _dbContext;
        private readonly IActivoEmpleadoService _Iactivoempleado;
        public ActivoEmpleadoController(IActivoEmpleadoService activoempleadoService, DbpruebaContext dbContext)
        {
            _dbContext = dbContext;
            _Iactivoempleado = activoempleadoService;
        }
        // GET: EmpleadoController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _Iactivoempleado.GetActivoEmpleado();
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
            return Redirect("/Empleado/Index");
        }
        [HttpGet]
        public IActionResult VistaActivo()
        {
            return Redirect("/Activo/Index");
        }
        [HttpGet]
        public IActionResult VistaActivoEmpleado()
        {
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Crear(ActivoEmpleado i)
        {
            await _Iactivoempleado.Crear(i);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            { return NotFound(); }
            var empleado = _dbContext.ActivoEmpleados.Find(id);
            if (empleado == null)
            { return NotFound(); }
            return View(empleado);
        }
        [HttpPost]
        public async Task<RedirectToActionResult> Editor(ActivoEmpleado i, int id)
        {

            await _Iactivoempleado.Editor(i, id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _Iactivoempleado.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
