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
    
    public partial class detalle_receta_medica
    {
        public int iddetalle_receta_medica { get; set; }
        public Nullable<int> idreceta_medica { get; set; }
        public Nullable<int> idmedicamento { get; set; }
        public string dosis { get; set; }
        public Nullable<bool> estado { get; set; }
    
        public virtual medicamento medicamento { get; set; }
        public virtual receta_medica receta_medica { get; set; }
    }
}