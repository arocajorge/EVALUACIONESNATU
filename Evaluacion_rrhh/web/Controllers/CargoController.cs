using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Info.general;
using Data.general;
namespace Web.Controllers
{
    public class CargoController : Controller
    {
        rol_cargo_Data cargo_data = new rol_cargo_Data();
        rol_cargo_Info info_cargo = new rol_cargo_Info();
            public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList()
        {
            try
            {
                List<rol_cargo_Info> listaCargo = new List<rol_cargo_Info>();
                listaCargo = cargo_data.get_list();
              
                return PartialView("_Cargo_partial", listaCargo);

            }
            catch (Exception)
            {

                throw;
            }
        }




        [HttpPost, ValidateInput(false)]
        public ActionResult Nuevo(rol_cargo_Info item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    int idcargo = 0;
                    cargo_data.grabarDB(item, ref idcargo);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return RedirectToAction("Index", "Cargo");
        }
        public ActionResult Nuevo()
        {
            info_cargo = new rol_cargo_Info();
            return View(info_cargo);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Modificar(rol_cargo_Info item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    cargo_data.modificarDB(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return RedirectToAction("Index", "Cargo");
        }
        public ActionResult Modificar(int? IdCargo)
        {

            try
            {
                info_cargo = new rol_cargo_Info();
               return View( cargo_data.GetInfo(IdCargo));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Anular(rol_cargo_Info item)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    cargo_data.anularDB(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return RedirectToAction("Index", "Cargo");
        }
        public ActionResult Anular(int? IdCargo)
        {
            try
            {
                info_cargo = new rol_cargo_Info();
                return View(cargo_data.GetInfo(IdCargo));
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}