using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.general;
using Info.general;
using DevExpress.Web.Mvc;

namespace web.Controllers
{
    
    public class Empleado_x_formularioController : Controller
    {
        rol_empleado_x_formulario_Data emp_for_data = new rol_empleado_x_formulario_Data();
        rol_empleado_x_formulario_Info emp_xfoem_info = new rol_empleado_x_formulario_Info();
        enc_formulario_Data formulario_data = new enc_formulario_Data();
        rol_empleado_Data empleado_data = new rol_empleado_Data();
        tbl_periodo_evaluacion_Info info_periodo = new tbl_periodo_evaluacion_Info();
        tbl_periodo_evaluacion_Data data_periodo = new tbl_periodo_evaluacion_Data();
        private object re;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult empleado_x_formulario_Partial()
        {
            try
            {
                emp_xfoem_info = emp_for_data.empleado_x_formulario_Partial();
                return PartialView("empleado_x_formulario_Partial", emp_xfoem_info);

            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult Asignar(decimal IdEmpleado = 0)
        {
            try
            {
                List<rol_empleado_x_formulario_Info> list = new List<rol_empleado_x_formulario_Info>();
                info_periodo = data_periodo.GetInfoPeriodoActivo();
                if (info_periodo == null)
                    return RedirectToAction("Index", "Periodo_evaluacion");
                if (IdEmpleado == 0)
                    return RedirectToAction("Index");
                ViewBag.IdEmpleado = IdEmpleado;
                return View(list);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] rol_empleado_x_formulario_Info info_det, decimal? IdEmpleado)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    info_periodo = data_periodo.GetInfoPeriodoActivo();
                    if (info_periodo == null)
                        ViewBag.mensaje = "No existe periodos activos";
                    else
                    {
                        info_det.IdPeriodo = info_periodo.IdPeriodo;
                        emp_for_data.guardarDB(info_det);
                        rol_empleado_Info infoE = empleado_data.GetInfo(IdEmpleado);
                        ViewBag.empleado = infoE.re_apellidos + " " + infoE.re_nombres;
                        ViewBag.listaempleado = empleado_data.get_list();
                        ViewBag.listaformularios = formulario_data.get_list(info_periodo.IdPeriodo);
                    }
                }

                return PartialView("GridViewPartial_det", emp_for_data. GetListEmp_Asignados(IdEmpleado,info_periodo.IdPeriodo));
            }
            catch (Exception )
            {

                throw;
            }
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] rol_empleado_x_formulario_Info info_det, decimal? IdEmpleado)
        {
            try
            {
                
                    info_periodo = data_periodo.GetInfoPeriodoActivo();
                    if (info_periodo == null)
                        return RedirectToAction("Index", "Periodo_evaluacion");

                if (ModelState.IsValid)
                    emp_for_data.modificarDB(info_det);
                rol_empleado_Info infoE = empleado_data.GetInfo(IdEmpleado);
                ViewBag.empleado = infoE.re_apellidos + " " + infoE.re_nombres;
                ViewBag.listaempleado = empleado_data.get_list();
                ViewBag.listaformularios = formulario_data.get_list(info_periodo.IdPeriodo);

                return PartialView("GridViewPartial_det", emp_for_data.GetListEmp_Asignados(IdEmpleado, info_periodo.IdPeriodo));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult EditingDelete([ModelBinder(typeof(DevExpressEditorsBinder))] rol_empleado_x_formulario_Info info_det, decimal? IdEmpleado)
        {
            try
            {
                info_periodo = data_periodo.GetInfoPeriodoActivo();
                if (info_periodo == null)
                    return RedirectToAction("Index", "Periodo_evaluacion");

                if (ModelState.IsValid)
                    emp_for_data.anularDB(info_det);
                rol_empleado_Info infoE = empleado_data.GetInfo(IdEmpleado);
                ViewBag.empleado = infoE.re_apellidos + " " + infoE.re_nombres;
                ViewBag.listaempleado = empleado_data.get_list();
                ViewBag.listaformularios = formulario_data.get_list(info_periodo.IdPeriodo);

                return PartialView("GridViewPartial_det", emp_for_data.GetListEmp_Asignados(IdEmpleado, info_periodo.IdPeriodo));
            }
            catch (Exception)
            {

                throw;
            }
        }


        [ValidateInput(false)]
        public ActionResult GridViewPartial_det(decimal IdEmpleado = 0)
        {
            try
            {
                
                List<rol_empleado_x_formulario_Info> lst_det = new List<rol_empleado_x_formulario_Info>();
                info_periodo = data_periodo.GetInfoPeriodoActivo();
                if (info_periodo == null)
                    info_periodo = new tbl_periodo_evaluacion_Info { IdPeriodo = 0 };

                lst_det = emp_for_data.GetListEmp_Asignados(IdEmpleado, info_periodo.IdPeriodo);
                rol_empleado_Info infoE = empleado_data.GetInfo(IdEmpleado);
                ViewBag.empleado = infoE.re_apellidos + " " + infoE.re_nombres;
                ViewBag.IdEmpleado = IdEmpleado;
                ViewBag.listaempleado = empleado_data.get_list();
                ViewBag.listaformularios = formulario_data.get_list(info_periodo.IdPeriodo);

                return PartialView("GridViewPartial_det", lst_det);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult AsignarPonderacion_partial(decimal IdEmpleado = 0)
        {
            try
            {
                info_periodo = data_periodo.GetInfoPeriodoActivo();
                if (info_periodo == null)
                    return RedirectToAction("Index", "Periodo_evaluacion");

                rol_empleado_x_formulario_Info info = new rol_empleado_x_formulario_Info();

                info = emp_for_data.GetInfo_ponderar(IdEmpleado, info_periodo.IdPeriodo);
                if (info.lista_emp_x_form.Count() == 0)
                   return RedirectToAction("Index", "Empleado_x_formulario");
                else
                return View("AsignarPonderacion_partial", info);
               
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult AsignarPonderacion_partial(rol_empleado_x_formulario_Info model)
        {
            try
            {
                double suma = 0;
                if (model.lista_emp_x_form.Count > 0)
                {
                  suma = model.lista_emp_x_form.Sum(v => v.ef_ponderacion);
                    if (suma < 100 |suma >100)
                    {
                        ViewBag.mensaje = "La suma de las ponderaciones es:" + suma + ", se esperaba 100";
                        return View(model);
                    }
                    else
                    {
                        foreach (var item in model.lista_emp_x_form)
                        {
                            emp_for_data.modificar_ponderacionDB(item);
                        }
                        return RedirectToAction("Index", "Empleado_x_formulario");
                    }

                }
                else

              
                return View(model);              
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult ListadoAsignaciones()
        {
            try
            {
                
                List<rol_empleado_x_formulario_Info> lista = new List<rol_empleado_x_formulario_Info>();
                lista= emp_for_data.GetListadoAsignaciones();

                return View("ListadoAsignaciones_partial", lista);
               
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}