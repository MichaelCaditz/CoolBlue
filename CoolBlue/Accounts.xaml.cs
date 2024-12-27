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
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using coolBlue.classes;
using DevExpress.Xpf.Core;
using System.ComponentModel;
using System.Drawing;
//using DevExpress.XtraPrinting;
//using DevExpress.XtraReports.UI;
//using DevExpress.XtraPrinting.Preview;
using DevExpress.Xpf.Printing;
using coolBlue.Properties;


namespace coolBlue
{
    /// <summary>
    /// Interaction logic for Accounts.xaml
    /// </summary>
    public partial class Accounts : ThemedWindow
    {
        public Accounts()
        {
            InitializeComponent();
        }

        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {
            int nCompanyID = Settings.Default.nCompanyID;

            coolBlue.EditDataSet editDataSet = ((coolBlue.EditDataSet)(this.FindResource("editDataSet")));

            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesforAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesforAccountsViewSource")));
            //System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));
            //System.Windows.Data.CollectionViewSource uSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountsViewSource")));
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesforAccountsUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesforAccountsUSP_getAllAccountsViewSource")));



            coolBlue.EditDataSetTableAdapters.USP_getAllAccountTypesforAccountsTableAdapter editDataSetUSP_getAllAccountTypesforAccountsTableAdapter = new coolBlue.EditDataSetTableAdapters.USP_getAllAccountTypesforAccountsTableAdapter();
            coolBlue.EditDataSetTableAdapters.USP_getAllAccountsTableAdapter editDataSetUSP_getAllAccountsTableAdapter = new coolBlue.EditDataSetTableAdapters.USP_getAllAccountsTableAdapter();


            //editDataSet.EnforceConstraints = false;

            editDataSetUSP_getAllAccountTypesforAccountsTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            editDataSetUSP_getAllAccountsTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;

            editDataSetUSP_getAllAccountTypesforAccountsTableAdapter.Fill(editDataSet.USP_getAllAccountTypesforAccounts);
            editDataSetUSP_getAllAccountsTableAdapter.Fill(editDataSet.USP_getAllAccounts, nCompanyID);
            
            //editDataSet.EnforceConstraints = true;



            uSP_getAllAccountTypesforAccountsViewSource.View.MoveCurrentToFirst();

            //uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.MoveCurrentToFirst();


            //uSP_getAllAccountsViewSource.View.MoveCurrentToFirst();

           // uSP_getAllAccountTypesDataGrid.FilterString = "[Note] = 'haha'"; //doesn't work
        }
        
        private void TableView_OnCustomCellAppearance(object sender, CustomCellAppearanceEventArgs e)
        {
            if (e.RowSelectionState != SelectionState.None)
            {
                e.Result = e.ConditionalValue;
                e.Handled = true;
            }
        }


        private void BarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

            goDetails();

        }




        private void goDetails()
        {
            int nCompanyID = Settings.Default.nCompanyID;
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesforAccountsUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesforAccountsUSP_getAllAccountsViewSource")));

            DataRowView drv = (DataRowView)uSP_getAllAccountTypesforAccountsUSP_getAllAccountsViewSource.View.CurrentItem;
            int accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
            if (accountCurrent == 0)
            {
                string message = "Please select an account";
                string caption = "CoolBlue";

                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult defaultResult = MessageBoxResult.OK;
                MessageBoxOptions options = MessageBoxOptions.RtlReading;

                MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

                if (result == MessageBoxResult.OK)
                {

                }
                 return;
            }
            editAccount editAccount1 = new editAccount(accountCurrent);
            editAccount1.ShowDialog();

            coolBlue.EditDataSet editDataSet = ((coolBlue.EditDataSet)(this.FindResource("editDataSet")));

            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesforAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesforAccountsViewSource")));
            //System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));
            //System.Windows.Data.CollectionViewSource uSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountsViewSource")));
            //System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));



            //coolBlue.EditDataSetTableAdapters.USP_getAllAccountTypesTableAdapter editDataSetUSP_getAllAccountTypesforAccountsTableAdapter = new coolBlue.EditDataSetTableAdapters.USP_getAllAccountTypesforAccountsTableAdapter();
            coolBlue.EditDataSetTableAdapters.USP_getAllAccountsTableAdapter editDataSetUSP_getAllAccountsTableAdapter = new coolBlue.EditDataSetTableAdapters.USP_getAllAccountsTableAdapter();
            editDataSet.EnforceConstraints = false;

            //editDataSetUSP_getAllAccountTypesTableAdapter.Fill(editDataSet.USP_getAllAccountTypes);
            editDataSetUSP_getAllAccountsTableAdapter.Fill(editDataSet.USP_getAllAccounts,nCompanyID);
            editDataSet.EnforceConstraints = true;



            // uSP_getAllAccountTypesViewSource.View.MoveCurrentToFirst();


        }


        

        private void TableView_RowDoubleClick(object sender, RowDoubleClickEventArgs e)
        {
            goDetails();
        }

