//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class enc_formulario_pregunta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public enc_formulario_pregunta()
        {
            this.enc_resolucion_formulario_det = new HashSet<enc_resolucion_formulario_det>();
        }
    
        public decimal IdPregunta { get; set; }
        public int IdPeriodo { get; set; }
        public decimal IdFormulario { get; set; }
        public string ep_descripcion { get; set; }
        public bool estado { get; set; }
        public double ep_ponderacion { get; set; }
        public Nullable<double> ep_calificacion { get; set; }
    
        public virtual enc_formulario enc_formulario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<enc_resolucion_formulario_det> enc_resolucion_formulario_det { get; set; }
    }
}
