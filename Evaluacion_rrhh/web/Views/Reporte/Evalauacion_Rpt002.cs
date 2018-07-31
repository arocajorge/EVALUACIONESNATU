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
    public partial class Evalauacion_Rpt002 : DevExpress.XtraReports.UI.XtraReport
    {
        public Evalauacion_Rpt002()
        {
            InitializeComponent();
        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                List<tbl_reporte002_Info> lista = new List<tbl_reporte002_Info>();
                tbl_reporte002_Data oda = new tbl_reporte002_Data();
                
                lista = oda.GetList((IdPeriodo.Value)==null?0:Convert.ToInt32(IdPeriodo.Value), Convert.ToDecimal(IdEmpleado.Value), Convert.ToDecimal(IdEmpleado_evaluado.Value));
                DataSource = lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
