//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlDeEpidemias.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Examen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Examen()
        {
            this.detalleExpediente = new HashSet<detalleExpediente>();
        }
    
        public int idexamen { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> idordenexamen { get; set; }
        public Nullable<int> idLaboratorio { get; set; }
        public Nullable<int> idmedico { get; set; }
        public Nullable<System.DateTime> FechaRealizacion { get; set; }
        public Nullable<bool> estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleExpediente> detalleExpediente { get; set; }
        public virtual Laboratorio Laboratorio { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual OrdenDeExamen OrdenDeExamen { get; set; }
    }
}
