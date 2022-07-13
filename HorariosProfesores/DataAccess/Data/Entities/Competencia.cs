using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class Competencia
    {
        [Key]
        public int Competencia_Id { get; set; }

        [Display(Name = "Nombre competencia")]
        [MaxLength(100,ErrorMessage ="La cantidad máxima de caractéres es {1}")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Competencia_Nombre { get; set; }

        [Display(Name = "Estado")]
        public bool IsActive { get; set; }

        [JsonIgnore]
        public Programa Programa { get; set; }

        public string Estado => IsActive ? "Activo" : "Desactivo";
    }
}
