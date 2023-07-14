using System.ComponentModel.DataAnnotations;

namespace ProyectoLogin.Models
{
    public partial class Activo
    {
        [Key]
        public int IdActivo { get; set; }
        public string Nombre  { get; set; }
        public string Descripcion { get; set; }
        public bool Estatus { get; set; }
    }
}
