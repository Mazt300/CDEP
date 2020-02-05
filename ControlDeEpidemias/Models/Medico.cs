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
    
    public partial class Medico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medico()
        {
            this.clasificacion_paciente_epidemia = new HashSet<clasificacion_paciente_epidemia>();
            this.consultorio_medico = new HashSet<consultorio_medico>();
            this.detalleExpediente = new HashSet<detalleExpediente>();
            this.Examen = new HashSet<Examen>();
            this.OrdenDeExamen = new HashSet<OrdenDeExamen>();
            this.receta_medica = new HashSet<receta_medica>();
        }
    
        public int idmedico { get; set; }
        public Nullable<int> idempleado { get; set; }
        public Nullable<bool> estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<clasificacion_paciente_epidemia> clasificacion_paciente_epidemia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<consultorio_medico> consultorio_medico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleExpediente> detalleExpediente { get; set; }
        public virtual Empleado Empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Examen> Examen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenDeExamen> OrdenDeExamen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<receta_medica> receta_medica { get; set; }
    }
}