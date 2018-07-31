using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Info.general
{
    public class rol_cargo_Info
    {
        public int IdEmpresa { get; set; }
        public int IdCargo { get; set; }
        [Display(Name ="Codigo")]
        public string rc_codigo { get; set; }
        [Display(Name = "Descripción")]
        [Required]
        public string rc_descripcion { get; set; }
        public bool estado { get; set; }

    }
}