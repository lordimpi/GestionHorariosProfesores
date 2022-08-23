using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data.Entities
{
    public class Ambiente
    {
        public int Id { get; set; }
        
        [Display(Name ="Nombre")]
        [MaxLength(100,ErrorMessage ="El máximo de caractéres para el campo {0} es de {1}")]
        [Required(ErrorMessage ="El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        [Display(Name ="Ubicación")]
        [MaxLength(100, ErrorMessage = "El máximo de caractéres para el campo {0} es de {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Ubicacion { get; set; }

        [Display(Name ="Tipo de Ambiente")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string TipoAmbiente { get; set; }

        [Display(Name ="Capacidad")]
        [Range(1,50,ErrorMessage ="La capacidad máxima es de 50 aprendices")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Capacidad { get; set; }
        
        [Display(Name ="Estado")]        
        public bool IsActive { get; set; }

        //Reltaions
        public ICollection<Horario> Horario { get; set; }
    }
}
