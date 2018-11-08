namespace Clima.Models.ViewModels
{
    public class EncuestaPregunta
    {
        public EncuestaPregunta()
        {
            Encuesta = new Encuesta();
            Cuestionario = new Cuestionario();          
        }

        public long Id { get; set; }
        public int IdEncuesta { get; set; }
        public short IdTipoPregunta { get; set; }
        public int? IdCuestionario { get; set; }

        public virtual Cuestionario Cuestionario { get; set; }
        public virtual TipoPregunta TipoPregunta { get; set; }
        public virtual Encuesta Encuesta { get; set; }
    }
}