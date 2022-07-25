using DataAccess.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataAccess.Data.Entities
{
    public class Competencia
    {
        [Key]
        public int Competencia_Id { get; set; }

        [Display(Name = "Nombre competencia")]
        [MaxLength(100, ErrorMessage = "La cantidad máxima de caractéres es {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Competencia_Nombre { get; set; }

        [Display(Name = "Estado")]
        public bool IsActive { get; set; }

        [Display(Name ="Tipo de competencia")]
        public TipoCompetencia Competencia_Tipo { get; set; }

        [JsonIgnore]
        public Programa Programa { get; set; }

        public string Estado => IsActive ? "Activo" : "Desactivo";
    }
}
