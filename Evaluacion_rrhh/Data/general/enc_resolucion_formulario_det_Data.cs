using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.general;
namespace Data.general
{
  public  class enc_resolucion_formulario_det_Data
    {
        public bool grabardb(List<enc_resolucion_formulario_det_Info> lista)
        {
            try
            {
                int sec = 0;
                using (Entities_general contex = new Entities_general())
                {

                    foreach (var item in lista)
                    {
                        sec++;
                        enc_resolucion_formulario_det addnew = new enc_resolucion_formulario_det();
                        addnew.IdPregunta = item.IdPregunta;
                        addnew.IdResolucion = item.IdResolucion;
                        addnew.re_ponderacion = item.re_ponderacion;
                        addnew.secuencia = sec;
                        contex.enc_resolucion_formulario_det.Add(addnew);
                    }
                    contex.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
