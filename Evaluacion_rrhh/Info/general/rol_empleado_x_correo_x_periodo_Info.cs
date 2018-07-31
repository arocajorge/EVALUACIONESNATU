using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Info.general
{
    public class rol_empleado_x_correo_x_periodo_Info
    {
        public int IdPeriodo { get; set; }
        public decimal IdEmpleado { get; set; }
        public int Secuencia { get; set; }
        public Nullable<bool> Correo_enviado { get; set; }
        public string Observacion { get; set; }
    }
}