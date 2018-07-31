using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;
using web.Filters;
using web.Models;
using Info.general;
using Data.general;

namespace web.Controllers {
    [WebSecurityAuthorize]
    public class AccountController : Controller {

        tbl_usuario_Data odata = new tbl_usuario_Data();
        rol_empleado_Data odata_empleado = new rol_empleado_Data();
        string mensaje = "";
        [AllowAnonymous]
        public ActionResult Login() {
            FormsAuthentication.SignOut();
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(tbl_usuario_Info model, string returnUrl) {
            try
            {
                decimal IdEmpleado = 0;
                if (string.IsNullOrWhiteSpace(model.IdUsuario) || string.IsNullOrWhiteSpace(model.us_contrasenia))
                {
                    return View(model);
                }

               if(odata.login(model))
                {
                    FormsAuthentication.SetAuthCookie(model.IdUsuario, true);
                    Session["admin"] = "1";
                    return RedirectToAction("Index", "Home");
                }
               else
               {

                    if (odata_empleado.Login(model.IdUsuario, model.us_contrasenia, ref IdEmpleado))
                    {
                        tbl_periodo_evaluacion_Info info_periodo_actual = new tbl_periodo_evaluacion_Info();
                        tbl_periodo_evaluacion_Data data_periodo_actual = new tbl_periodo_evaluacion_Data();
                        info_periodo_actual = data_periodo_actual.get_info(data_periodo_actual.GetUltimoPeriodo());

                        if (info_periodo_actual == null)
                            return RedirectToAction("Mensaje", "Resolucion_formulario", new { mensaje = "No existe periodo de evaluación activo" });

                        if (info_periodo_actual.estado_cierre)
                        {
                            return RedirectToAction("Calificacion_x_empleado", "Resolucion_calificacion", new { IdEmpleado = IdEmpleado, IdPeriodo = info_periodo_actual.IdPeriodo});
                        }

                        enc_resolucion_formulario_Data data_resolucion = new enc_resolucion_formulario_Data();
                        if(data_resolucion.empleado_realizo_encuesta(IdEmpleado, info_periodo_actual.IdPeriodo))
                        {                            
                            return RedirectToAction("Mensaje", "Resolucion_formulario", new { mensaje = "Encuesta realizada exitósamente, espere los resultados" });
                        }

                        Session["IdEmpleado"] = IdEmpleado;
                        Session["admin"] = "0";
                        FormsAuthentication.SetAuthCookie(model.IdUsuario, true);

                        return RedirectToAction("Index", "Resolucion_formulario");
                    }
                    else
                    {
                        return RedirectToAction("Mensaje", "Resolucion_formulario", new { mensaje = "Usted no se encuentra registrado en el sistema de evaluación de personal, comuníquese con sistemas" });
                    }

                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult LogOff() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
        
        public ActionResult Index()
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus) {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch(createStatus) {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion

        public ActionResult Nuevo()
        {
            try
            {
                tbl_usuario_Info model = new tbl_usuario_Info();
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Nuevo(tbl_usuario_Info model)
        {
            try
            {
                if (model == null)
                    return View();
                if (!validar(model, ref mensaje))
                {
                    ViewBag.mensaje = mensaje;
                    return View();
                }
                if (!odata.grabarDB(model))
                {
                    ViewBag.mensaje = mensaje;
                    return View();
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Modificar(string IdUsuario)
        {
            try
            {
                if (IdUsuario == null)
                    return RedirectToAction("Index", "Account");
                tbl_usuario_Info model = odata.GetInfo(IdUsuario);
                if (model == null)
                    return RedirectToAction("Index", "Account");
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Modificar(tbl_usuario_Info model)
        {
            try
            {
                if (model == null)
                    return View();
                if (!validar(model, ref mensaje))
                {
                    ViewBag.mensaje = mensaje;
                    return View();
                }
                if (!odata.modificarDB(model))
                {
                    ViewBag.mensaje = "No se pudo modificar el registro";
                    return View();
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Anular(string IdUsuario)
        {
            try
            {
                if (IdUsuario == null)
                    return RedirectToAction("Index", "Account");
                tbl_usuario_Info model = odata.GetInfo(IdUsuario);
                if (model == null)
                    return RedirectToAction("Index", "Account");
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Anular(tbl_usuario_Info model)
        {
            try
            {
                if (model == null)
                    return View();
                if (!odata.anaularDB(model))
                {
                    ViewBag.mensaje = "No se pudo anular el registro";
                    return View();
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_usuario()
        {
            var model = odata.get_list();
            return PartialView("_GridViewPartial_usuario", model);
        }

        private bool validar(tbl_usuario_Info i_validar, ref string msg)
        {
            try
            {
                if (i_validar.IdUsuario == null)
                {
                    msg = "El campo usuario es obligatorio";
                    return false;
                }
                if (i_validar.us_contrasenia == null)
                {
                    msg = "El compo contraseña es obligatorio";
                    return false;
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = new object[0];
            return PartialView("_GridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(Data.enc_resolucion_formulario item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(Data.enc_resolucion_formulario item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Decimal IdResolucion)
        {
            var model = new object[0];
            if (IdResolucion != null)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model);
        }
    }
}