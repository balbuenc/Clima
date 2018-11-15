namespace Clima.Models.ViewModels
{
    public class OpcionSeleccion
    {

        public long Id { get; set; }
        public string Descripcion { get; set; }
        public string Respuesta { get; set; }

        public virtual Cuestionario SeleccionMultiples { get; set; }
    }
}