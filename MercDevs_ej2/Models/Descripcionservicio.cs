﻿using System;
using System.Collections.Generic;

namespace MercDevs_ej2.Models;

public partial class Descripcionservicio
{
    public int? IdDescServ { get; set; }

    public string Nombre { get; set; } = null!;

    public int? IdServicio { get; set; }

    public virtual Servicio IdServicioNavigation { get; set; } = null!;
}
