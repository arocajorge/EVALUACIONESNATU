using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.general;
namespace Data.general
{
   public class enc_resolucion_calificacion_Data
    {
        public List<enc_resolucion_calificacion_Info> GetList_x_periodo(int IdPeriodo)
        {
            try
            {
                List<enc_resolucion_calificacion_Info> lista = new List<enc_resolucion_calificacion_Info>();

                using (Entities_general contex = new Entities_general())
                {
                    lista = (from emp in contex.rol_empleado
                             join cali in contex.enc_resolucion_calificacion
                             on emp.IdEmpleado equals cali.IdEmpleado
                             select new enc_resolucion_calificacion_Info
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

        public List<enc_resolucion_calificacion_Info> GetList_x_usuario(decimal IdEmpleado, int IdPeriodo)
        {
            try
            {
                List<enc_resolucion_calificacion_Info> lista = new List<enc_resolucion_calificacion_Info>();

                using (Entities_general contex = new Entities_general())
                {
                    lista = (from emp in contex.rol_empleado
                             join cali in contex.enc_resolucion_calificacion
                             on emp.IdEmpleado equals cali.IdEmpleado

                             join periodo in contex.tbl_periodo_evaluacion
                             on cali.IdPeriodo equals periodo.IdPeriodo
                             where emp.IdEmpleado== IdEmpleado
                             && cali.IdPeriodo == IdPeriodo
                             select new enc_resolucion_calificacion_Info
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
