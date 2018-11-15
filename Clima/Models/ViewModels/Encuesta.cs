using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clima.Models.ViewModels
{
    public class Encuesta
    {
        public Encuesta()
        {
            EncuestaPreguntas = new List<EncuestaPregunta>();
        }

        [Key]
        public int IdEncuesta { get; set; }

        public short IdPeriodo { get; set; }

        [StringLength(128)]
        [Required]
        public string Nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string Descripcion { get; set; }

        public short Activo { get; set; }

        public List<EncuestaPregunta> EncuestaPreguntas { get; set; }
    }
}