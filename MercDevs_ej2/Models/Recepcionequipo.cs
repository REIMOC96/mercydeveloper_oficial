using System;
using System.Collections.Generic;

namespace MercDevs_ej2.Models;

public partial class Recepcionequipo
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public int IdServicio { get; set; }

    public DateTime? Fecha { get; set; }

    public int? TipoPc { get; set; }

    public string? Accesorio { get; set; }

    public string? MarcaPc { get; set; }

    public string? ModeloPc { get; set; }

    public string? Nserie { get; set; }

    public int? CapacidadRam { get; set; }

    public int? TipoAlmacenamiento { get; set; }

    public string? CapacidadAlmacenamiento { get; set; }

    public int? TipoGpu { get; set; }

    public string? Grafico { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Servicio IdServicioNavigation { get; set; } = null!;
}
