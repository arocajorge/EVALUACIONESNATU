using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Info.general;
using Data.general;
namespace Web.Controllers
{
    public class FormularioController : Controller
    {
        enc_formulario_Info info_formulario = new enc_formulario_Info();
        enc_formulario_Data formulario_data = new enc_formulario_Data();
        public ActionResult Index()
        {
            tbl_periodo_evaluacion_Info info_periodo_actual = new tbl_periodo_evaluacion_Info();
            tbl_periodo_evaluacion_Data data_periodo_actual = new tbl_periodo_evaluacion_Data();
            info_periodo_actual = data_periodo_actual.GetInfoPeriodoActivo();
            if (info_periodo_actual == null)
                return RedirectToAction("Index", "Periodo_evaluacion");
            tbl_periodo_evaluacion_Data periodo_data = new tbl_periodo_evaluacion_Data();
            ViewBag.lista_periodos = periodo_data.GetList();

            enc_formulario_Info model = new enc_formulario_Info();            
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(enc_formulario_Info model)
        {


            tbl_periodo_evaluacion_Info info_periodo_actual = new tbl_periodo_evaluacion_Info();
            tbl_periodo_evaluacion_Data data_periodo_actual = new tbl_periodo_evaluacion_Data();
            info_periodo_actual = data_periodo_actual.GetInfoPeriodoActivo();
            if (info_periodo_actual == null)
                return RedirectToAction("Index", "Periodo_evaluacion");

            List<enc_formulario_Info> lst_formulario = formulario_data.get_list(info_periodo_actual.IdPeriodo);
            if (lst_formulario.Count == 0)
            {
                if (model.IdPeriodo_migrar != 0)
                {
                    formulario_data.grabarDB_migracion(formulario_data.get_list_migracion(Convert.ToInt32(model.IdPeriodo_migrar)), info_periodo_actual.IdPeriodo);
                }
            }

            return RedirectToAction("Index");
        }
              
        public ActionResult FormularioPartial()
        {
            try
            {
                tbl_periodo_evaluacion_Info info_periodo_actual = new tbl_periodo_evaluacion_Info();
                tbl_periodo_evaluacion_Data data_periodo_actual = new tbl_periodo_evaluacion_Data();
                info_periodo_actual = data_periodo_actual.GetInfoPeriodoActivo();
                if (info_periodo_actual == null)
                    return RedirectToAction("Index", "Periodo_evaluacion");

                List<enc_formulario_Info> lista_formulario = new List<enc_formulario_Info>();
                lista_formulario = formulario_data.get_list(info_periodo_actual.IdPeriodo);
               
                return PartialView("_FormularioPartial", lista_formulario);

            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Nuevo(enc_formulario_Info item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    formulario_data.grabarDB(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return RedirectToAction("Index", "Formulario");

        }
        public ActionResult Nuevo()
        {


            try
            {
                info_formulario = new enc_formulario_Info();
                return View(info_formulario);
            }
            catch (Exception)
            {

                return View();
            }

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Modificar(enc_formulario_Info item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    formulario_data.modificarDB(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return RedirectToAction("Index", "Formulario");
        }
        public ActionResult Modificar(decimal IdFormulario)
        {

            try
            {
                if (IdFormulario == 0)
                {
                    return RedirectToAction("Index", "Formulario");
                }
                info_formulario = formulario_data.get_info(IdFormulario);
                if (info_formulario == null)
                    return RedirectToAction("Index", "Formulario");
                return View(info_formulario);
            }
            catch (Exception)
            {

                return View();
            }
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Anular(enc_formulario_Info item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    formulario_data.anularDB(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return RedirectToAction("Index", "Formulario");
        }
        public ActionResult Anular(decimal IdFormulario = 0)
        {

            try
            {
                if (IdFormulario == 0)
                {
                    return RedirectToAction("Index", "Formulario");
                }
                 info_formulario = formulario_data.get_info(IdFormulario);
                if (info_formulario == null)
                    return RedirectToAction("Index", "Formulario");
                return View(info_formulario);
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}