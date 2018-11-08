using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clima.Models.ViewModels
{
    public class TipoPregunta
    {
        public TipoPregunta() {
            Cuestionarios = new List<Cuestionario>();
        }
    
        public short IdTipoPregunta { get; set; }
        public string Tipo { get; set; }

        public List<Cuestionario> Cuestionarios { get; set; }
    }
}