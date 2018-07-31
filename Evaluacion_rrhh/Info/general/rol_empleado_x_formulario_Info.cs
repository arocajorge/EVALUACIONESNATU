using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Info.general
{
    public class rol_empleado_x_formulario_Info
    {

        public int IdPeriodo { get; set; }
        public int Secuancia { get; set; }
        public decimal Idempleado { get; set; }
        public decimal Idempleado_evaluado { get; set; }
        public decimal IdFormulario { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        public double ef_ponderacion { get; set; }



        public string re_codigo { get; set; }
        public string re_apellidos { get; set; }
        public string re_nombres { get; set; }
        public string cargo { get; set; }
        public string formulario { get; set; }
        public string re_cedula { get; set; }


        public string re_codigo_ev { get; set; }
        public string re_apellidos_ev { get; set; }
        public string re_nombres_ev { get; set; }
        public string ep_descripcion_ev { get; set; }
        public string formulario_ev { get; set; }

        public string re_nombre_completo_ev { get; set; }
        public List<rol_empleado_Info> lista { get; set; }
        public List<enc_formulario_pregunta_Info> lista_preguntas { get; set; }
        public List<rol_empleado_x_formulario_Info> lista_emp_x_form { get; set; }

        public rol_empleado_x_formulario_Info()
        {
            lista = new List<rol_empleado_Info>();
            lista_preguntas = new List<enc_formulario_pregunta_Info>();
            lista_emp_x_form = new List<rol_empleado_x_formulario_Info>();
        }



    }
}