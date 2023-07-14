using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLogin.Models
{
    public partial class ActivoEmpleado
    {
        [Key]
        public int IdActivoEmpleado { get; set; }
        [ForeignKey("Empleado")]
        public int? FkEmpleado { get; set; }
        public Empleado Empleado { get; set; }
        [ForeignKey("Activo")]
        public int? FkActivo { get; set; }
        public Activo Activo { get; set; } 
        public DateTime FechaDeAsignacion { get; set; }
        public DateTime FechaDeLiberacion { get; set; }
        public DateTime FechaDeEntrega { get; set; }
    }
}
