using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Info.general
{
    public class tbl_periodo_evaluacion_Info
    {
        public int IdPeriodo { get; set; }
        [Display(Name ="Fecha Apertura")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "El campo fecha apertura es obligatorio")]

        public System.DateTime pe_fecha_ini { get; set; }
        [Display(Name = "Fecha cierre")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "El campo fecha cierre es obligatorio")]

        public System.DateTime pe_fecha_fin { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El campo fecha descripción es obligatorio")]
        public string pe_observacion { get; set; }
        [Display(Name = "Cerrado)")]
        public bool estado_cierre { get; set; }

        public bool estado { get; set; }
    }
}