using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Info.general
{
    public class enc_resolucion_formulario_det_Info
    {
        public decimal IdResolucion { get; set; }
        public int secuencia { get; set; }
        public decimal IdPregunta { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public Nullable<double> re_ponderacion { get; set; }
        public string ep_descripcion { get; set; }

    }
}