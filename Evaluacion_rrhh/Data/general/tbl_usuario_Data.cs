using Info.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.general
{
   public class tbl_usuario_Data
    {         
        public bool login(tbl_usuario_Info model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.IdUsuario) || string.IsNullOrWhiteSpace(model.us_contrasenia))
                {
                    return false;
                }

                using (Entities_general Context = new Entities_general())
                {
                    

                   
                        var lst_2 = from q in Context.tbl_usuario
                                    where q.IdUsuario == model.IdUsuario
                                    && q.us_contrasenia == model.us_contrasenia
                                    select q;

                        if (lst_2.Count() == 0)
                        {
                            return false;
                        }
                        else
                        return true;


                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public List<tbl_usuario_Info> get_list()
        {
            try
            {
                List<tbl_usuario_Info> lista = new List<tbl_usuario_Info>();
                using (Entities_general model = new Entities_general())
                {

                    lista = (from q in model.tbl_usuario
                                     where q.estado == true
                                     select new tbl_usuario_Info
                                     {
                                         IdUsuario = q.IdUsuario,
                                         us_contrasenia = q.us_contrasenia,
                                         estado = q.estado
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
       
        public bool grabarDB(tbl_usuario_Info info)
        {

            try
            {
                using (Entities_general entyti = new Entities_general())
                {

                    tbl_usuario addnewC = new tbl_usuario();
                    addnewC.IdUsuario = info.IdUsuario;
                    addnewC.us_contrasenia = info.us_contrasenia;
                    addnewC.estado = true;
                    entyti.tbl_usuario.Add(addnewC);
                    entyti.SaveChanges();

                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public bool modificarDB(tbl_usuario_Info info)
        {
            try
            {

                using (Entities_general entyti = new Entities_general())
                {

                    var addnewC = entyti.tbl_usuario.Where(v => v.IdUsuario == info.IdUsuario).FirstOrDefault();
                    if (addnewC != null)
                    {
                        addnewC.us_contrasenia = info.us_contrasenia;
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
 
        public bool anaularDB(tbl_usuario_Info info)
        {

            try
            {
                using (Entities_general entyti = new Entities_general())
                {

                    var addnewC = entyti.tbl_usuario.Where(v => v.IdUsuario == info.IdUsuario).FirstOrDefault();
                    if (addnewC != null)
                    {
                        addnewC.estado = false;
                        entyti.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }
     
        public tbl_usuario_Info GetInfo(string IdUsuario, string contrasena)
        {
            try
            {
                tbl_usuario_Info info = new tbl_usuario_Info();
                using (Entities_general model = new Entities_general())
                {

                    info = (from q in model.tbl_usuario
                            where q.estado == true
                            && q.IdUsuario == IdUsuario
                            && q.us_contrasenia==contrasena
                            select new tbl_usuario_Info
                            {
                                IdUsuario = q.IdUsuario,
                                us_contrasenia = q.us_contrasenia,
                                estado = q.estado
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

        public tbl_usuario_Info GetInfo(string IdUsuario)
        {
            try
            {
                tbl_usuario_Info info = new tbl_usuario_Info();
                using (Entities_general model = new Entities_general())
                {

                    info = (from q in model.tbl_usuario
                            where q.estado == true
                            && q.IdUsuario == IdUsuario
                            select new tbl_usuario_Info
                            {
                                IdUsuario = q.IdUsuario,
                                us_contrasenia = q.us_contrasenia,
                                estado = q.estado
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
