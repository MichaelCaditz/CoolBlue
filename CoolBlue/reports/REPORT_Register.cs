using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace coolBlue.reports
{
    public partial class REPORT_Register : DevExpress.XtraReports.UI.XtraReport
    {
        public REPORT_Register()
        {
            InitializeComponent();
        }

        private void REPORT_Register_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            Parameters["endDate"].Value = DateTime.Today;
            Parameters["startDate"].Value = DateTime.Today.AddYears(-100);
            Parameters["accountingPeriod"].Value = 1000;
        }
    }
}
