using MercDevs_ej2.MercydevsEjercicio2;
using MercDevs_ej2.Models;

namespace MercDevs_ej2.ViewModel
{
    public class FichaCompleta
    {
        public Models.Recepcionequipo? Equipo { get; set; }
        public Models.Datosfichatecnica? DatosFichaTecnica { get; set; }
        public Models.Cliente? Cliente { get; set; }
        public Models.Servicio? Servicio { get; set; }
        public Models.Usuario? Usuario { get; set; }
        public Models.Descripcionservicio? DescripcionServicio { get; set; }
        public Models.Diagnosticosolucion? DiagnosticoSolucion { get; set; }
    }
}
