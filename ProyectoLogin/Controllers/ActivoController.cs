using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;
using ProyectoLogin.Servicios.Contrato;
using ProyectoLogin.Servicios.Implementacion;


namespace ProyectoLogin.Controllers
{
    public class ActivoController : Controller
    {
        private readonly DbpruebaContext _dbContext;
        private readonly IActivoService _Iactivo;
        public ActivoController(IActivoService activoService, DbpruebaContext dbContext)
        {
            _dbContext = dbContext;
            _Iactivo = activoService;
        }
        // GET: EmpleadoController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _Iactivo.GetActivos();
            return View(response);
        }
        [HttpGet]
        public IActionResult VistaEmpleado()
        {
            return Redirect("/Empleado/Index");
        }
        [HttpGet]
        public IActionResult VistaActivo()
        {
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult VistaActivoEmpleado()
        {
            return Redirect("/ActivoEmpleado/Index");
        }
        [HttpGet]
        public IActionResult VistaCrear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Activo i)
        {
            await _Iactivo.Crear(i);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            { return NotFound(); }
            var empleado = _dbContext.Activos.Find(id);
            if (empleado == null)
            { return NotFound(); }
            return View(empleado);
        }
        [HttpPost]
        public async Task<RedirectToActionResult> Editor(Activo i, int id)
        {

            await _Iactivo.Editor(i, id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _Iactivo.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
