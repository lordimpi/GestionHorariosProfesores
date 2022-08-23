using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MiniSIMCA.Models
{
    public class AmbienteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(100, ErrorMessage = "El máximo de caractéres para el campo {0} es de {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        [Display(Name = "Ubicación")]
        [MaxLength(100, ErrorMessage = "El máximo de caractéres para el campo {0} es de {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Ubicacion { get; set; }

        [Display(Name = "Tipo de Ambiente")]
        //[Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un tipo de Ambiente")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string TipoAmbiente { get; set; }

        public IEnumerable<SelectListItem> TipoAmbientes { get; set; }

        [Display(Name = "Capacidad")]
        [Range(1, 50, ErrorMessage = "La capacidad máxima es de 50 aprendices")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Capacidad { get; set; }

        [Display(Name = "Estado")]
        public bool IsActive { get; set; }

        public string Estado => IsActive ? "Activo" : "Desactivo";
    }
}
