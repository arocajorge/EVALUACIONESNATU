using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Info.general;
using Data.general;
using System.IO;
using System.Data;
using ExcelDataReader;
namespace Web.Controllers
{
    public class EmpleadoController : Controller
    {
        List<rol_empleado_Info> lista = new List<rol_empleado_Info>();
        rol_empleado_Data emp_data = new rol_empleado_Data();
        rol_cargo_Info cargo_info = new rol_cargo_Info();
        rol_cargo_Data cargo_data = new rol_cargo_Data();
        rol_empleado_x_correo_x_periodo_Data odata_correo = new rol_empleado_x_correo_x_periodo_Data();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetList()
        {
            try
            {
                lista = emp_data.get_list();
                return PartialView("_Empleado_partial",lista);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Nuevo()
        {
            rol_empleado_Info model = new rol_empleado_Info();
            ViewBag.listacargo = cargo_data.get_list();
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(rol_empleado_Info item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        if (emp_data.guardarDB(item))
                            return RedirectToAction("Index", "Empleado");
                        else
                        ViewBag.listacargo = cargo_data.get_list();
                        return View("Nuevo",item);


                    }
                    catch (Exception e)
                    {
                        ViewData["EditError"] = e.Message;
                    }
                }
                else
                    ViewData["EditError"] = "Please, correct all errors.";
                return RedirectToAction("Index", "Empleado");
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Modificar(decimal? IdEmpleado)
        {
            try
            {
                ViewBag.listacargo = cargo_data.get_list();
                return View(emp_data.GetInfo(IdEmpleado));

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Modificar(rol_empleado_Info item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (emp_data.modificarDB(item))
                        return RedirectToAction("Index", "Empleado");
                    else
                        ViewBag.listacargo = cargo_data.get_list();
                    return View("Modificar", item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("Index", "Empleado");
        }
        public ActionResult Anular(decimal? IdEmpleado)
        {
            ViewBag.listacargo = cargo_data.get_list();
            return View(emp_data.GetInfo(IdEmpleado));
        }
        [HttpPost]
        public ActionResult Anular(rol_empleado_Info item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    emp_data.anularDB(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return RedirectToAction("Index", "Empleado");
        }

        [HttpPost]
        public ActionResult Importarempleados(HttpPostedFileBase uploadfile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int cont = 0;
                    int IdCargo = 0;
                    List<rol_empleado_Info> listaemp = new List<rol_empleado_Info>();
                    List<rol_cargo_Info> listaCargo = new List<rol_cargo_Info>();
                    rol_cargo_Data caro_data = new rol_cargo_Data();
                    rol_empleado_Data empleado_data = new rol_empleado_Data();
                    if (uploadfile != null && uploadfile.ContentLength > 0)
                    {
                        Stream stream = uploadfile.InputStream;
                        IExcelDataReader reader = null;
                        if (uploadfile.FileName.EndsWith(".xls"))
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(stream);
                        }
                        else if (uploadfile.FileName.EndsWith(".xlsx"))
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        }
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                if (cont != 0)
                                {

                                    // verificando cargo
                                    if (cargo_data.si_existe(reader.GetString(7))==false)
                                    {
                                        rol_cargo_Info infoc = new rol_cargo_Info();                                   
                                        infoc.rc_descripcion = reader.GetString(7);
                                        infoc.estado = true;
                                        caro_data.grabarDB(infoc, ref IdCargo);
                                    }
                                    else
                                    {
                                        IdCargo = cargo_data.GetInfo(reader.GetString(7)).IdCargo;
                                    }


                                    try
                                    {
                                        rol_empleado_Info info = new rol_empleado_Info();
                                        info.re_codigo = reader.GetString(0);
                                        info.re_apellidos = reader.GetString(1);
                                        info.re_nombres = reader.GetString(2);
                                        info.re_cedula = reader.GetString(3);
                                        info.re_correo = reader.GetString(4);
                                        info.re_telefonos = reader.GetString(5);
                                        info.re_direccion = reader.GetString(6);
                                        info.IdCargo = IdCargo;
                                        info.estado = reader.GetString(8) == "A" ? true : false;
                                        listaemp.Add(info);
                                        if (emp_data.si_existe(info.re_cedula))
                                            emp_data.modificarDB_x_cedula(info);
                                        else
                                            empleado_data.guardarDB(info);
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }
                                cont++;
                            }
                        }

                        return RedirectToAction("Index","Empleado");
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Please upload your file");
                }
                return View();
            }
            catch (Exception ex)
            {

                return View();
            }
        }
        public ActionResult Importarempleados()
        {
            return View();
        }

        public ActionResult TestCorreo(decimal IdEmpleado)
        {
            try
            {
                rol_empleado_Info info_empleado = new rol_empleado_Info();
                info_empleado= emp_data.GetInfo(IdEmpleado);
                if (info_empleado != null)
                {
                    tbl_periodo_evaluacion_Info info_periodo = new tbl_periodo_evaluacion_Info();
                    tbl_periodo_evaluacion_Data data_periodo = new tbl_periodo_evaluacion_Data();

                    info_periodo = data_periodo.GetInfoPeriodoActivo();
                    if (info_periodo != null)
                    {
                        info_empleado.fechaI = info_periodo.pe_fecha_ini;
                        info_empleado.fechaF = info_periodo.pe_fecha_fin;
                        odata_correo.EnviarCorreo(info_empleado);
                    }
                }
                return RedirectToAction("Index", "Empleado");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}