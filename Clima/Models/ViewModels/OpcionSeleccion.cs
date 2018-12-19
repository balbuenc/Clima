using System.ComponentModel.DataAnnotations;

namespace Clima.Models.ViewModels
{
    public class OpcionSeleccion
    {

        public long Id { get; set; }
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Debe seleccionar el item")]
        public string Respuesta { get; set; }

        public virtual Cuestionario SeleccionMultiples { get; set; }
    }
}