using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class Docente
    {
        [Key]
        public int Docente_Id { get; set; }

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
