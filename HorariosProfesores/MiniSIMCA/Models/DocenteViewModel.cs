using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MiniSIMCA.Models
{
    public class DocenteViewModel
    {

        public string Id { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(100, ErrorMessage = "El el máximo de caracteres es de {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Docente_Nombres { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(100, ErrorMessage = "El el máximo de caracteres es de {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Docente_Apellidos { get; set; }

        [Display(Name = "Tipo de identificación")]
        //[Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un tipo de identificación")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string TipoIdentificacionId { get; set; }

        public IEnumerable<SelectListItem> TiposIdentificacion { get; set; }

        [Display(Name = "Identificación")]
        [MaxLength(10, ErrorMessage = "El el máximo de caracteres es de {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Docente_Identificacion { get; set; }

        [Display(Name = "Tipo docente")]
        //[Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un tipo de docente")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string TipoDocenteId { get; set; }

        public IEnumerable<SelectListItem> TipoDocentes { get; set; }

        [Display(Name = "Tipo de contrato")]
        //[Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un contrato")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string ContratoId { get; set; }

        public IEnumerable<SelectListItem> TipoContratos { get; set; }

        [Display(Name = "Area Docente")]
        [MaxLength(100, ErrorMessage = "El el máximo de caracteres es de {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Docente_Area { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo válido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Docente_Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caractéres.")]
        public string Docente_Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmación de contraseña")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Compare("Docente_Password", ErrorMessage = "Las contraseñas no son iguales")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caractéres.")]
        public string Docente_PasswordConfirm { get; set; }

        [Display(Name = "Estado")]
        public bool IsActive { get; set; }
    }
}
