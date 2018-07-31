using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.reporte;
using Data.general;
using Info.reportes;

namespace Data.reporte
{
   public class tbl_reporte001_Data
    {
        public List<tbl_reporte001_Info> GetRpt001(int IdPeriodo)
        {
            try
            {
                List<tbl_reporte001_Info> lista = new List<tbl_reporte001_Info>();

                using (Entities_general contex = new Entities_general())
                {
                    lista = (from emp in contex.rol_empleado
                             join cali in contex.enc_resolucion_calificacion
                             on emp.IdEmpleado equals cali.IdEmpleado
                             where IdPeriodo == cali.IdPeriodo
                             select new tbl_reporte001_Info
                             {
                                 IdEmpleado = emp.IdEmpleado,
                                 IdPeriodo = cali.IdPeriodo,
                                 re_codigo = emp.re_codigo,
                                 re_cedula = emp.re_cedula,
                                 re_apellidos = emp.re_apellidos,
                                 re_nombres = emp.re_nombres,
                                 Calificacion = cali.Calificacion,
                                 factor_cumplimiento = cali.factor_cumplimiento,
                                 calificacion_final = cali.calificacion_final
                             }).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
