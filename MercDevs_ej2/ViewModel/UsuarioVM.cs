using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MercDevs_ej2.ViewModel
{
    public class UsuarioVM
    {
        public int IdUsuario { get; set; }

       // [Required(ErrorMessage = "El nombre es obligatorio")]
       // [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "El nombre solo puede contener letras y espacios")]
       // [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        public string Nombre { get; set; } = null!;

     //   [Required(ErrorMessage = "El apellido es obligatorio")]
     //   [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "El apellido solo puede contener letras y espacios")]
     //   [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres")]
        public string Apellido { get; set; } = null!;

      //  [Required(ErrorMessage = "El correo es obligatorio")]
      //  [EmailAddress(ErrorMessage = "Formato de correo no válido")]
      //  [StringLength(100, ErrorMessage = "El correo electrónico no puede tener más de 100 caracteres")]
        public string Correo { get; set; } = null!;

      //  [Required(ErrorMessage = "La contraseña es obligatoria")]
      //  [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string Password { get; set; } = null!;

      //  [Required(ErrorMessage = "Confirmar contraseña es obligatorio")]
      //  [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfPassword { get; set; } = null!;
       
        // quite los validadores porque por alguna razon hacian que la app fuera mucho mas lenta
    }
}
