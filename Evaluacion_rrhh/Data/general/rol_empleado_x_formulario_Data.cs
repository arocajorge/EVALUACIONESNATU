using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.general;
namespace Data.general
{
   public class rol_empleado_x_formulario_Data
    {

        public bool guardarDB(rol_empleado_x_formulario_Info info)
        {
            try
            {
                tbl_periodo_evaluacion_Data i_periodo =new tbl_periodo_evaluacion_Data();
                int idperiodo = i_periodo.GetInfoPeriodoActivo().IdPeriodo;
                using (Entities_general Context = new Entities_general())
                {

                    rol_empleado_x_formulario Entity = new rol_empleado_x_formulario();

                    Entity.Idempleado = info.Idempleado;
                    Entity.Idempleado_evaluado = info.Idempleado_evaluado;
                    Entity.ef_ponderacion = info.ef_ponderacion;
                    Entity.IdFormulario = info.IdFormulario;
                    Entity.IdPeriodo = info.IdPeriodo;
                    Entity.Secuencia = GetSecuencia(info.Idempleado);
                    Context.rol_empleado_x_formulario.Add(Entity);
                    Context.SaveChanges();

                }

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool modificarDB(rol_empleado_x_formulario_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    var Entity = Context.rol_empleado_x_formulario.Where(v => v.Idempleado == info.Idempleado && v.Secuencia == info.Secuancia).FirstOrDefault();
                    if (Entity != null)
                    {
                        Entity.Idempleado_evaluado = info.Idempleado_evaluado;
                        Entity.ef_ponderacion = info.ef_ponderacion;
                        Entity.IdFormulario = info.IdFormulario;
                        Context.SaveChanges();
                    }

                }

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool anularDB(rol_empleado_x_formulario_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    var Entity = Context.rol_empleado_x_formulario.Where(v => v.Idempleado == info.Idempleado && v.Secuencia == info.Secuancia).FirstOrDefault();

                    if (Entity != null)
                    {
                        Entity.Idempleado_evaluado = info.Idempleado_evaluado;
                        Entity.ef_ponderacion = info.ef_ponderacion;
                        Entity.IdFormulario = info.IdFormulario;
                        Context.rol_empleado_x_formulario.Remove(Entity);
                        Context.SaveChanges();
                    }

                }

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private int GetSecuencia(decimal IdEmpleado)
        {
            try
            {
                using (Entities_general contex = new Entities_general())
                {
                    var selec = (from q in contex.rol_empleado_x_formulario
                                 where q.Idempleado == IdEmpleado
                                 select q);
                    if (selec.Count() == 0)
                        return 1;
                    else
                        return (from q in contex.rol_empleado_x_formulario
                                select q.Secuencia).Max() + 1;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<rol_empleado_x_formulario_Info> GetListadoAsignaciones()
            {
            try
            {
                
                List<rol_empleado_x_formulario_Info> lista = new List<rol_empleado_x_formulario_Info>();
                using (Entities_general contex=new Entities_general())
                {

                    lista = (from emp_evalua in contex.rol_empleado
                             join emp_x_form in contex.rol_empleado_x_formulario
                             on emp_evalua.IdEmpleado equals emp_x_form.Idempleado

                             join emp_evaluado in contex.rol_empleado
                             on emp_x_form.Idempleado_evaluado equals emp_evaluado.IdEmpleado

                             join periodo in contex.tbl_periodo_evaluacion
                             on emp_x_form.IdPeriodo equals periodo.IdPeriodo

                             join formulario in contex.enc_formulario
                             on emp_x_form.IdFormulario equals formulario.IdFormulario

                             join preguntas in contex.enc_formulario_pregunta
                             on formulario.IdFormulario equals preguntas.IdFormulario
                             // where emp_evalua.IdEmpleado==Idempleado
                             select new rol_empleado_x_formulario_Info
                             {
                                 Idempleado = emp_evalua.IdEmpleado,
                                 Idempleado_evaluado = emp_evaluado.IdEmpleado,
                                 IdPeriodo = periodo.IdPeriodo,
                                 IdFormulario = formulario.IdFormulario,

                                 re_codigo = emp_evalua.re_codigo,
                                 re_apellidos = emp_evalua.re_apellidos,
                                 re_nombres = emp_evalua.re_nombres,
                                 re_cedula = emp_evalua.re_cedula,

                                 re_codigo_ev = emp_evaluado.re_codigo,
                                 re_apellidos_ev = emp_evaluado.re_apellidos,
                                 re_nombres_ev = emp_evaluado.re_nombres,
                                 ep_descripcion_ev = preguntas.ep_descripcion,
                                 formulario_ev=formulario.ef_descripcion




                             }
                             
                        ).ToList();

                }
                
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<rol_empleado_x_formulario_Info> GetListEmp_Asignados(decimal? IdEmpleado, int IdPeriodo)
        {
            try
            {

                List<rol_empleado_x_formulario_Info> lista = new List<rol_empleado_x_formulario_Info>();
                using (Entities_general entity = new Entities_general())
                {

                    lista = (from q in entity.rol_empleado_x_formulario
                             join empleado in entity.rol_empleado
                             on q.Idempleado_evaluado equals empleado.IdEmpleado
                             where q.Idempleado == IdEmpleado
                             && q.IdPeriodo == IdPeriodo
                             select new rol_empleado_x_formulario_Info
                             {
                                 Idempleado = q.Idempleado,
                                 Idempleado_evaluado = q.Idempleado_evaluado,
                                 IdFormulario = q.IdFormulario,
                                 ef_ponderacion = q.ef_ponderacion,
                                 Secuancia = q.Secuencia,
                                 re_codigo_ev=empleado.re_codigo,
                                 re_apellidos_ev=empleado.re_apellidos,
                                 re_nombres_ev=empleado.re_nombres

                             }

                        ).ToList();

                }
                return lista;
            }
            catch (Exception)
            {

                return new List<rol_empleado_x_formulario_Info>();
            }
        }
        public rol_empleado_x_formulario_Info empleado_x_formulario_Partial()
        {
            try
            {
                rol_empleado_x_formulario_Info modelInfo = new rol_empleado_x_formulario_Info();
                using (Entities_general model = new Entities_general())
                {

                    modelInfo.lista = (from q in model.rol_empleado
                                       where
                                       q.estado == true

                                       select new rol_empleado_Info
                                       {
                                           IdEmpleado = q.IdEmpleado,
                                           re_codigo = q.re_codigo,
                                           re_apellidos = q.re_apellidos,
                                           re_nombres = q.re_nombres,
                                           re_cedula = q.re_cedula,
                                           re_correo = q.re_correo,
                                           re_telefonos = q.re_telefonos,
                                           re_direccion = q.re_direccion,
                                           IdCargo = q.IdCargo,
                                           estado = q.estado,
                                           num_empleado_asignados = (from emp_x_f in model.rol_empleado_x_formulario
                                                                     join per in model.tbl_periodo_evaluacion
                                                                     on emp_x_f.IdPeriodo equals per.IdPeriodo
                                                                     where emp_x_f.Idempleado == q.IdEmpleado
                                                                     && per.estado_cierre == false
                                                                     select emp_x_f.Idempleado).Count(),

                                           num_emo_lo_evaluan = (from emp_x_f in model.rol_empleado_x_formulario
                                                                     join per in model.tbl_periodo_evaluacion
                                                                     on emp_x_f.IdPeriodo equals per.IdPeriodo
                                                                     where emp_x_f.Idempleado_evaluado == q.IdEmpleado
                                                                     && per.estado_cierre == false
                                                                     select emp_x_f.Idempleado).Count(),

                                           sum_ponderacion = (from emp_x_f in model.rol_empleado_x_formulario
                                                                     join per in model.tbl_periodo_evaluacion
                                                                     on emp_x_f.IdPeriodo equals per.IdPeriodo
                                                                     where emp_x_f.Idempleado_evaluado == q.IdEmpleado
                                                                     && per.estado_cierre == false
                                                                     select emp_x_f.ef_ponderacion).Sum()


                                       }


                              ).ToList();
                }

                return modelInfo;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public rol_empleado_x_formulario_Info GetInfo(decimal? IdEmpleado, int IdPeriodo)
        {
            try
            {
                rol_empleado_x_formulario_Info info = new rol_empleado_x_formulario_Info();
                using (Entities_general entity = new Entities_general())
                {

                    info.lista_emp_x_form = (from q in entity.rol_empleado_x_formulario
                             join empleado in entity.rol_empleado
                             on q.Idempleado equals empleado.IdEmpleado
                             join formulario in entity.enc_formulario
                             on q.IdFormulario equals formulario.IdFormulario
                             where q.Idempleado == IdEmpleado && q.IdPeriodo == IdPeriodo
                             select new rol_empleado_x_formulario_Info
                             {
                                 Idempleado = q.Idempleado,
                                 Idempleado_evaluado = q.Idempleado_evaluado,
                                 IdFormulario = q.IdFormulario,
                                 ef_ponderacion = q.ef_ponderacion,
                                 Secuancia = q.Secuencia,
                                 re_codigo_ev = empleado.re_codigo,
                                 re_apellidos_ev = empleado.re_apellidos,
                                 re_nombres_ev = empleado.re_nombres,
                                 re_nombre_completo_ev = empleado.re_apellidos + " " + empleado.re_nombres,
                                 formulario_ev = formulario.ef_descripcion
                             }

                        ).ToList();

                }
                return info;
            }
            catch (Exception)
            {

                return new rol_empleado_x_formulario_Info();
            }
        }

        public rol_empleado_x_formulario_Info GetInfo_ponderar(decimal? IdEmpleado, int IdPeriodo)
        {
            try
            {
                rol_empleado_x_formulario_Info info = new rol_empleado_x_formulario_Info();
                using (Entities_general entity = new Entities_general())
                {

                    info.lista_emp_x_form = (from q in entity.rol_empleado_x_formulario
                                             join empleado in entity.rol_empleado
                                             on q.Idempleado equals empleado.IdEmpleado
                                             join formulario in entity.enc_formulario
                                             on q.IdFormulario equals formulario.IdFormulario
                                             where q.Idempleado_evaluado == IdEmpleado
                                             && q.IdPeriodo == IdPeriodo
                                             && formulario.estado==true
                                             &&formulario.IdPeriodo==IdPeriodo
                                             select new rol_empleado_x_formulario_Info
                                             {
                                                 Idempleado = q.Idempleado,
                                                 Idempleado_evaluado = q.Idempleado_evaluado,
                                                 IdFormulario = q.IdFormulario,
                                                 ef_ponderacion = q.ef_ponderacion,
                                                 Secuancia = q.Secuencia,
                                                 re_codigo_ev = empleado.re_codigo,
                                                 re_apellidos_ev = empleado.re_apellidos,
                                                 re_nombres_ev = empleado.re_nombres,
                                                 re_nombre_completo_ev = empleado.re_apellidos + " " + empleado.re_nombres,
                                                 formulario_ev = formulario.ef_descripcion
                                             }

                        ).ToList();

                }
                return info;
            }
            catch (Exception)
            {

                return new rol_empleado_x_formulario_Info();
            }
        }

        public bool modificar_ponderacionDB(rol_empleado_x_formulario_Info info)
        {
            try
            {
                using (Entities_general Context = new Entities_general())
                {
                    var Entity = Context.rol_empleado_x_formulario.Where(v => v.Idempleado == info.Idempleado && v.Secuencia == info.Secuancia && v.Idempleado_evaluado==info.Idempleado_evaluado).FirstOrDefault();
                    if (Entity != null)
                    {
                        Entity.ef_ponderacion = info.ef_ponderacion;
                        Context.SaveChanges();
                    }

                }

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
