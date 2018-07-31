using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Info.general
{
    public class enc_formulario_pregunta_Info
    {
        public int IdPeriodo { get; set; }
        [Key]
        [Required]
        [Display(Name ="ID")]
        public decimal IdPregunta { get; set; }
        [Required]
        [Display(Name = "Formulario")]
        public decimal IdFormulario { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string ep_descripcion { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
        [Display(Name = "Ponderación")]

        public double ep_ponderacion { get; set; }

    }
}