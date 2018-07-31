using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Info.general;
using Data.general;
namespace Web.Controllers
{
    public class Parametros_correoController : Controller
    {
        tbl_parametros_correo_Info parametro_info = new tbl_parametros_correo_Info();
        tbl_parametros_correo_Data parametro_data = new tbl_parametros_correo_Data();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ParametrosCorreo_partial()
        {
            try
            {
                List<tbl_parametros_correo_Info> lista_parametros = new List<tbl_parametros_correo_Info>();
                lista_parametros = parametro_data.ParametrosCorreoPartial();
                return PartialView("ParametrosCorreoPartial", lista_parametros);

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GuardarDB(tbl_parametros_correo_Info item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    parametro_data.guardarDB(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return RedirectToAction("Index", "Parametros_correo");
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ModificarDB(tbl_parametros_correo_Info item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    parametro_data.ModificarDB(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            return RedirectToAction("Index", "Parametros_correo");
        }


    }
}