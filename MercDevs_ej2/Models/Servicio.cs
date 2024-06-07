using System;
using System.Collections.Generic;

namespace MercDevs_ej2.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string Nombre { get; set; } = null!;

    public int Precio { get; set; }

    public string? Sku { get; set; }

    public int UsuarioIdUsuario { get; set; }

    public virtual ICollection<Descripcionservicio> Descripcionservicios { get; set; } = new List<Descripcionservicio>();

    public virtual ICollection<Recepcionequipo> Recepcionequipos { get; set; } = new List<Recepcionequipo>();

    public virtual Usuario UsuarioIdUsuarioNavigation { get; set; } = null!;
}
