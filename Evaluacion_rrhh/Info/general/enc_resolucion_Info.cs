using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.general;
namespace Info.general
{
  public  class enc_resolucion_Info
    {
        public List<enc_resolucion_formulario_Info> lista_resoluccion { get; set; }
        public string Concepto { get; set; }
        public enc_resolucion_Info()
        {
            lista_resoluccion = new List<enc_resolucion_formulario_Info>();
        }
    }
}
