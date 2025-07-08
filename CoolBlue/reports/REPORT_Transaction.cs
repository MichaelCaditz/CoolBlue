using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using coolBlue.Properties;


namespace coolBlue.reports
{
    public partial class REPORT_Transaction : DevExpress.XtraReports.UI.XtraReport
    {
        public REPORT_Transaction()
        {
            InitializeComponent();
        }

        private void REPORT_Transaction_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            int nCompanyID = Settings.Default.nCompanyID;

            Parameters["endDate"].Value = DateTime.Today;
            Parameters["startDate"].Value = DateTime.Today.AddYears(-1);
            Parameters["accountingPeriod"].Value = 1001;
            Parameters["companyID"].Value = nCompanyID;
        }
    }
}
