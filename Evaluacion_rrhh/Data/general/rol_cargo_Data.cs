using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.general;
namespace Data.general
{
  public  class rol_cargo_Data
    {
        public List<rol_cargo_Info> get_list()
        {
            try
            {
                List<rol_cargo_Info> listaCargo = new List<rol_cargo_Info>();
                using (Entities_general contex = new Entities_general())
                {

                    listaCargo = (from q in contex.rol_cargo
                                  where
                                   q.estado == true
                                  select new rol_cargo_Info
                                  {
                                      IdCargo = q.IdCargo,
                                      rc_codigo = q.rc_codigo,
                                      rc_descripcion = q.rc_descripcion,
                                      estado = q.estado
                                  }
                              ).ToList();
                }

                return listaCargo;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public rol_cargo_Info GetInfo(int? IdCargo)
        {
            rol_cargo_Info info = new rol_cargo_Info();
            try
            {
                using (Entities_general entyti = new Entities_general())
                {

                    var addnewC = entyti.rol_cargo.Where(v => v.IdCargo == IdCargo).FirstOrDefault();
                    if (addnewC != null)
                    {
                        info.IdCargo = addnewC.IdCargo;
                        info.rc_codigo = addnewC.rc_codigo;
                        info.rc_descripcion = addnewC.rc_descripcion;
                    }

                }
                return info;
            }
            catch (Exception e)
            {
                return new rol_cargo_Info();
            }
        }
        public rol_cargo_Info GetInfo(string ca_descripcion)
        {
            rol_cargo_Info info = new rol_cargo_Info();
            try
            {
                using (Entities_general entyti = new Entities_general())
                {

                    var addnewC = entyti.rol_cargo.Where(v => v.rc_descripcion == ca_descripcion).FirstOrDefault();
                    if (addnewC != null)
                    {
                        info.IdCargo = addnewC.IdCargo;
                        info.rc_codigo = addnewC.rc_codigo;
                        info.rc_descripcion = addnewC.rc_descripcion;
                    }

                }
                return info;
            }
            catch (Exception e)
            {
                return new rol_cargo_Info();
            }
        }

        public bool grabarDB(rol_cargo_Info info, ref int IdCargo)
        {
            try
            {
                using (Entities_general entyti = new Entities_general())
                {
                    var selec = (from q in entyti.rol_cargo
                                 where
                                  q.rc_descripcion == info.rc_descripcion
                                 select q);

                    if (selec.Count() == 0)
                    {
                        rol_cargo addnewC = new rol_cargo();
                        addnewC.IdCargo = GetId();
                        addnewC.rc_codigo = info.rc_codigo;
                        addnewC.rc_descripcion = info.rc_descripcion;
                        addnewC.estado = true;
                        entyti.rol_cargo.Add(addnewC);
                        entyti.SaveChanges();
                        IdCargo = addnewC.IdCargo;
                    }
                }
                return true;

            }
            catch (Exception)
            {

                throw;

            }
        }
        public bool modificarDB(rol_cargo_Info info)
        {

            try
            {
                using (Entities_general entyti = new Entities_general())
                {

                    var addnewC = entyti.rol_cargo.Where(v => v.IdCargo == info.IdCargo).FirstOrDefault();
                    if (addnewC != null)
                    {
                        addnewC.rc_codigo = info.rc_codigo;
                        addnewC.rc_descripcion = info.rc_descripcion;
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

        public bool anularDB(rol_cargo_Info info)
        {
            try
            {
                using (Entities_general entyti = new Entities_general())
                {

                    var addnewC = entyti.rol_cargo.Where(v => v.IdCargo == info.IdCargo).FirstOrDefault();
                    if (addnewC != null)
                    {
                        addnewC.estado = false;
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
                    var selec = (from q in entyti.rol_cargo
                                 select q);

                    if (selec.Count() == 0)
                        return 1;
                    else
                        return (from q in entyti.rol_cargo
                                select q.IdCargo).Max() + 1;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool si_existe( string ca_descripcion)
        {
            try
            {
                using (Entities_general entyti = new Entities_general())
                {
                    var selec = (from q in entyti.rol_cargo
                                 where q.rc_descripcion==ca_descripcion
                                 select q);
                    if (selec.Count() == 0)
                        return false;
                    else
                        return true;
                   
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
