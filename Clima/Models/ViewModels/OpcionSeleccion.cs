namespace Clima.Models.ViewModels
{
    public class OpcionSeleccion
    {
        public int IdSeleccion { get; set; }
        public string Descripcion { get; set; }
        public bool Checkeado { get; set; }
        public string Respuesta { get; set; }

        public long Id { get; set; }

        public virtual Cuestionario SeleccionMultiples { get; set; }
    }
}