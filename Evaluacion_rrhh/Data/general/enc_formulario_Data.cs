using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.general;
namespace Data.general
{
  public  class enc_formulario_Data
    {
        
        private decimal GetId()
        {
            try
            {
                using (Entities_general entyti = new Entities_general())
                {
                    var selec = (from q in entyti.enc_formulario
                                 select q);

                    if (selec.Count() == 0)
                        return 1;
                    else
                        return (from q in entyti.enc_formulario
                                select q.IdFormulario).Max() + 1;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public enc_formulario_Info get_info(decimal IdFormulario)
        {
            try
            {
                enc_formulario_Info info = new enc_formulario_Info();

                using (Entities_general Context = new Entities_general())
                {
                    enc_formulario q = Context.enc_formulario.FirstOrDefault(v => v.IdFormulario == IdFormulario);
                    if (q == null) return null;
                    info = new enc_formulario_Info
                    {
                        IdFormulario = q.IdFormulario,
                        ef_codigo = q.ef_codigo,
                        ef_descripcion = q.ef_descripcion,
                        IdPeriodo = q.IdPeriodo,
                        estado = q.estado
                    };
                }

                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<enc_formulario_Info> get_list(int IdPeriodo)
        {
            try
            {
                List<enc_formulario_Info> listaFormularios = new List<enc_formulario_Info>();
                using (Entities_general contex = new Entities_general())
                {

                    listaFormularios = (from q in contex.enc_formulario
                                        where q.IdPeriodo == IdPeriodo &&
                                         q.estado == true
                                        select new enc_formulario_Info
                                        {
                                            IdFormulario = q.IdFormulario,
                                            IdPeriodo = q.IdPeriodo,
                                            ef_descripcion = q.ef_descripcion,
                                            ef_codigo = q.ef_codigo,
                                            estado = q.estado
                                        }
                              ).ToList();
                }

                return listaFormularios;

            }
            catch (Exception ex)
            {
                return new List<enc_formulario_Info>();
            }
        }

        public bool grabarDB(enc_formulario_Info info)
        {
            try
            {
                tbl_periodo_evaluacion_Info info_periodo = new tbl_periodo_evaluacion_Info();
                tbl_periodo_evaluacion_Data periodo_data = new tbl_periodo_evaluacion_Data();
                info_periodo = periodo_data.GetInfoPeriodoActivo();
                using (Entities_general contex = new Entities_general())
                {
                    enc_formulario addnew = new enc_formulario();
                    addnew.IdFormulario = GetId();
                    addnew.ef_codigo = (info.ef_codigo)==null?"": info.ef_codigo;
                    addnew.ef_descripcion = info.ef_descripcion;
                    addnew.IdPeriodo = info_periodo.IdPeriodo;
                    addnew.estado = true;
                    contex.enc_formulario.Add(addnew);
                    contex.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool anularDB(enc_formulario_Info info)
        {
            try
            {
                using (Entities_general contex = new Entities_general())
                {
                    var addnewC = contex.enc_formulario.Where(v => v.IdFormulario == info.IdFormulario).FirstOrDefault();

                    if (addnewC != null)
                    {
                        addnewC.estado = false;
                        contex.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(enc_formulario_Info info)
        {
            try
            {
                using (Entities_general contex = new Entities_general())
                {
                    var addnewC = contex.enc_formulario.Where(v => v.IdFormulario == info.IdFormulario).FirstOrDefault();

                    if (addnewC != null)
                    {
                        addnewC.ef_descripcion = info.ef_descripcion;
                        addnewC.ef_codigo = info.ef_codigo;
                        contex.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<enc_formulario_Info> get_list_migracion(int IdPeriodo)
        {
            try
            {
                List<enc_formulario_Info> Lista = new List<enc_formulario_Info>();

                using (Entities_general Context = new Entities_general())
                {
                    Lista = (from q in Context.enc_formulario
                             where q.estado == true && q.IdPeriodo == IdPeriodo
                             select new enc_formulario_Info
                             {
                                 IdFormulario = q.IdFormulario,
                                 IdPeriodo = q.IdPeriodo,
                                 ef_descripcion = q.ef_descripcion,
                                 ef_codigo = q.ef_codigo,
                                 estado = q.estado
                             }).ToList();

                    enc_formulario_pregunta_Data data_p = new enc_formulario_pregunta_Data();
                    foreach (var item in Lista)
                    {
                        item.listaPreguntas = data_p.get_list(item.IdFormulario);
                    }
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool grabarDB_migracion(List<enc_formulario_Info> Lista, int IdPeriodo)
        {
            try
            {
                enc_formulario_pregunta_Data data_p = new enc_formulario_pregunta_Data();
                using (Entities_general Context = new Entities_general())
                {
                    foreach (var item in Lista)
                    {
                        enc_formulario Entity = new enc_formulario
                        {
                            IdFormulario = item.IdFormulario = GetId(),
                            ef_codigo = (item.ef_codigo) == null ? "" : item.ef_codigo,
                            ef_descripcion = item.ef_descripcion,
                            IdPeriodo = IdPeriodo,
                            estado = true,
                        };
                        Context.enc_formulario.Add(Entity);
                        Context.SaveChanges();
                        foreach (var item_p in item.listaPreguntas)
                        {
                            item_p.IdFormulario = item.IdFormulario;
                            item_p.IdPeriodo = item.IdPeriodo;
                            data_p.guardarDB(item_p);
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
