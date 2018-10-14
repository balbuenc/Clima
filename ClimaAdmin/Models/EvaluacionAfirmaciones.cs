namespace ClimaAdmin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EvaluacionAfirmaciones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Evaluacion { get; set; }

        [Required]
        [StringLength(128)]
        public string Descripcion { get; set; }
    }
}
