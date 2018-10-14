namespace ClimaAdmin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Encuestas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Encuestas()
        {
            AsignacionesEmpresas = new HashSet<AsignacionesEmpresas>();
            EncuestaPreguntas = new HashSet<EncuestaPreguntas>();
        }

        public short IdPeriodo { get; set; }

        [Required]
        [StringLength(128)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(4000)]
        public string Descripcion { get; set; }

        public short Activo { get; set; }

        [Key]
        public int IdEncuesta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AsignacionesEmpresas> AsignacionesEmpresas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EncuestaPreguntas> EncuestaPreguntas { get; set; }

        public virtual Periodos Periodos { get; set; }
    }
}
