using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.general;
namespace Data.general
{
  public  class rol_empleado_Data
    {


        public rol_empleado_Info GetInfo(decimal? IdEmpleado)
        {
            rol_empleado_Info addnewC = new rol_empleado_Info();
            try
            {

                using (Entities_general contex = new Entities_general())
                {
                    var item = contex.rol_empleado.Where(v => v.IdEmpleado == IdEmpleado).FirstOrDefault();
                    if (item != null)
                    {
                        addnewC.IdEmpleado = item.IdEmpleado;
                        addnewC.IdCargo = item.IdCargo;
                        addnewC.re_codigo = item.re_codigo;
                        addnewC.re_apellidos = item.re_apellidos;
                        addnewC.re_nombres = item.re_nombres;
                        addnewC.re_telefonos = item.re_telefonos;
                        addnewC.re_correo = item.re_correo;
                        addnewC.re_cedula = item.re_cedula;
                        addnewC.re_direccion = item.re_direccion;
                        addnewC.estado = true;
                        contex.SaveChanges();
                    }
                }



                return addnewC;
            }
            catch (Exception e)
            {
                return new rol_empleado_Info();
            }
        }
        public List<rol_empleado_Info> get_list()
        {
            try
            {
                List<rol_empleado_Info> listaemp = new List<rol_empleado_Info>();
                using (Entities_general model = new Entities_general())
                {

                    listaemp = (from q in model.rol_empleado
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
                                    NombreCompleato=q.re_apellidos+" "+q.re_nombres,
                                    FechaUltCorreo = q.FechaUltCorreo
                                    
                                }
                              ).ToList();
                }

                return listaemp;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool modificarDB( rol_empleado_Info info)
        {
            try
            {
                using (Entities_general contex = new Entities_general())
                {
                    var addnewC = contex.rol_empleado.Where(v => v.IdEmpleado == info.IdEmpleado).FirstOrDefault();
                    if (addnewC != null)
                    {
                        addnewC.IdCargo = info.IdCargo;
                        addnewC.re_codigo = info.re_codigo;
                        addnewC.re_apellidos = info.re_apellidos;
                        addnewC.re_nombres = info.re_nombres;
                        addnewC.re_telefonos = info.re_telefonos;
                        addnewC.re_correo = info.re_correo;
                        addnewC.re_cedula = info.re_cedula;
                        addnewC.re_direccion = info.re_direccion;
                        addnewC.estado = true;
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

        public bool modificarDB_x_cedula(rol_empleado_Info info)
        {
            try
            {
                using (Entities_general contex = new Entities_general())
                {
                    var addnewC = contex.rol_empleado.Where(v => v.re_cedula == info.re_cedula).FirstOrDefault();
                    if (addnewC != null)
                    {
                        addnewC.IdCargo = info.IdCargo;
                        addnewC.re_codigo = info.re_codigo;
                        addnewC.re_apellidos = info.re_apellidos;
                        addnewC.re_nombres = info.re_nombres;
                        addnewC.re_telefonos = info.re_telefonos;
                        addnewC.re_correo = info.re_correo;
                        addnewC.re_cedula = info.re_cedula;
                        addnewC.re_direccion = info.re_direccion;
                        addnewC.estado = info.estado;
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

        public bool anularDB(rol_empleado_Info info)
        {
            try
            {
                using (Entities_general contex = new Entities_general())
                {
                    var addnewC = contex.rol_empleado.Where(v => v.IdEmpleado == info.IdEmpleado).FirstOrDefault();
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
        private decimal GetId()
        {
            try
            {
                using (Entities_general contex = new Entities_general())
                {
                    var selec = (from q in contex.rol_empleado
                                 select q);

                    if (selec.Count() == 0)
                        return 1;
                    else
                        return (from q in contex.rol_empleado
                                select q.IdEmpleado).Max() + 1;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool guardarDB(rol_empleado_Info info)
        {
            try
            {
                using (Entities_general contex = new Entities_general())
                {
                    var selec = (from q in contex.rol_empleado
                                 where
                                  q.re_cedula == info.re_cedula
                                 select q);

                    if (selec.Count() == 0)
                    {
                        rol_empleado addnewC = new rol_empleado
                        {
                            IdEmpleado = GetId(),
                            IdCargo = info.IdCargo,
                            re_codigo = info.re_codigo,
                            re_apellidos = info.re_apellidos,
                            re_nombres = info.re_nombres,
                            re_telefonos = info.re_telefonos,
                            re_correo = (info.re_correo == null) ? " " : info.re_correo,
                            re_direccion = info.re_direccion,
                            re_cedula = info.re_cedula,
                            estado = true,
                        };
                        contex.rol_empleado.Add(addnewC);
                        contex.SaveChanges();
                    }
                    else
                    {

                    }
                }
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public bool Login(String usuario, string contraseña, ref decimal IdEmpleado)
        {
            try
            {
                using (Entities_general contex = new Entities_general())
                {
                    var addnewC = contex.rol_empleado.Where(v => v.re_codigo == usuario && v.re_cedula==contraseña).FirstOrDefault();
                    if (addnewC != null)
                    {
                        IdEmpleado = addnewC.IdEmpleado;
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool si_existe(string cedula)
        {
            try
            {
                using (Entities_general contex = new Entities_general())
                {
                    var selec = (from q in contex.rol_empleado
                                 where q.re_cedula==cedula
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
