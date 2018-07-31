using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.general;
namespace Data.general
{
  public  class enc_resolucion_formulario_Data
    {
        public bool grabarDB(enc_resolucion_formulario_Info info, ref decimal IdResolucion)
        {
            try
            {
                tbl_periodo_evaluacion_Data Periodo_data = new tbl_periodo_evaluacion_Data();
                tbl_periodo_evaluacion_Info infoPeriodo = new tbl_periodo_evaluacion_Info();
                infoPeriodo = Periodo_data.GetInfoPeriodoActivo();
                using (Entities_general contex = new Entities_general())
                {

                    enc_resolucion_formulario addnew = new enc_resolucion_formulario();
                    addnew.IdEmpleado = info.IdEmpleado;
                    addnew.IdEmpleado_evaluado = info.IdEmpleado_evaluado;
                    addnew.IdPeriodo = infoPeriodo.IdPeriodo;
                    addnew.re_fecha = DateTime.Now;
                    addnew.IdResolucion = GetId();
                    contex.enc_resolucion_formulario.Add(addnew);
                    contex.SaveChanges();
                    IdResolucion = addnew.IdResolucion;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public enc_resolucion_Info GetResolver_evaluacion(decimal? IdEmpleado, int IdPeriodo)
        {
            try
            {
                enc_resolucion_Info info = new enc_resolucion_Info();
                List<enc_resolucion_formulario_Info> listaresolu = new List<enc_resolucion_formulario_Info>();
                List<enc_resolucion_formulario_det_Info> lista_det = new List<enc_resolucion_formulario_det_Info>();
                using (Entities_general contex = new Entities_general())
                {

                    listaresolu = (from emp_evalua in contex.rol_empleado
                            join emp_x_form in contex.rol_empleado_x_formulario
                            on emp_evalua.IdEmpleado equals emp_x_form.Idempleado_evaluado

                            join formulario in contex.enc_formulario
                            on emp_x_form.IdFormulario equals formulario.IdFormulario
                            where emp_x_form.Idempleado==IdEmpleado
                            && emp_x_form.IdPeriodo == IdPeriodo
                           && formulario.IdPeriodo == IdPeriodo

                            select new enc_resolucion_formulario_Info
                            {
                                IdEmpleado = emp_x_form.Idempleado,
                                IdEmpleado_evaluado = emp_x_form.Idempleado_evaluado,
                                re_nombres = emp_evalua.re_nombres+" "+emp_evalua.re_apellidos,
                                lista = (from preg in contex.enc_formulario_pregunta
                                         join peri in contex.tbl_periodo_evaluacion
                                         on emp_x_form.IdPeriodo equals peri.IdPeriodo
                                         
                                         where preg.IdFormulario == emp_x_form.IdFormulario
                                         && preg.IdFormulario==formulario.IdFormulario
                                         && peri.estado_cierre==false
                                         && peri.estado==true
                                         && preg.estado == true
                                         && !contex.enc_resolucion_formulario.Any(v=>v.IdEmpleado==IdEmpleado && v.IdPeriodo==emp_x_form.IdPeriodo)
                                         && preg.IdPeriodo == IdPeriodo
                                         && peri.IdPeriodo == IdPeriodo
                                         select new enc_resolucion_formulario_det_Info
                                         {
                                             IdPregunta = preg.IdPregunta,
                                             ep_descripcion = preg.ep_descripcion,
                                             re_ponderacion = 0,
                                             
                                             }).ToList()

                             }

                ).ToList();
                }
                info.lista_resoluccion = listaresolu;
                return  info;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private decimal GetId()
        {
            try
            {
                using (Entities_general contex = new Entities_general())
                {
                    var selec = (from q in contex.enc_resolucion_formulario
                                 select q);

                    if (selec.Count() == 0)
                        return 1;
                    else
                        return (from q in contex.enc_resolucion_formulario
                                select q.IdResolucion).Max() + 1;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool empleado_realizo_encuesta(decimal IdEmpleado, int IdPeriodo)
        {
            using (Entities_general Context = new Entities_general())
            {
                var lst  =from q in Context.enc_resolucion_formulario
                        where q.IdEmpleado == IdEmpleado && q.IdPeriodo == IdPeriodo
                        select q;

                if (lst.Count() > 0)
                    return true;
            }
            return false;
        }
    }
}
