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
namespace web.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        tbl_reporte001_Data odata = new tbl_reporte001_Data();
        List<tbl_reporte001_Info> lista = new List<tbl_reporte001_Info>();

        tbl_periodo_evaluacion_Data odata_periodo = new tbl_periodo_evaluacion_Data();
        tbl_periodo_evaluacion_Info Info_periodo = new tbl_periodo_evaluacion_Info();
             
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Rpt001()
        {
            try
            {
                int IdPeriodo = 0;
                if (IdPeriodo == null | IdPeriodo == 0)
                {
                    Info_periodo = odata_periodo.GetInfoPeriodoActivo();
                    if (Info_periodo != null)
                        IdPeriodo = Info_periodo.IdPeriodo;
                }
                lista = odata.GetRpt001(Convert.ToInt32(IdPeriodo));

                return PartialView("_Rpt001", lista);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Rpt001(int IdPeriodo)
        {
            try
            {
                if (IdPeriodo == null | IdPeriodo == 0)
                {
                    Info_periodo = odata_periodo.GetInfoPeriodoActivo();
                    if (Info_periodo != null)
                        IdPeriodo = Info_periodo.IdPeriodo;
                }
                lista = odata.GetRpt001(Convert.ToInt32(IdPeriodo));

                return View("_Rpt001", lista);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}