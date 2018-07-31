using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.general;
namespace Data.general
{
   public class tbl_parametros_correo_Data
    {
        public List<tbl_parametros_correo_Info> ParametrosCorreoPartial()
        {
            try
            {
                List<tbl_parametros_correo_Info> lista_parametros = new List<tbl_parametros_correo_Info>();
                using (Entities_general model = new Entities_general())
                {

                    lista_parametros = (from q in model.tbl_parametros_correo

                                        select new tbl_parametros_correo_Info
                                        {
                                            ep_correo = q.ep_correo,
                                            ep_contrasenia = q.ep_contrasenia,
                                            ep_permite_sll = q.ep_permite_sll,
                                            ep_puerto = q.ep_puerto,
                                            ep_dominio = q.ep_dominio,
                                            ep_observacion = q.ep_observacion

                                        }
                              ).ToList();
                }

                return  lista_parametros;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool guardarDB(tbl_parametros_correo_Info item)
        {

            try
            {


                using (Entities_general entyti = new Entities_general())
                {
                    var consu = entyti.tbl_parametros_correo.FirstOrDefault();
                    if (consu == null)
                    {
                        tbl_parametros_correo addnewC = new tbl_parametros_correo();
                        addnewC.ep_correo = item.ep_correo;
                        addnewC.ep_contrasenia = item.ep_contrasenia;
                        addnewC.ep_permite_sll = item.ep_permite_sll;
                        addnewC.ep_dominio = item.ep_dominio;
                        addnewC.ep_puerto = item.ep_puerto;
                        addnewC.ep_observacion = item.ep_observacion;
                        entyti.tbl_parametros_correo.Add(addnewC);
                        entyti.SaveChanges();
                    }

                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool ModificarDB(tbl_parametros_correo_Info item)
        {
                try
                {
                    using (Entities_general entyti = new Entities_general())
                    {

                        var addnewC = entyti.tbl_parametros_correo.FirstOrDefault();
                        if (addnewC != null)
                        {
                            addnewC.ep_correo = item.ep_correo;
                            addnewC.ep_contrasenia = item.ep_contrasenia;
                            addnewC.ep_permite_sll = item.ep_permite_sll;
                            addnewC.ep_puerto = item.ep_puerto;
                            addnewC.ep_dominio = item.ep_dominio;
                            addnewC.ep_observacion = item.ep_observacion;
                            entyti.SaveChanges();
                        }

                    }
                return true;
                }
                catch (Exception e)
                {
                return false;
                }
         
        }

        public tbl_parametros_correo_Info GetInfo()
        {
            try
            {
                tbl_parametros_correo_Info info = new tbl_parametros_correo_Info();
                using (Entities_general model = new Entities_general())
                {

                    info = (from q in model.tbl_parametros_correo

                                        select new tbl_parametros_correo_Info
                                        {
                                            ep_correo = q.ep_correo,
                                            ep_contrasenia = q.ep_contrasenia,
                                            ep_permite_sll = q.ep_permite_sll,
                                            ep_puerto = q.ep_puerto,
                                            ep_dominio = q.ep_dominio,
                                            ep_observacion = q.ep_observacion

                                        }
                              ).FirstOrDefault();
                }

                return info;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
