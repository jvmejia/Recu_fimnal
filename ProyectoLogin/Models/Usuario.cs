using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLogin.Models;

public partial class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }
}
