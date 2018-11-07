using System.Collections.Generic;


namespace Clima.Models.ViewModels
{
    public class Cuestionario
    {
        public Cuestionario()
        {
            OpcionesSeleccion = new List<OpcionSeleccion>();
        }

        public int IdCuestionario { get; set; }
        public string Enunciado { get; set; }
        public int IdDimension { get; set; }
        public int CheckId { get; set; }
        public string CheckSeleccionado { get; set; }

        public List<OpcionSeleccion> OpcionesSeleccion { get; set; }
    }
}