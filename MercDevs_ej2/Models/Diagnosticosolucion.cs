using System;
using System.Collections.Generic;

namespace MercDevs_ej2.Models;

public partial class Diagnosticosolucion
{
    public int IdDiagnosticoSolucion { get; set; }

    public string DescripcionDiagnostico { get; set; } = null!;

    public string? DescripcionSolucion { get; set; }

    public int? IdFichaTecnica { get; set; } =null!;

    public virtual Datosfichatecnica IdFichaTecnicaNavigation { get; set; } = null!;
}
