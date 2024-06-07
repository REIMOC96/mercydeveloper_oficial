using System;
using System.Collections.Generic;

namespace MercDevs_ej2.Models;

public partial class Descripcionservicio
{
    public int IdDescServ { get; set; }

    public string Nombre { get; set; } = null!;

    public int ServicioIdServicio { get; set; }

    public virtual Servicio ServicioIdServicioNavigation { get; set; } = null!;
}
