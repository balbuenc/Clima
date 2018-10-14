namespace ClimaAdmin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dimensiones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dimensiones()
        {
            EncuestaPreguntas = new HashSet<EncuestaPreguntas>();
        }

        [Key]
        public int IdDimension { get; set; }

        [Required]
        [StringLength(128)]
        public string Nombre { get; set; }

        [StringLength(1024)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EncuestaPreguntas> EncuestaPreguntas { get; set; }
    }
}
