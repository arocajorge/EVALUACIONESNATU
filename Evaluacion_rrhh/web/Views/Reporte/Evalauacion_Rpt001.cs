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
    public partial class Evalauacion_Rpt001 : DevExpress.XtraReports.UI.XtraReport
    {
        public Evalauacion_Rpt001()
        {
            InitializeComponent();
        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Evalauacion_Rpt001_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                List<tbl_reporte001_Info> lista = new List<tbl_reporte001_Info>();
                tbl_reporte001_Data oda = new tbl_reporte001_Data();
                lista = oda.GetRpt001((IdPeriodo.Value) == null ? 0 : Convert.ToInt32(IdPeriodo.Value));
                DataSource = lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
