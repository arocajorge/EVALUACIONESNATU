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
   public class tbl_reporte002_Data
    {
        public List<tbl_reporte002_Info> GetList(int IdPeriodo, decimal IdEmpleado, decimal IdEmpleado_evaluado)
        {
            try
            {
                List<tbl_reporte002_Info> lista = new List<tbl_reporte002_Info>();

                decimal IdEmpleado_ini = IdEmpleado;
                decimal IdEmpleado_fin = IdEmpleado == 0 ? 99999 : IdEmpleado;

                decimal IdEmpleado_evaluado_ini = IdEmpleado_evaluado;
                decimal IdEmpleado_evaluado_fin = IdEmpleado_evaluado == 0 ? 99999 : IdEmpleado_evaluado;

                using (Entities_general contex = new Entities_general())
                {
                    lista = (from emp in contex.vw_reporte002
                             where emp.IdPeriodo == IdPeriodo
                             && IdEmpleado_ini <= emp.IdEmpleado && emp.IdEmpleado <= IdEmpleado_fin
                             && IdEmpleado_evaluado_ini <= emp.Idempleado_evaluado && emp.Idempleado_evaluado <= IdEmpleado_evaluado_fin
                             select new tbl_reporte002_Info
                             {
                                 IdEmpleado = emp.IdEmpleado,
                                 Idempleado_evaluado = emp.Idempleado_evaluado,
                                 re_codigo_eva = emp.re_codigo_eva,
                                 re_apellidos_eva = emp.re_apellidos_eva,
                                 re_nombres_eva = emp.re_apellidos_eva + "  " + emp.re_nombres_eva,
                                 ef_descripcion = emp.ef_descripcion,
                                 ep_descripcion = emp.ep_descripcion,
                                 ef_ponderacion = emp.ef_ponderacion,
                                 ef_calificacion = emp.ef_calificacion,
                                 ef_calificacion_ponderacion = emp.ef_calificacion_ponderacion,
                                 re_ponderacion = emp.re_ponderacion,
                                 ep_ponderacion = emp.ep_ponderacion,
                                 re_cedula = emp.re_cedula,
                                 re_codigo = emp.re_codigo,
                                 re_apellidos = emp.re_apellidos,
                                 re_nombres = emp.re_apellidos + "  " + emp.re_nombres,
                                 Ponderacion_x_pregunta = emp.Ponderacion_x_pregunta,
                                 Calificacion = emp.Calificacion
                                 

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
