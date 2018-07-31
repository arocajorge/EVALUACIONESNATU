using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.reportes
{
   public class tbl_reporte002_Info
    {
        [Display(Name ="Empleado evaluador")]
        public decimal? IdEmpleado { get; set; }
        [Display(Name ="Codigo evaluado")]
        public string re_codigo_eva { get; set; }
        [Display(Name = "Apellido evaluado")]
        public string re_apellidos_eva { get; set; }
        [Display(Name = "Nombres evaluado")]
        public string re_nombres_eva { get; set; }
        [Display(Name = "Formulario")]
        public string ef_descripcion { get; set; }
        [Display(Name = "Pregunta")]
        public string ep_descripcion { get; set; }
        [Display(Name = "Peso evaluador")]

        public double ef_ponderacion { get; set; }
        [Display(Name = "Calificacion")]

        public Nullable<double> ef_calificacion { get; set; }
        [Display(Name = "Calificacion ponderacion")]

        public Nullable<double> ef_calificacion_ponderacion { get; set; }
        [Display(Name = "Respuesta")]
        public Nullable<double> re_ponderacion { get; set; }
        [Display(Name = "Calificación [0-100]")]

        public double ep_ponderacion { get; set; }
        public string re_cedula { get; set; }
        [Display(Name = "Codigo")]

        public string re_codigo { get; set; }
        [Display(Name = "Apellidos")]

        public string re_apellidos { get; set; }
        [Display(Name = "Nombres evaluador")]

        public string re_nombres { get; set; }
        [Display(Name = "Ponderacion x pregunta")]

        public Nullable<double> Ponderacion_x_pregunta { get; set; }
        [Display(Name = "Empleado evaluado")]
        public decimal? Idempleado_evaluado { get; set; }
        public double Calificacion { get; set; }
        public string pe_descripcion { get; set; }

        [Display(Name = "Periodo")]
        public int? IdPeriodo { get; set; }
    }
}
