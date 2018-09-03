using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Info.general;
using Data.general;
namespace Web.Controllers
{
    public class Formulario_preguntaController : Controller
    {
        enc_formulario_pregunta_Data pregunta_data = new enc_formulario_pregunta_Data();
        enc_formulario_pregunta_Info pregunta_info = new enc_formulario_pregunta_Info();
        enc_formulario_Data formulario_data = new enc_formulario_Data();
        tbl_periodo_evaluacion_Info info_periodo = new tbl_periodo_evaluacion_Info();
        tbl_periodo_evaluacion_Data data_periodo = new tbl_periodo_evaluacion_Data();
         public ActionResult Index(int IdFormulario = 0)
        {
            try
            {
                if (IdFormulario == 0)
                    return RedirectToAction("Index", "Formulario");

                ViewBag.IdFormulario = IdFormulario;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_preguntas(int IdFormulario = 0, int IdPEriodo=0)
        {
            try
            {
                if (IdFormulario == 0)
                    return PartialView("_GridViewPartial_preguntas");

                List<enc_formulario_pregunta_Info> list_preguntas = new List<enc_formulario_pregunta_Info>();
                list_preguntas = pregunta_data.get_list(IdFormulario, IdPEriodo);
                ViewBag.IdFormulario = IdFormulario;
                return PartialView("_GridViewPartial_preguntas", list_preguntas);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Nuevo(int IdFormulario = 0)
        {
            if (IdFormulario == 0)
                return RedirectToAction("Index", "Formulario");

            enc_formulario_pregunta_Info model = new enc_formulario_pregunta_Info
            {
                IdFormulario = IdFormulario
            };
            info_periodo = data_periodo.GetInfoPeriodoActivo();
            if (info_periodo == null)
                return RedirectToAction("Index", "Periodo_evaluacion");

            ViewBag.lst_formulario = formulario_data.get_list(info_periodo.IdPeriodo);
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(enc_formulario_pregunta_Info model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    double suma = 0;

                    if (model.ep_ponderacion == 0 | model.ep_ponderacion < 0)
                    {
                        ViewBag.mensaje = "La ponderación debe ser mayor que cero!";
                        info_periodo = data_periodo.GetInfoPeriodoActivo();
                        if (info_periodo == null)
                            return RedirectToAction("Index", "Periodo_evaluacion");

                        ViewBag.lst_formulario = formulario_data.get_list(info_periodo.IdPeriodo);

                        return View(model);
                    }
                    if (model.ep_ponderacion>100)
                    {
                        ViewBag.mensaje = "La ponderación es: "+model.ep_ponderacion+" se esperaba máximo 100";
                        info_periodo = data_periodo.GetInfoPeriodoActivo();
                        if (info_periodo == null)
                            return RedirectToAction("Index", "Periodo_evaluacion");

                        ViewBag.lst_formulario = formulario_data.get_list(info_periodo.IdPeriodo);

                        return View(model);
                    }
                    suma = suma +pregunta_data.valiadrSumatoria(model.IdFormulario) + model.ep_ponderacion;
                    if (suma > 100)
                    {
                        ViewBag.mensaje = "La ponderación de las preguntas es mayor que 100!";
                        info_periodo = data_periodo.GetInfoPeriodoActivo();
                        if (info_periodo == null)
                            return RedirectToAction("Index", "Periodo_evaluacion");

                        ViewBag.lst_formulario = formulario_data.get_list(info_periodo.IdPeriodo);

                        return View(model);
                    }

                    if (!pregunta_data.guardarDB(model))
                    {
                        ViewBag.mensaje = "No se ha podido guardar el registro";
                        info_periodo = data_periodo.GetInfoPeriodoActivo();
                        if (info_periodo == null)
                            return RedirectToAction("Index", "Periodo_evaluacion");

                        ViewBag.lst_formulario = formulario_data.get_list(info_periodo.IdPeriodo);
                        return View(model);
                    }
                }
                return RedirectToAction("Index", "Formulario_pregunta", new { IdFormulario = model.IdFormulario });

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Modificar(decimal IdPregunta = 0, decimal IdFormulario = 0)
        {
            try
            {
                if (IdFormulario == 0)
                    return RedirectToAction("Index", "Formulario");
                if (IdPregunta == 0)
                {
                    ViewBag.IdFormulario = IdFormulario;
                    return RedirectToAction("Index", "Formulario_pregunta", new { IdFormulario });
                }
                pregunta_info  = pregunta_data.get_info(IdPregunta);
                if (pregunta_info == null)
                {
                    ViewBag.IdFormulario = IdFormulario;
                    return RedirectToAction("Index", "Formulario_pregunta", new { IdFormulario });
                }

                info_periodo = data_periodo.GetInfoPeriodoActivo();
                if (info_periodo == null)
                    return RedirectToAction("Index", "Periodo_evaluacion");

                ViewBag.lst_formulario = formulario_data.get_list(info_periodo.IdPeriodo);
                return View(pregunta_info);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Modificar(enc_formulario_pregunta_Info model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.mensaje = "";
                    info_periodo = data_periodo.GetInfoPeriodoActivo();
                    if (info_periodo == null)
                        return RedirectToAction("Index", "Periodo_evaluacion");

                    ViewBag.lst_formulario = formulario_data.get_list(info_periodo.IdPeriodo);
                    return View(model);
                }
                if (!pregunta_data.modificarDB(model))
                {
                    ViewBag.mensaje = "No se ha podido modificar el registro";
                    info_periodo = data_periodo.GetInfoPeriodoActivo();
                    if (info_periodo == null)
                        return RedirectToAction("Index", "Periodo_evaluacion");

                    ViewBag.lst_formulario = formulario_data.get_list(info_periodo.IdPeriodo);
                    return View(model);
                }
                return RedirectToAction("Index", "Formulario_pregunta", new { IdFormulario = model.IdFormulario });
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Anular(decimal IdPregunta = 0, decimal IdFormulario = 0)
        {
            try
            {
                if (IdFormulario == 0)
                    return RedirectToAction("Index", "Formulario");
                if (IdPregunta == 0)
                {
                    ViewBag.IdFormulario = IdFormulario;
                    return RedirectToAction("Index", "Formulario_pregunta", new { IdFormulario });
                }
                pregunta_info  =pregunta_data. get_info(IdPregunta);
                if (pregunta_info == null)
                {
                    ViewBag.IdFormulario = IdFormulario;
                    return RedirectToAction("Index", "Formulario_pregunta", new { IdFormulario });
                }
                info_periodo = data_periodo.GetInfoPeriodoActivo();
                if (info_periodo == null)
                    return RedirectToAction("Index", "Periodo_evaluacion");

                ViewBag.lst_formulario = formulario_data.get_list(info_periodo.IdPeriodo);
                return View(pregunta_info);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Anular(enc_formulario_pregunta_Info model)
        {
            try
            {
                if (!pregunta_data.anularDB(model))
                {
                    ViewBag.mensaje = "No se ha podido anular el registro";
                    info_periodo = data_periodo.GetInfoPeriodoActivo();
                    if (info_periodo == null)
                        return RedirectToAction("Index", "Periodo_evaluacion");

                    ViewBag.lst_formulario = formulario_data.get_list(info_periodo.IdPeriodo);
                    return View(model);
                }
                return RedirectToAction("Index", "Formulario_pregunta", new { IdFormulario = model.IdFormulario });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}