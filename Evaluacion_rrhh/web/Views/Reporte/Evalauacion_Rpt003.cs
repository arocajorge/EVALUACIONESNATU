using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Info.reportes;
using Data.reporte;
using System.Collections.Generic;
namespace web.Views.Reporte
{
    public partial class Evalauacion_Rpt003 : DevExpress.XtraReports.UI.XtraReport
    {
        public Evalauacion_Rpt003()
        {
            InitializeComponent();
        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void Evalauacion_Rpt003_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                List<tbl_reporte003_Info> lista = new List<tbl_reporte003_Info>();
                tbl_reporte003_Data oda = new tbl_reporte003_Data();
                lista = oda.GetList((IdPeriodo.Value) == null ? 0 : Convert.ToInt32(IdPeriodo.Value), (IdEmpleado.Value) == null ? 0 : Convert.ToInt32(IdEmpleado.Value), (Idempleado_evaluado.Value) == null ? 0 : Convert.ToDecimal(Idempleado_evaluado.Value));
                DataSource = lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
