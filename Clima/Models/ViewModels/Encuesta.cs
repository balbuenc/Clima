using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clima.Models.ViewModels
{
    public class Encuesta
    {
        public int IdEncuesta { get; set; }
        public short IdPeriodo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public short Activo { get; set; }
    }
}