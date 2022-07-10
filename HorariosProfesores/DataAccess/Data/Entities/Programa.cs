using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data.Entities
{
    public class Programa
    {
        [Key]
        public int Programa_Id { get; set; }

        [Display(Name = "Nombre del programa")]
        [MaxLength(50, ErrorMessage = "La cantidad máxima de caractéres es de {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Programa_Nombre { get; set; }
    }
}
