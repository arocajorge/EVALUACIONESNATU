using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.general
{
    public class tbl_usuario_Info
    {
        [Key]
        [Display(Name ="Usuario")]
        [Required]
        public string IdUsuario { get; set; }
        [Display(Name = "Contraseña")]
        [Required]
        public string us_contrasenia { get; set; }
        public bool estado { get; set; }
    }
}
