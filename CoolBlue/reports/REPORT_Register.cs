using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.Grid;

using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using coolBlue.classes;
using DevExpress.Xpf.Core;
using coolBlue.Properties;




//using DevExpress.XtraPrinting;
//using DevExpress.XtraReports.UI;
//using DevExpress.XtraPrinting.Preview;
using DevExpress.Xpf.Printing;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.XtraEditors.DXErrorProvider;

namespace coolBlue.reports
{
    public partial class REPORT_Register : DevExpress.XtraReports.UI.XtraReport
    {
        public int USP_getAllAccountsforAccounts { get; private set; }

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

        private void REPORT_Register_BeforePrint(object sender, CancelEventArgs e)
        {
            string cName = "";
            int nAccountID = 0;
            int nCompanyID = Settings.Default.nCompanyID;
            DevExpress.XtraReports.Parameters.Parameter param =
                (DevExpress.XtraReports.Parameters.Parameter)((DevExpress.XtraReports.UI.XtraReport)sender).
                    Parameters["accountID"];
            if (param != null)
            {
                //REPORT_Register xafParameter =
                //    (REPORT_Register)param.Value;
                nAccountID = (int) param.Value;
            }

            DataSet xx = new coolBlue.AccountsDataSet();
            coolBlue.AccountsDataSet.USP_getAllAccountsDataTable dt = new  coolBlue.AccountsDataSet.USP_getAllAccountsDataTable();
           coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountsTableAdapter accountsDataSetUSP_getAllAccountsTableAdapter = new coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountsTableAdapter();
           accountsDataSetUSP_getAllAccountsTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            accountsDataSetUSP_getAllAccountsTableAdapter.Fill(dt, nCompanyID   );



           // DataRow[] foundRowC = xx.Tables[USP_getAllAccountsforAccounts].Select("ID = " + nAccountID.ToString());
            DataRow[] foundRowC = dt.Select("ID = " + nAccountID.ToString());
            if (foundRowC.Count() > 0)
            {
                cName = (string)foundRowC[0]["cName"];
                xrLabelAccountName.Text = cName;

            }



        }
    }
}
