using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MiniSIMCA.Models
{
    public class EditUserViewModel
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
        [MaxLength(30, ErrorMessage = "El el máximo de caracteres es de {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Docente_TipoIdentificacion { get; set; }

        [Display(Name = "Identificación")]
        [MaxLength(10, ErrorMessage = "El el máximo de caracteres es de {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Docente_Identificacion { get; set; }

        [Display(Name = "Docente Tipo")]
        [MaxLength(30, ErrorMessage = "El el máximo de caracteres es de {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Docente_Tipo { get; set; }

        [Display(Name = "Tipo Contrato Docente")]
        [MaxLength(30, ErrorMessage = "El el máximo de caracteres es de {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Docente_TipoContrato { get; set; }

        [Display(Name = "Area Docente")]
        [MaxLength(100, ErrorMessage = "El el máximo de caracteres es de {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Docente_Area { get; set; }

        [Display(Name = "Estado")]
        public bool IsActive { get; set; }
    }
}
