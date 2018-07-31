using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.general;
namespace Data.general
{
   public class tbl_periodo_evaluacion_Data
    {
        public bool guardarDB(tbl_periodo_evaluacion_Info info)
        {
            try
            {
                using (Entities_general entyti = new Entities_general())
                {

                    tbl_periodo_evaluacion addnewC = new tbl_periodo_evaluacion();
                    addnewC.IdPeriodo =info.IdPeriodo= Convert.ToInt32(GetId());
                    addnewC.pe_fecha_fin = info.pe_fecha_fin;
                    addnewC.pe_fecha_ini = info.pe_fecha_ini;
                    addnewC.pe_observacion = info.pe_observacion;
                    addnewC.estado = true;
                    addnewC.estado_cierre = false;
                    entyti.tbl_periodo_evaluacion.Add(addnewC);
                    entyti.SaveChanges();
                    string sql = "exec sp_replicar_asignacion " + info.IdPeriodo.ToString();
                    entyti.Database.ExecuteSqlCommand(sql);

                    return true;
                }
               
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool modificarDB(tbl_periodo_evaluacion_Info info)
        {
            try
            {
                using (Entities_general entyti = new Entities_general())
                {

                    var addnewC = entyti.tbl_periodo_evaluacion.Where(v => v.IdPeriodo == info.IdPeriodo).FirstOrDefault();
                    if (addnewC != null)
                    {
                        addnewC.pe_fecha_fin = info.pe_fecha_fin;
                        addnewC.pe_fecha_ini = info.pe_fecha_ini;
                        addnewC.pe_observacion = info.pe_observacion;
                        addnewC.estado_cierre = info.estado_cierre;
                        entyti.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool anularDB(tbl_periodo_evaluacion_Info item)
        {
            try
            {
                using (Entities_general entyti = new Entities_general())
                {

                    var addnewC = entyti.tbl_periodo_evaluacion.Where(v => v.IdPeriodo == item.IdPeriodo).FirstOrDefault();
                    if (addnewC != null)
                    {
                        addnewC.estado = false;
                        addnewC.estado_cierre = false;
                        entyti.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

         private int GetId()
        {
            try
            {
                using (Entities_general entyti = new Entities_general())
                {
                    var selec = (from q in entyti.tbl_periodo_evaluacion
                                 select q);

                    if (selec.Count() == 0)
                        return 1;
                    else
                        return (from q in entyti.tbl_periodo_evaluacion
                                select q.IdPeriodo).Max() + 1;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public List<tbl_periodo_evaluacion_Info> GetList()
        {
            try
            {
                List<tbl_periodo_evaluacion_Info> listaPeriodos = new List<tbl_periodo_evaluacion_Info>();
                using (Entities_general contex = new Entities_general())
                {

                    listaPeriodos = (from q in contex.tbl_periodo_evaluacion
                                     where
                                      q.estado == true
                                     select new tbl_periodo_evaluacion_Info
                                     {
                                         IdPeriodo = q.IdPeriodo,
                                         pe_fecha_fin = q.pe_fecha_fin,
                                         pe_fecha_ini = q.pe_fecha_ini,
                                         pe_observacion = q.pe_observacion,
                                         estado = q.estado,
                                         estado_cierre=q.estado_cierre
                                     }
                              ).ToList();
                }

                return listaPeriodos;

            }
            catch (Exception)
            {

                return new List<tbl_periodo_evaluacion_Info>();
            }
        }

        public tbl_periodo_evaluacion_Info GetInfoPeriodoActivo()
        {
            try
            {
                tbl_periodo_evaluacion_Info info = new tbl_periodo_evaluacion_Info();
                using (Entities_general contex = new Entities_general())
                {
                    info = (from q in contex.tbl_periodo_evaluacion
                            where
                             q.estado == true
                             && q.estado_cierre == false
                            select new tbl_periodo_evaluacion_Info
                            {
                                IdPeriodo = q.IdPeriodo,
                                pe_fecha_fin = q.pe_fecha_fin,
                                pe_fecha_ini = q.pe_fecha_ini,
                                pe_observacion = q.pe_observacion,
                                estado = q.estado
                            }).FirstOrDefault();
                }
                
                return info;

            }
            catch (Exception)
            {

                return new tbl_periodo_evaluacion_Info();
            }
        }
        public tbl_periodo_evaluacion_Info get_info(int IdPeriodo)
        {
            try
            {
                tbl_periodo_evaluacion_Info info = new tbl_periodo_evaluacion_Info();
                using (Entities_general contex = new Entities_general())
                {
                    info = (from q in contex.tbl_periodo_evaluacion
                            where
                             q.IdPeriodo == IdPeriodo
                            select new tbl_periodo_evaluacion_Info
                            {
                                IdPeriodo = q.IdPeriodo,
                                pe_fecha_fin = q.pe_fecha_fin,
                                pe_fecha_ini = q.pe_fecha_ini,
                                pe_observacion = q.pe_observacion,
                                estado = q.estado,
                                estado_cierre=q.estado_cierre
                            }
                              ).FirstOrDefault();

                }

                return info;

            }
            catch (Exception)
            {

                return new tbl_periodo_evaluacion_Info();
            }
        }
        public List<tbl_periodo_evaluacion_Info> GetListPeriodos_abiertos()
        {
            try
            {
                List<tbl_periodo_evaluacion_Info> info = new List<tbl_periodo_evaluacion_Info>();
                using (Entities_general contex = new Entities_general())
                {
                    info = (from q in contex.tbl_periodo_evaluacion
                            where
                             q.estado == true
                             && q.estado_cierre == false
                            select new tbl_periodo_evaluacion_Info
                            {
                                IdPeriodo = q.IdPeriodo,
                                pe_fecha_fin = q.pe_fecha_fin,
                                pe_fecha_ini = q.pe_fecha_ini,
                                pe_observacion = q.pe_observacion,
                                estado = q.estado
                            }
                              ).ToList();

                }

                return info;

            }
            catch (Exception)
            {

                return new List<tbl_periodo_evaluacion_Info>();
            }
        }

        public bool cerrar_periodo(int IdPeriodo)
        {
            try
            {
                using (Entities_general entyti = new Entities_general())
                {
                    entyti.sp_cerrar_periodo(IdPeriodo);

                    var modif = entyti.tbl_periodo_evaluacion.FirstOrDefault(v => v.IdPeriodo == IdPeriodo);
                    if (modif != null)
                        modif.estado_cierre = true;
                    entyti.SaveChanges();
                        
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetUltimoPeriodo()
        {
            try
            {
                int ID = 0;
                using (Entities_general entyti = new Entities_general())
                {
                    //Obtengo ultimo periodo no cerrado
                    var lst = from q in entyti.tbl_periodo_evaluacion
                              where q.estado == true && q.estado_cierre == false
                              select q;

                    if (lst.Count() > 0)
                        ID = lst.OrderByDescending(q => q.pe_fecha_fin).First().IdPeriodo;
                    else
                    {
                        //Obtengo ultimo periodo cerrado
                        var lst_2 = from q in entyti.tbl_periodo_evaluacion
                                    where q.estado == true
                                    select q;

                        ID = lst_2.OrderByDescending(q => q.pe_fecha_fin).First().IdPeriodo;
                    }
                }
                return ID;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
