using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.reporte;
using Info.reportes;
using Info.general;
using Data.general;
using web.Views.Reporte;
namespace web.Controllers
{
    public class Resolucion_calificacionController : Controller
    {
        // GET: Reporte
       

        tbl_periodo_evaluacion_Data odata_periodo = new tbl_periodo_evaluacion_Data();
        tbl_periodo_evaluacion_Info Info_periodo = new tbl_periodo_evaluacion_Info();
        rol_empleado_Data odata_empleados = new rol_empleado_Data();

        public ActionResult Resolucion_calificacion_detalle(int IdPeriodo = 0, decimal IdEmpleado = 0, decimal IdEmpleado_evaluado = 0)
        {
            try
            {
                tbl_reporte002_Data odata = new tbl_reporte002_Data();
                List<tbl_reporte002_Info> lista = new List<tbl_reporte002_Info>();
                lista = odata.GetList(Convert.ToInt32(IdPeriodo),IdEmpleado,IdEmpleado_evaluado);
                ViewBag.IdPeriodo = IdPeriodo;
                ViewBag.lst_rpt = lista;

                tbl_reporte002_Info model = new tbl_reporte002_Info { IdPeriodo = IdPeriodo };
                return PartialView("_Resolucion_calificacion_detalle_partial", model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Resolucion_calificacion_x_calificador_partial(int IdPeriodo=0, decimal IdEmpleado=0, decimal Idempleado_evaluado=0)
        {
            try
            {
                tbl_reporte003_Data odata = new tbl_reporte003_Data();
                List<tbl_reporte003_Info> lista = new List<tbl_reporte003_Info>();
                lista = odata.GetList(Convert.ToInt32(IdPeriodo), Convert.ToDecimal(IdEmpleado), Convert.ToDecimal(Idempleado_evaluado));
                ViewBag.IdPeriodo = IdPeriodo;
                ViewBag.IdEmpleado = IdEmpleado;
                ViewBag.Idempleado_evaluado = Idempleado_evaluado;
                ViewBag.lst_rpt = lista;

                tbl_reporte003_Info model = new tbl_reporte003_Info { IdPeriodo = IdPeriodo };
                return PartialView("_Resolucion_calificacion_x_calificador_partial", model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Calificacion_x_empleado(decimal IdEmpleado = 0, int IdPeriodo = 0)
        {
            ViewBag.IdEmpleado = IdEmpleado;
            ViewBag.IdPeriodo = IdPeriodo;
            return View();
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial(decimal IdEmpleado = 0, int IdPeriodo = 0)
        {
            enc_resolucion_calificacion_Data odata = new enc_resolucion_calificacion_Data();
            List<enc_resolucion_calificacion_Info> model = new List<enc_resolucion_calificacion_Info>();
            model = odata.GetList_x_usuario(IdEmpleado, IdPeriodo);
            ViewBag.IdEmpleado = IdEmpleado;
            ViewBag.IdPeriodo = IdPeriodo;
            return PartialView("_GridViewPartial", model);
        }
        public ActionResult Resolucion_calificacion(tbl_reporte001_Info Model)
        {
            try
            {if (Model == null)
                    Model = new tbl_reporte001_Info();

                int IdPeriodo = 0;
                tbl_reporte001_Data odata = new tbl_reporte001_Data();
                List<tbl_reporte001_Info> lista = new List<tbl_reporte001_Info>();
                if (Model.IdPeriodo != 0)
                {
                    lista = odata.GetRpt001(Convert.ToInt32(Model.IdPeriodo));
                    IdPeriodo = Model.IdPeriodo;
                }
                else
                {
                    IdPeriodo = odata_periodo.GetUltimoPeriodo();
                    lista = odata.GetRpt001(Convert.ToInt32(IdPeriodo));
                }

                ViewBag.IdPeriodo = IdPeriodo;
                return PartialView("_Resolucion_calificacion_partial", lista);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult Index()
        {
            tbl_reporte001_Info model = new tbl_reporte001_Info();
            ViewBag.lista_periodos = odata_periodo.GetList();
            Info_periodo = odata_periodo.GetInfoPeriodoActivo();
            if (Info_periodo != null)
                model.IdPeriodo = Info_periodo.IdPeriodo;
            else
                model = new tbl_reporte001_Info();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(tbl_reporte001_Info model)
        {
            ViewBag.lista_periodos = odata_periodo.GetList();
            return View(model);
        }
        public ActionResult Imprimir(int IdPeriodo)
        {
            try
            {
                Evalauacion_Rpt001 model = new Evalauacion_Rpt001();
                if (IdPeriodo == 0)
                    model.IdPeriodo.Value = IdPeriodo = odata_periodo.GetUltimoPeriodo();
                else
                    model.IdPeriodo.Value = IdPeriodo;
                return View("Imprimir", model);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult Index2()
        {
            tbl_reporte002_Info model = new tbl_reporte002_Info();
            ViewBag.lista_periodos = odata_periodo.GetList();
            ViewBag.lista_empleados = odata_empleados.get_list();
            Info_periodo = odata_periodo.GetInfoPeriodoActivo();
            if (Info_periodo != null)
                model.IdPeriodo = Info_periodo.IdPeriodo;
            else
                model = new tbl_reporte002_Info();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index2(tbl_reporte002_Info model)
        {
            ViewBag.lista_periodos = odata_periodo.GetList();
            ViewBag.lista_empleados = odata_empleados.get_list();
            return View(model);
        }
        public ActionResult Imprimir_detalle(int IdPeriodo = 0, decimal IdEmpleado = 0, decimal IdEmpleado_evaluado = 0)
        {
            try
            {
                Evalauacion_Rpt002 model = new Evalauacion_Rpt002();
                model.IdPeriodo.Value = IdPeriodo;
                model.IdEmpleado.Value = IdEmpleado;
                model.IdEmpleado_evaluado.Value = IdEmpleado_evaluado;
                return View("Imprimir_detalle", model);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult Index3()
        {
            tbl_reporte003_Info model = new tbl_reporte003_Info();
            ViewBag.lista_periodos = odata_periodo.GetList();
            ViewBag.lista_empleados = odata_empleados.get_list();
            Info_periodo = odata_periodo.GetInfoPeriodoActivo();
            if (Info_periodo != null)
                model.IdPeriodo = Info_periodo.IdPeriodo;
            else
                model = new tbl_reporte003_Info();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index3(tbl_reporte003_Info model)
        {
            ViewBag.lista_periodos = odata_periodo.GetList();
            ViewBag.lista_empleados = odata_empleados.get_list();

            return View(model);
        }
        public ActionResult Imprimir_calificacion_x_evaluador(int IdPeriodo=0, decimal? IdEmpleado=0,decimal? Idempleado_evaluado=0)
        {
           
            try
            {
                Evalauacion_Rpt003 model = new Evalauacion_Rpt003();
                model.IdPeriodo.Value = IdPeriodo;
                model.IdEmpleado.Value = IdEmpleado;
                model.Idempleado_evaluado.Value = Idempleado_evaluado;

                model.IdPeriodo.Value = IdPeriodo;
                return View("Imprimir_calificacion_x_evaluador", model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        
    }
}