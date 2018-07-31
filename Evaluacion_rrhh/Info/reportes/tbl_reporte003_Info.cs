using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.reportes
{
   public class tbl_reporte003_Info
    {
        public long IdRow { get; set; }
        [Display(Name ="Periodo")]
        public Nullable<int> IdPeriodo { get; set; }
        public int Secuencia { get; set; }
        [Display(Name ="Empleado evaluador")]
        public Nullable<decimal> Idempleado { get; set; }
        [Display(Name = "Empleado evaluado")]
        public Nullable<decimal> Idempleado_evaluado { get; set; }
        public string emp_evaluador { get; set; }
        public string emp_evaluado { get; set; }
        public string ef_descripcion { get; set; }
        public double ef_ponderacion { get; set; }
        public Nullable<double> ef_calificacion { get; set; }
        public Nullable<double> ef_calificacion_ponderacion { get; set; }
    }
}
