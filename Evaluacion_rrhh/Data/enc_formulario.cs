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
    
    public partial class enc_formulario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public enc_formulario()
        {
            this.enc_formulario_pregunta = new HashSet<enc_formulario_pregunta>();
            this.rol_empleado_x_formulario = new HashSet<rol_empleado_x_formulario>();
        }
    
        public decimal IdFormulario { get; set; }
        public int IdPeriodo { get; set; }
        public string ef_codigo { get; set; }
        public string ef_descripcion { get; set; }
        public bool estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<enc_formulario_pregunta> enc_formulario_pregunta { get; set; }
        public virtual tbl_periodo_evaluacion tbl_periodo_evaluacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rol_empleado_x_formulario> rol_empleado_x_formulario { get; set; }
    }
}