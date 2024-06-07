using System;
using System.Collections.Generic;

namespace MercDevs_ej2.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<Recepcionequipo> Recepcionequipos { get; set; } = new List<Recepcionequipo>();
}
