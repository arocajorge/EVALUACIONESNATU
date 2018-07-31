using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Info.general
{
    public class rol_empleado_Info
    {
        public int IdEmpresa { get; set; }
        public decimal IdEmpleado { get; set; }
        [Display(Name ="Codigo")]
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
        [Required]
        [Display(Name = "Cargo")]

        public int IdCargo { get; set; }
        public bool estado { get; set; }
        public string formulario { get; set; }
        public decimal IdFormulario { get; set; }
        public decimal IdEmpleado_eva { get; set; }
        public int IdPeriodo { get; set; }
        public string Cargo { get; set; }
        public DateTime fechaI { get; set; }
        public DateTime fechaF { get; set; }
        public int num_empleado_asignados { get; set; }
        public int num_emo_lo_evaluan { get; set; }

        public double? sum_ponderacion { get; set; }
        public string NombreCompleato { get; set; }

    }
}