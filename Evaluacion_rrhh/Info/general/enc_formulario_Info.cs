using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Info.general
{
    public class enc_formulario_Info
    {
        [Display(Name ="Periodo")]
        public int IdPeriodo { get; set; }
        public decimal IdFormulario { get; set; }
        [Display(Name = "Codigo")]

        public string ef_codigo { get; set; }
        [Display(Name = "Formulario")]
        [Required]
        public string ef_descripcion { get; set; }
        [Display(Name = "Ponderación")]

        public bool estado { get; set; }

       public List<enc_formulario_pregunta_Info> listaPreguntas;
        [Display(Name ="Periodo")]
        public int? IdPeriodo_migrar { get; set; }
        public enc_formulario_Info()
        {
            listaPreguntas = new List<enc_formulario_pregunta_Info>();
        }
    }
}