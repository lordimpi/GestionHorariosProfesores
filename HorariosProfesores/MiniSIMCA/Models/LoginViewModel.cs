using System.ComponentModel.DataAnnotations;

namespace MiniSIMCA.Models
{
    public class LoginViewModel
    {
        [Display(Name ="Email")]
        [Required(ErrorMessage ="El campo {0} es obligatorio.")]
        [EmailAddress(ErrorMessage ="Debe ingresar un email válido.")]
        public string UserName { get; set; }

        [Display(Name ="Contraseña")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="El campo {0} el obligatorio.")]
        [MinLength(6, ErrorMessage ="El campo {0} debe tener al menos {1} carácteres")]
        public string Password { get; set; }
        
        [Display(Name ="Recordarme en este navegador")]
        public bool RememberMe { get; set; }
    }
}
