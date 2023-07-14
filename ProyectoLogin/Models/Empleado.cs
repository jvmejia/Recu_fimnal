using System.ComponentModel.DataAnnotations;

namespace ProyectoLogin.Models
{
    public partial class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }
        public int NumEmpleado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estatus { get; set; } 
    }
}
