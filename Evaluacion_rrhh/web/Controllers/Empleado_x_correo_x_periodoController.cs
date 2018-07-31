using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.general;
using Info.general;
namespace Web.Controllers
{
    public class Empleado_x_correo_x_periodoController : Controller
    {
        rol_empleado_x_correo_x_periodo_Data data = new rol_empleado_x_correo_x_periodo_Data();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EnviarCorreoPartial()
        {
            try
            {
                List<rol_empleado_Info> lista = new List<rol_empleado_Info>();
                lista = data.GetList_emp_a_notificar();

                return PartialView("EnviarCorreoPartial", lista);
            }
            catch (Exception)
            {

                throw;
            }
           
        }



        [HttpPost]
        public ActionResult EnviarCorreoPartial(List<rol_empleado_Info> lista_)
        {
            try
            {
                List<rol_empleado_Info> lista = new List<rol_empleado_Info>();
                lista = data.GetList_emp_a_notificar();
                data.EnviarCorreo(lista);
                return RedirectToAction("Index", "Empleado_x_correo_x_periodo");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}