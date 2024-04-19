 using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace coolBlue.reports
{
	public partial class REPORT_TransactionbyTag : DevExpress.XtraReports.UI.XtraReport
	{	
		public REPORT_TransactionbyTag()
		{
			InitializeComponent();
		}

        private void REPORT_TransactionbyTag_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
			Parameters["endDate"].Value = DateTime.Today;
			Parameters["startDate"].Value = DateTime.Today.AddYears(-1);
			Parameters["accountingPeriod"].Value = 1000;
		}
    }
}
