using System;
using System.Collections.Generic;

namespace MercDevs_ej2.MercydevsEjercicio2;

public partial class Datosfichatecnica
{
    public int IdFichaTecnica { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFinalizacion { get; set; }

    public string? PobservacionRecomendaciones { get; set; }

    public int? Soinstalado { get; set; }

    public int? SuiteOfficeInstalada { get; set; }

    public int? LectorPdfinstalado { get; set; }

    public int? NavegadorWebInstalado { get; set; }

    public string? AntivirusInstalado { get; set; }

    public int RecepcionEquipoId { get; set; }

    public virtual ICollection<Diagnosticosolucion> Diagnosticosolucions { get; set; } = new List<Diagnosticosolucion>();

    public virtual Recepcionequipo RecepcionEquipo { get; set; } = null!;
}
