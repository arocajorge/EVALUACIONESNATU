using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Info.general
{
    public class tbl_parametros_correo_Info
    {
        public int IdEmpresa { get; set; }
        [Required]
        [Display(Name ="Correo")]
        public string ep_correo { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string ep_contrasenia { get; set; }
        [Display(Name = "Puerto salida")]
        public int ep_puerto { get; set; }
        [Display(Name = "¿Requiere seguridad sll?")]

        public bool ep_permite_sll { get; set; }
        [Display(Name = "Dominio")]

        public string ep_dominio { get; set; }
        [Display(Name = "Observación")]
        public string ep_observacion { get; set; }
    }
}