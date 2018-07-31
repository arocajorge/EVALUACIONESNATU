using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.general
{
   public class enc_resolucion_calificacion_Info
    {
        public decimal IdEmpleado { get; set; }
        public int IdPeriodo { get; set; }
        public double Calificacion { get; set; }
        public bool factor_cumplimiento { get; set; }
        public double calificacion_final { get; set; }


        [Display(Name = "Codigo")]
        public string re_codigo { get; set; }
        [Display(Name = "Apellidos")]

        [Required]
        public string re_apellidos { get; set; }
        [Display(Name = "Nombres")]

        [Required]
        public string re_nombres { get; set; }
        [Display(Name = "Cédula")]

        [Required]
        public string re_cedula { get; set; }
        [Display(Name = "Correo electronico")]

        [Required]
        public string re_correo { get; set; }
        [Display(Name = "Teléfonos")]

        public string re_telefonos { get; set; }
        [Display(Name = "Dirección")]

        public string re_direccion { get; set; }
    }
}
