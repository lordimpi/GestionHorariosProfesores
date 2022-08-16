using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MiniSIMCA.Models
{
    public class CreatePeriodoAcademicoViewModel : EditPeriodoAcademicoViewModel
    {
        [Display(Name = "Programas")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un programa")]
        [Required(ErrorMessage ="Seleccione un programa")]
        public int Programa_Id { get; set; }

        public IEnumerable<SelectListItem> Programas { get; set; }
    }
}
