using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Info.general;
using Data.general;
namespace Web.Controllers
{
    public class Resolucion_formularioController : Controller
    {
        enc_resolucion_formulario_Data reso_data = new enc_resolucion_formulario_Data();
        enc_resolucion_formulario_det_Data resol_data_det = new enc_resolucion_formulario_det_Data();
        tbl_periodo_evaluacion_Info info_periodo = new tbl_periodo_evaluacion_Info();
        tbl_periodo_evaluacion_Data data_periodo = new tbl_periodo_evaluacion_Data();
        public ActionResult Index()
        {
            try
            {
                enc_resolucion_Info info = new enc_resolucion_Info();
                Decimal IdEmpleado = 0;
                IdEmpleado = (Session["IdEmpleado"])==null?0:Convert.ToDecimal( (Session["IdEmpleado"]));
                info.Concepto = "Califique del [0-100], de acuerdo a lo preguntado";

                info_periodo = data_periodo.GetInfoPeriodoActivo();
                if (info_periodo == null)
                    return RedirectToAction("Mensaje", "Resolucion_formulario", new { mensaje = "No existe periodo de evaluación activo" });

                if (reso_data.empleado_realizo_encuesta(IdEmpleado,info_periodo.IdPeriodo))
                    return RedirectToAction("Mensaje", "Resolucion_formulario", new { mensaje = "Evaluación realizada exitósamente, espere los resultados" });

                info = reso_data.GetResolver_evaluacion(IdEmpleado, info_periodo.IdPeriodo);

                if (info.lista_resoluccion.Count == 0)
                {
                    return RedirectToAction("Mensaje", "Resolucion_formulario", new { mensaje = "Actualmente no existe un formulario disponible para usted, comuníquese con sistemas" });
                }
                return PartialView("Index", info);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult LoginID(decimal p1 = 0)
        {
            if(p1 == 0)
                return RedirectToAction("Mensaje", "Resolucion_formulario", new { mensaje = "Usted no se encuentra registrado en el sistema de evaluación de personal, comuníquese con sistemas" });
            Session["IdEmpleado"] = p1;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Index(enc_resolucion_Info model)
        {
            try
            {
                foreach (var item in model.lista_resoluccion)
                {
                    foreach (var item_ in item.lista)
                    {
                        if (item_.re_ponderacion == null)
                        {
                            ViewBag.mensaje = "La pregunta  "+item_.ep_descripcion+"\n"+"no ha sido contestada para el empleado \n" +item.re_nombres;
                            return PartialView("Index", model);
                        }
                    }
                }

                decimal idresoluccion = 0;
                    foreach (var item in model.lista_resoluccion)
                    {
                        if (reso_data.grabarDB(item, ref idresoluccion))
                        {
                            foreach (var item_ in item.lista)
                            {
                                item_.IdResolucion = idresoluccion;
                            }
                            resol_data_det.grabardb(item.lista);
                        }
                    }                
                return RedirectToAction("Mensaje", new { mensaje = "Evaluación realizada exitósamente" });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult enc_resolucion_formulario_det(decimal? IdEmpleado, decimal? IdEmpleadoEva, decimal? IdFormulario)
        {
            try
            {
                info_periodo = data_periodo.GetInfoPeriodoActivo();
                if (info_periodo == null)
                    return RedirectToAction("Mensaje", "Resolucion_formulario", new { mensaje = "No existe periodo de evaluación activo" });

                enc_resolucion_Info info = new enc_resolucion_Info();
                info= reso_data.GetResolver_evaluacion(IdEmpleado,info_periodo.IdPeriodo);
                return PartialView("Index", info);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult Mensaje(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }

        public ActionResult Resultados_evaluacion()
        {
            return View();
        }

        ActionResult Resultados_evaluacion_partial(int IdPeriodo)
        {
            try
            {

                return PartialView();
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Error");
            }
        }

         }
}