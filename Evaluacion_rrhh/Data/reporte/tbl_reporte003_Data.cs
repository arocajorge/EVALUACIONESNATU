using Info.reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.reporte
{
  public  class tbl_reporte003_Data
    {
        public List<tbl_reporte003_Info> GetList(int IdPeriodo, decimal IdEmpleado, decimal Idempleado_evaluado)
        {
            try
            {
                decimal IdEmpleadoInicio = IdEmpleado == 0 ? 0 : IdEmpleado;
                decimal IdEmpleadoFin = IdEmpleado == 0 ? 999999 : IdEmpleado;

                decimal Idempleado_evaluadoInicio = Idempleado_evaluado == 0 ? 0 : Idempleado_evaluado;
                decimal Idempleado_evaluadoFin = Idempleado_evaluado == 0 ? 999999 : Idempleado_evaluado;

                List<tbl_reporte003_Info> lista = new List<tbl_reporte003_Info>();
                using (Entities_general contex = new Entities_general())
                {
                    lista = (from emp in contex.vw_reporte003
                             where 
                              emp.IdPeriodo == IdPeriodo

                             && emp.Idempleado >= IdEmpleadoInicio
                             && emp.Idempleado <= IdEmpleadoFin

                             && emp.Idempleado_evaluado >= Idempleado_evaluadoInicio
                             && emp.Idempleado_evaluado <= Idempleado_evaluadoFin

                             select new tbl_reporte003_Info
                             {
                                 IdRow = emp.IdRow,
                                 IdPeriodo = emp.IdPeriodo,
                                 Secuencia = emp.Secuencia,
                                 Idempleado = emp.Idempleado,
                                 Idempleado_evaluado = emp.Idempleado_evaluado,
                                 emp_evaluador = emp.emp_evaluador,
                                 emp_evaluado = emp.emp_evaluado,
                                 ef_descripcion = emp.ef_descripcion,
                                 ef_ponderacion = emp.ef_ponderacion,
                                 ef_calificacion = emp.ef_calificacion,
                                 ef_calificacion_ponderacion = emp.ef_calificacion_ponderacion,
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
