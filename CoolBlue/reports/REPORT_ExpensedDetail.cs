using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace coolBlue.reports
{
    public partial class REPORT_ExpensedDetail : DevExpress.XtraReports.UI.XtraReport
    {
        public REPORT_ExpensedDetail()
        {
            InitializeComponent();
        }

        private void REPORT_ExpensedDetail_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            Parameters["endDate"].Value = DateTime.Today;
            Parameters["startDate"].Value = DateTime.Today.AddYears(-1);
            Parameters["accountingPeriod"].Value = 1000;
        }
    }
}
