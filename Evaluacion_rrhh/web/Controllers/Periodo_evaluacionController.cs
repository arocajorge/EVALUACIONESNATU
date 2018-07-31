using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Info.general;
using Data.general;
namespace Web.Controllers
{
    public class Periodo_evaluacionController : Controller
    {
        tbl_periodo_evaluacion_Data periodo_data = new tbl_periodo_evaluacion_Data();
        tbl_periodo_evaluacion_Info periodo_info = new tbl_periodo_evaluacion_Info();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PeriodosPartial()
        {
            try
            {
                List<tbl_periodo_evaluacion_Info> listaperiodos = new List<tbl_periodo_evaluacion_Info>();
                listaperiodos = periodo_data.GetList();
                return PartialView("PeriodosPartial", listaperiodos);

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Nuevo(tbl_periodo_evaluacion_Info item)
        {
            try
            {
                var model = new object[0];
                if (ModelState.IsValid)
                {
                    try
                    {
                        periodo_data.guardarDB(item);
                    }
                    catch (Exception e)
                    {
                        ViewData["EditError"] = e.Message;
                    }
                }
                else
                    ViewData["EditError"] = "Please, correct all errors.";
                return RedirectToAction("Index", "Periodo_evaluacion");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Nuevo()
        {
            return View(periodo_info);
            
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Modificar(tbl_periodo_evaluacion_Info item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    periodo_data.modificarDB(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return RedirectToAction("Index", "Periodo_evaluacion");
        }

        public ActionResult Modificar(int IdPeriodo = 0)
        {
            try
            {
                periodo_info = periodo_data.get_info(IdPeriodo);
                return View(periodo_info);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Anular(tbl_periodo_evaluacion_Info item)
        {
            try
            {
                if (item.IdPeriodo >= 0)
                {
                    try
                    {
                        periodo_data.anularDB(item);
                    }
                    catch (Exception e)
                    {
                        ViewData["EditError"] = e.Message;
                    }
                }
                return RedirectToAction("Index", "Periodo_evaluacion");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Anular(int IdPeriodo = 0)
        {
            try
            {
                periodo_info = periodo_data.get_info(IdPeriodo);
                return View(periodo_info);

            }
            catch (Exception)
            {

                throw;
            }
        }



        public ActionResult Cerrar_periodo_partial()
        {
            try
            {
                tbl_periodo_evaluacion_Info model = new tbl_periodo_evaluacion_Info();
                ViewBag.lista_periodos = periodo_data.GetListPeriodos_abiertos();
                return View("_Cerrar_periodoPartial",model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Cerrar_periodo_partial(tbl_periodo_evaluacion_Info item)
        {

            try
            {
                if (periodo_data.cerrar_periodo(item.IdPeriodo))
                    return RedirectToAction("Index", "Periodo_evaluacion");
                else
                    return View("Cerrar_periodo_partial", item);
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}