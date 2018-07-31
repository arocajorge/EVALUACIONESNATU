using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Info.general
{
    public class enc_resolucion_formulario_Info
    {
        public decimal IdResolucion { get; set; }
        public int IdPeriodo { get; set; }
        public decimal IdEmpleado { get; set; }
        public decimal IdEmpleado_evaluado { get; set; }
        public System.DateTime re_fecha { get; set; }



        public string re_apellidos { get; set; }
        public string re_nombres { get; set; }
        public string ef_descripcion { get; set; }
        public decimal IdFormulario { get; set; }

        public List<enc_resolucion_formulario_det_Info> lista { get; set; }

    }
}