        private void Properties_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            goDetails();
        }

        private void BarButtonitemNewAccount_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {


            int TransactID1 = 0;
            //int nAccountTypeID = 0;
            //int nCatID = 0;
            //int nCurrencyID = 0;
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesforAccountsUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesforAccountsUSP_getAllAccountsViewSource")));

            //coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));
            DataRowView drv = (DataRowView)uSP_getAllAccountTypesforAccountsUSP_getAllAccountsViewSource.View.CurrentItem;
            int accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
            int nAccountTypeID = (drv == null ? 0 : DBNull.Value.Equals(drv["nAccountTypeID"]) == true ? 0 : (int)drv["nAccountTypeID"]);
            int nCatID = (drv == null ? 0 : DBNull.Value.Equals(drv["nCatID"]) == true ? 0 : (int)drv["nCatID"]);
            int nCurrencyID = (drv == null ? 0 : DBNull.Value.Equals(drv["nCurrencyID"]) == true ? 0 : (int)drv["nCurrencyID"]);
            int nCompanyID = Settings.Default.nCompanyID;

            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesforAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesforAccountsViewSource")));
            DataRowView drv1 = (DataRowView)uSP_getAllAccountTypesforAccountsViewSource.View.CurrentItem;
            int nID = (drv1 == null ? 0 : DBNull.Value.Equals(drv1["ID"]) == true ? 0 : (int)drv1["ID"]);


            string cPIN = "";
            string cCV = "";
            string cExpiry = "";
            string cAcctNum = "";

            // int accountCurrent = 0;
            // int wasnull = 0;


            if (nID == 0)
            {


                string message = "Account Type Required";
                string caption = "CoolBlue";

                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult defaultResult = MessageBoxResult.OK;
                MessageBoxOptions options = MessageBoxOptions.RtlReading;

                MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

                if (result == MessageBoxResult.OK)
                {

                }
                // return;
            }
            else
            {
                //DataRowView drv = (DataRowView)uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.CurrentItem;
                //accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
            }






            SqlConnection conn = new SqlConnection() { ConnectionString = ProgramSettings.coolblueconnectionString };
            try
            {

                using (SqlCommand cmd3 = new SqlCommand() { Connection = conn, CommandType = CommandType.StoredProcedure })
                {
                    //cmd3.Transaction = trans1;
                    cmd3.Parameters.Clear();
                    cmd3.CommandText = "dbo.USP_insertAccount";
                    cmd3.Parameters.AddWithValue("@nAccountTypeID", nID);
                    cmd3.Parameters.AddWithValue("@nCatID", nCatID);
                    cmd3.Parameters.AddWithValue("@nCurrencyID", nCurrencyID);
                    cmd3.Parameters.AddWithValue("cPIN", cPIN);
                    cmd3.Parameters.AddWithValue("cCV", cCV);
                    cmd3.Parameters.AddWithValue("cExpiry", cExpiry);
                    cmd3.Parameters.AddWithValue("cAcctNum", cAcctNum);
                    cmd3.Parameters.AddWithValue("nCompanyID", nCompanyID);

                    SqlParameter retval = cmd3.Parameters.Add("@transactIdentity", SqlDbType.Int);
                    retval.Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    TransactID1 = (int)cmd3.Parameters["@transactIdentity"].Value;
                }




            }


            catch (Exception ex)
            {
                //utilities.errorLog(System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                System.ArgumentException argEx = new System.ArgumentException("New Line", "", ex);
                throw argEx;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();

                //registerDataSet.EnforceConstraints = false;

                //registerDataSetUSP_getSplitTableAdapter.Fill(registerDataSet.USP_getSplit, accountCurrent);
                //registerDataSetUSP_getLineTableAdapter.Fill(registerDataSet.USP_getLine, accountCurrent);
                // registerDataSet.EnforceConstraints = true;

                //uSP_getLineDataGrid.

                //uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.MoveCurrentToPosition(0);

                //resetButtons();
                //LocateNewLine(TransactID1);

                int nAccountCurrent = TransactID1;
                editAccount editAccount1 = new editAccount(nAccountCurrent);
                editAccount1.ShowDialog();
                coolBlue.EditDataSet editDataSet = ((coolBlue.EditDataSet)(this.FindResource("editDataSet")));

                //System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesViewSource")));
                //System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));
                //System.Windows.Data.CollectionViewSource uSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountsViewSource")));
                // System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));



                // coolBlue.EditDataSetTableAdapters.USP_getAllAccountTypesTableAdapter editDataSetUSP_getAllAccountTypesTableAdapter = new coolBlue.EditDataSetTableAdapters.USP_getAllAccountTypesTableAdapter();
                coolBlue.EditDataSetTableAdapters.USP_getAllAccountsTableAdapter editDataSetUSP_getAllAccountsTableAdapter = new coolBlue.EditDataSetTableAdapters.USP_getAllAccountsTableAdapter();
                editDataSet.EnforceConstraints = false;
                //editDataSetUSP_getAllAccountTypesTableAdapter.Fill(editDataSet.USP_getAllAccountTypes);
                editDataSetUSP_getAllAccountsTableAdapter.Fill(editDataSet.USP_getAllAccounts,nCompanyID);
                editDataSet.EnforceConstraints = true;


                //uSP_getAllAccountTypesViewSource.View.MoveCurrentToFirst();


            }
        }
    }
}
