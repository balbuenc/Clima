//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clima.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dimensiones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dimensiones()
        {
            this.Afirmaciones = new HashSet<Afirmaciones>();
            this.Preguntas = new HashSet<Preguntas>();
            this.SeleccionMultiples = new HashSet<SeleccionMultiples>();
        }
    
        public int IdDimension { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Afirmaciones> Afirmaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Preguntas> Preguntas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeleccionMultiples> SeleccionMultiples { get; set; }
    }
}
