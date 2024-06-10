using System.ComponentModel.DataAnnotations;

namespace MercDevs_ej2.ViewModel
{
    public class LoginVM
    {
      //  [Required(ErrorMessage = "El correo es obligatorio")]
      //  [EmailAddress(ErrorMessage = "Formato de correo no válido")]
      //  [StringLength(40, ErrorMessage = "El correo electrónico no puede tener más de 40 caracteres")]
        public string Correo { get; set; } = string.Empty;

      //  [Required(ErrorMessage = "La contraseña es obligatoria")]
      //  [StringLength(40, MinimumLength = 4, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string Password { get; set; } = string.Empty;
    }
}
