using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clima.Models.ViewModels
{
    public class Cuestionario
    {
        public Cuestionario()
        {
            OpcionesSeleccion = new List<OpcionSeleccion>();
        }

        [Key]
        public int IdCuestionario { get; set; }
        [StringLength(250)]
        [Required]
        public string Enunciado { get; set; }
        public int IdDimension { get; set; }
        [Required(ErrorMessage = "Debe seleccionar este campo")]
        public int SelectId { get; set; }       
        public int IsMultiple { get; set; }
        public List<OpcionSeleccion> OpcionesSeleccion { get; set; }
    }
}