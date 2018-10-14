namespace ClimaAdmin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EncuestaPreguntas
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdEncuesta { get; set; }

        public int IdDimension { get; set; }

        public short IdTipoPregunta { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdAfirmacion { get; set; }

        public virtual Afirmaciones Afirmaciones { get; set; }

        public virtual Dimensiones Dimensiones { get; set; }

        public virtual Encuestas Encuestas { get; set; }

        public virtual TipoPreguntas TipoPreguntas { get; set; }
    }
}
