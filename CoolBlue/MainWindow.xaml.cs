﻿using System;
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
using System.Windows.Threading;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Grid.EditForm;
using DevExpress.Xpf.Editors;
//using System.Threading.Tasks;
using coolBlue.Properties;
using DevExpress.DataAccess.Native.Json;
using DevExpress.XtraExport.Helpers;




namespace coolBlue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DevExpress.Xpf.Core.ThemedWindow
    {

        //coolBlue.RegisterDataSet registerDataSet;
        //coolBlue.AccountsDataSet accountsDataSet;


        //coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountsTableAdapter accountsDataSetUSP_getAllAccountsTableAdapter = new coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountsTableAdapter();
        //System.Windows.Data.CollectionViewSource uSP_getAllAccountsViewSource;
        coolBlue.RegisterDataSetTableAdapters.USP_getLineTableAdapter registerDataSetUSP_getLineTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getLineTableAdapter();
        //System.Windows.Data.CollectionViewSource uSP_getLineViewSource1 ;
        coolBlue.RegisterDataSetTableAdapters.USP_getSplitTableAdapter registerDataSetUSP_getSplitTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getSplitTableAdapter();
        //System.Windows.Data.CollectionViewSource uSP_getSplitViewSource1;

        public MainWindow()
        {
            InitializeComponent();



        }

        public bool doCustomColumn = true;



        //public Dictionary<int, decimal> runningBalance = new Dictionary<int, decimal>();





        public int newVendorAdded = 0;
        private void DXRibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {

            openingroutine();
            //runningBalance.Add(1, 1000); //adding a key/value using the Add() method
            //runningBalance.Add(2, 2000);
            //runningBalance.Add(3, 3000);
        }

        private void openingroutine()
        {
            string connString = "";
            string server = Settings.Default.server;
            string database = "coolblue";
            string database1 = "works";
            string username = Settings.Default.username;
            string password = Settings.Default.password;

            int nCompanyID = Settings.Default.nCompanyID;



            ProgramSettings.coolblueconnectionString = String.Format("data source={0};initial catalog={1};password={2};persist security info=True;user id={3};packet size=4096;Connection Timeout=15", server, database, password, username);
            ProgramSettings.worksConnectionString = String.Format("data source='{0}';initial catalog={1};password={2};persist security info=True;user id={3};packet size=4096;Connection Timeout=30", server, database1, password, username);


            this.Title = "coolblue       " + server + ": " + username + "   Company: " + Settings.Default.nCompanyID.ToString();

            coolBlue.AccountsDataSet accountsDataSet = ((coolBlue.AccountsDataSet)(this.FindResource("accountsDataSet")));


            coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountTypesTableAdapter accountsDataSetUSP_getAllAccountTypesTableAdapter = new coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountTypesTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesViewSource")));

            coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountsTableAdapter accountsDataSetUSP_getAllAccountsTableAdapter = new coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountsTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountsViewSource")));

            accountsDataSet.EnforceConstraints = false;

            accountsDataSetUSP_getAllAccountTypesTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            accountsDataSetUSP_getAllAccountTypesTableAdapter.Fill(accountsDataSet.USP_getAllAccountTypes);


            accountsDataSetUSP_getAllAccountsTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            accountsDataSetUSP_getAllAccountsTableAdapter.Fill(accountsDataSet.USP_getAllAccounts, nCompanyID);

            accountsDataSet.EnforceConstraints = true;

            uSP_getAllAccountTypesViewSource.View.MoveCurrentToFirst();
            //uSP_getAllAccountsViewSource.View.MoveCurrentToFirst();

            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));




            coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));

            coolBlue.currencyConversion currencyConversion = ((coolBlue.currencyConversion)(this.FindResource("currencyConversion")));

            //coolBlue.RegisterDataSetTableAdapters.USP_getLineTableAdapter registerDataSetUSP_getLineTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getLineTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getLineViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getLineViewSource1")));


            //coolBlue.RegisterDataSetTableAdapters.USP_getSplitTableAdapter registerDataSetUSP_getSplitTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getSplitTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getSplitViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getSplitViewSource1")));
            //coolBlue.RegisterDataSetTableAdapters.USP_getSubCatsTableAdapter registerDataSetUSP_getSubCatsTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getSubCatsTableAdapter();
            //System.Windows.Data.CollectionViewSource uSP_getSubCatsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getSubCatsViewSource")));
            coolBlue.RegisterDataSetTableAdapters.USP_getAllAccountsForSplitTableAdapter registerDataSetUSP_getAllAccountsForSplitTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getAllAccountsForSplitTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllAccountsForSplitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountsForSplitViewSource")));


            coolBlue.RegisterDataSetTableAdapters.USP_getAllVendorsTableAdapter registerDataSetUSP_getAllVendorsTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getAllVendorsTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllVendorsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllVendorsViewSource")));
            coolBlue.RegisterDataSetTableAdapters.USP_getAllTagsTableAdapter registerDataSetUSP_getAllTagsTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getAllTagsTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllTagsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllTagsViewSource")));
            coolBlue.RegisterDataSetTableAdapters.USP_getAllClassTableAdapter registerDataSetUSP_getAllClassTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getAllClassTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllClassViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllClassViewSource")));
            coolBlue.RegisterDataSetTableAdapters.USP_getAllCurrencyTableAdapter registerDataSetUSP_getAllCurrencyTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getAllCurrencyTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllCurrencyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllCurrencyViewSource")));
            coolBlue.currencyConversionTableAdapters.USP_getAllCurrencyConversionTableAdapter currencyConversionUSP_getAllCurrencyConversionTableAdapter = new coolBlue.currencyConversionTableAdapters.USP_getAllCurrencyConversionTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllCurrencyConversionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllCurrencyConversionViewSource")));

            //I cannot make this work yet
            //System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));

            //registerDataSetUSP_getSubCatsTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            //registerDataSetUSP_getSubCatsTableAdapter.Fill(registerDataSet.USP_getSubCats);
            registerDataSetUSP_getAllAccountsForSplitTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            registerDataSetUSP_getAllAccountsForSplitTableAdapter.Fill(registerDataSet.USP_getAllAccountsForSplit, nCompanyID);
            registerDataSetUSP_getAllVendorsTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            registerDataSetUSP_getAllVendorsTableAdapter.Fill(registerDataSet.USP_getAllVendors);
            registerDataSetUSP_getAllTagsTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            registerDataSetUSP_getAllTagsTableAdapter.Fill(registerDataSet.USP_getAllTags);
            registerDataSetUSP_getAllClassTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            registerDataSetUSP_getAllClassTableAdapter.Fill(registerDataSet.USP_getAllClass);
            registerDataSetUSP_getAllCurrencyTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            registerDataSetUSP_getAllCurrencyTableAdapter.Fill(registerDataSet.USP_getAllCurrency);

            currencyConversionUSP_getAllCurrencyConversionTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            currencyConversionUSP_getAllCurrencyConversionTableAdapter.Fill(currencyConversion.USP_getAllCurrencyConversion);

            //DataRowView drv = (DataRowView)uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.CurrentItem;

            //int accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);


            //registerDataSetUSP_getLineTableAdapter.Fill(registerDataSet.USP_getLine, accountCurrent);
            //registerDataSetUSP_getSplitTableAdapter.Fill(registerDataSet.USP_getSplit, accountCurrent);

            //uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.CurrentChanged += new System.EventHandler (_uSP_getAllAccountTypesUSP_getAllAccountsViewSource_CurentChanged);

            coolBlue.SettingsDataSet settingsDataSet = ((coolBlue.SettingsDataSet)(this.FindResource("settingsDataSet")));

            coolBlue.SettingsDataSetTableAdapters.USP_getAllCompanyTableAdapter settingsDataSetUSP_getAllCompanyTableAdapter = new coolBlue.SettingsDataSetTableAdapters.USP_getAllCompanyTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllCompanyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllCompanyViewSource")));

            settingsDataSetUSP_getAllCompanyTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            settingsDataSetUSP_getAllCompanyTableAdapter.Fill(settingsDataSet.USP_getAllCompany);






            uSP_getLineViewSource1.View.MoveCurrentToFirst();
            uSP_getSplitViewSource1.View.MoveCurrentToFirst();
            //uSP_getSubCatsViewSource.View.MoveCurrentToFirst();
            uSP_getAllVendorsViewSource.View.MoveCurrentToFirst();
            uSP_getAllTagsViewSource.View.MoveCurrentToFirst();
            uSP_getAllClassViewSource.View.MoveCurrentToFirst();
            uSP_getAllCurrencyViewSource.View.MoveCurrentToFirst();
            uSP_getAllAccountsForSplitViewSource.View.MoveCurrentToFirst();
            uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.MoveCurrentToFirst();
            uSP_getAllCurrencyConversionViewSource.View.MoveCurrentToFirst();
            uSP_getAllCompanyViewSource.View.MoveCurrentToFirst();



            TextEditBalance.DisplayFormatString = "#,##0.00;<#,##0.00>";
            TextEditBalanceNative.DisplayFormatString = "#,##0.00;<#,##0.00>";

            //DataTable dt = registerDataSet.USP_getLine;
            //DataRow foundRow = dt.Rows.Find(TransactID1);
            //int rowHandle = dt.Rows.IndexOf(foundRow);
            //uSP_getLineDataGrid.View.FocusedRowHandle = rowHandle;
            //uSP_getLineDataGrid.View.MoveLastRow();

            barEditCompany.EditValue = Settings.Default.nCompanyID;

            ImageBrush myBrush = new ImageBrush();

            myBrush.ImageSource =
                new BitmapImage(new Uri("images\\_NZ90099_100_101.jpg", UriKind.Relative));
            mainGrid.Background = myBrush;


        }

        public bool _uSP_getAllAccountTypesUSP_getAllAccountsViewSource_CurentChanged()
        {
            //I cannot make this work yet
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));

            coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));
            DataRowView drv = (DataRowView)uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.CurrentItem;
            int accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
            int accountingPeriod = Settings.Default.nAccountingPeriodID;
            int company = Settings.Default.nCompanyID;


            registerDataSet.EnforceConstraints = false;
            registerDataSetUSP_getSplitTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            registerDataSetUSP_getSplitTableAdapter.Fill(registerDataSet.USP_getSplit, accountCurrent, accountingPeriod, company);
            registerDataSetUSP_getLineTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            registerDataSetUSP_getLineTableAdapter.Fill(registerDataSet.USP_getLine, accountCurrent, accountingPeriod, company);
            //registerDataSet.EnforceConstraints = true;

            getTotals();
            return true;

        }



        private void uSP_getAllAccountsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));

            coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));
            DataRowView drv = (DataRowView)uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.CurrentItem;
            int accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
            int accountingPeriod = Settings.Default.nAccountingPeriodID;  // this will be changed so value comes from settings
            int company = Settings.Default.nCompanyID;  // this will be changed so value comes from settings

            registerDataSet.EnforceConstraints = false;
            registerDataSetUSP_getSplitTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            registerDataSetUSP_getSplitTableAdapter.Fill(registerDataSet.USP_getSplit, accountCurrent, accountingPeriod, company);
            registerDataSetUSP_getLineTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            registerDataSetUSP_getLineTableAdapter.Fill(registerDataSet.USP_getLine, accountCurrent, accountingPeriod, company);
            //registerDataSet.EnforceConstraints = true;

            getTotals();
        }

        private void insertNewLine()
        {
            int TransactID1 = 0;
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesViewSource")));

            coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));


            int accountCurrent = 0;
            int accountingPeriod = 0;
            int company = 0;
            int accountingTypeCurrent = 0;
            int nCurrencyID = 0;
            int wasnull = 0;
            wasnull = (uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View == null ? 1 : 0);
            if (wasnull == 1)
            {

                // MessageBox.Show("Warning: uSP_getLineViewSource is null", "CoolBlue");
                string message = "Warning: uSP_getAllAccountTypesUSP_getAllAccountsViewSource is null";
                string caption = "CoolBlue";

                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult defaultResult = MessageBoxResult.OK;
                MessageBoxOptions options = MessageBoxOptions.RtlReading;
                // Show message box
                // MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

                // Displays the MessageBox.
                MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

                if (result == MessageBoxResult.OK)
                {

                    // Closes the parent form.

                    //this.Close();

                }
                return;
            }
            else
            {
                DataRowView drv = (DataRowView)uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.CurrentItem;
                accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
                nCurrencyID = (drv == null ? 0 : DBNull.Value.Equals(drv["nCurrencyID"]) == true ? 0 : (int)drv["nCurrencyID"]);
                accountingPeriod = Settings.Default.nAccountingPeriodID;
                company = Settings.Default.nCompanyID;


                DataRowView drv1 = (DataRowView)uSP_getAllAccountTypesViewSource.View.CurrentItem;
                accountingTypeCurrent = (drv1 == null ? 0 : DBNull.Value.Equals(drv1["nAccountingTypeID"]) == true ? 0 : (int)drv1["nAccountingTypeID"]);



            }


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



            SqlConnection conn = new SqlConnection() { ConnectionString = ProgramSettings.coolblueconnectionString };
            try
            {

                using (SqlCommand cmd3 = new SqlCommand() { Connection = conn, CommandType = CommandType.StoredProcedure })
                {
                    //cmd3.Transaction = trans1;
                    cmd3.Parameters.Clear();
                    cmd3.CommandText = "dbo.USP_insertLine";
                    cmd3.Parameters.AddWithValue("@nAccount", accountCurrent);
                    cmd3.Parameters.AddWithValue("@nAccountingPeriod", accountingPeriod);
                    cmd3.Parameters.AddWithValue("@nCompany", company);



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

                registerDataSet.EnforceConstraints = false;
                registerDataSetUSP_getSplitTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
                registerDataSetUSP_getSplitTableAdapter.Fill(registerDataSet.USP_getSplit, accountCurrent, accountingPeriod, company);
                registerDataSetUSP_getLineTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
                registerDataSetUSP_getLineTableAdapter.Fill(registerDataSet.USP_getLine, accountCurrent, accountingPeriod, company);
                // registerDataSet.EnforceConstraints = true;

                //uSP_getLineDataGrid.

                //uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.MoveCurrentToPosition(0);

                //resetButtons();


                //LocateNewLine(TransactID1);
                //coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));
                DataTable dt = registerDataSet.USP_getLine;
                DataRow foundRow = dt.Rows.Find(TransactID1);
                int rowHandle = dt.Rows.IndexOf(foundRow);
                uSP_getLineDataGrid.View.FocusedRowHandle = rowHandle;

                SplitsView.AddNewRow();
                int newRowHandle = DataControlBase.NewItemRowHandle;

                switch (accountingTypeCurrent)
                {

                    case 1000:

                        uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nAccountID_C", accountCurrent);
                        //uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nEntryCurrencyID", nCurrencyID);

                        break;

                    case 1001:

                        uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nAccountID_C", accountCurrent);
                        //uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nEntryCurrencyID", nCurrencyID);

                        break;

                    case 1003:

                        uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nAccountID_D", accountCurrent);
                        //uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nEntryCurrencyID", nCurrencyID);

                        break;

                }
                //these are done in SplitsView_InitNewRow:
                //uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nAmount_C", 0);
                //uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nAmount_D", 0);
                //uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nAmount_C_Native", 0);
                //uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nAmount_D_Native", 0);


                SplitsView.Focus();
                Vendor.Focus();
                //System.Windows.Forms.SendKeys.SendWait("{ENTER}");

                //SplitsView.FocusedRowHandle = 0;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    //SplitsView.ShowInlineEditForm();
                    SplitsView.ShowEditForm();
                }), DispatcherPriority.Render);
                //Dispatcher.BeginInvoke((Action)SplitsView.ShowEditor, DispatcherPriority.Render);


                //LineView.Focus();
            }

            //System.Windows.Data.CollectionViewSource uSP_getLineUSP_getSplitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getLineUSP_getSplitViewSource")));


            //DataRowView drv3;
            // uSP_getLineUSP_getSplitViewSource.View.SourceCollection.

            // registerDataSet.USP_getSplit.Rows.Add();
            // SplitsView.ShowEditor();

            //DataRowView drv3 = (DataRowView)uSP_getLineUSP_getSplitViewSource.View.CurrentItem;
            //uSP_getLineUSP_getSplitViewSource.View.










            //SplitsView.DataControl.RefreshData();
            ////SplitsView.FocusedRowHandle = 99;
            //SplitsView.MoveFirstRow();
            //SplitsView.ShowEditor();

            //SplitsView.DataControl.RefreshData();










            // uSP_getSplitDataGrid.SetCellValue(uSP_getSplitDataGrid.View.FocusedRowHandle, uSP_getSplitDataGrid.Columns["nAmount_C"], 44);

        }

        private void SimpleButton_Click_1(object sender, RoutedEventArgs e)
        {
            insertNewLine();
        }

        public void LocateNewLine(int IDToFind)
        {
            //int IDToFind = Convert.ToInt32(txt_IdUnique.Text);


            //if (IDToFind > -1 )
            {
                //foreach (DataRowView drv in (BindingListCollectionView)uSP_getLineDataGrid.ItemsSource)
                //    if ((int)drv["ID"] == IDToFind)
                //    {
                //        // This is the data row view record you want...
                //        uSP_getLineDataGrid.SelectedItem = drv;


                //        break;
                //    }



                //System.Windows.Data.CollectionViewSource uSP_getLineViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getLineViewSource1")));
                // uSP_getLineViewSource1.View.MoveCurrentTo(0);
                //int rowHandle = uSP_getLineDataGrid.GetRowHandleByListIndex(IDToFind);

                // DataRow dr = DataTable1.Rows.Find([primary key value]);

                //coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));
                //DataTable dt = registerDataSet.USP_getLine;
                //DataRow foundRow = dt.Rows.Find(IDToFind);


                //int rowHandle = dt.Rows.IndexOf(foundRow);


                //uSP_getLineDataGrid.View.FocusedRowHandle = rowHandle;



            }
        }


        private void btnSaveConfig_Click(object sender, RoutedEventArgs e)
        {

            saveConfig();

        }

        private void saveConfig()
        {
            coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));

            int TransactID1 = 0;
            System.Windows.Data.CollectionViewSource uSP_getLineViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getLineViewSource1")));
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));
            System.Windows.Data.CollectionViewSource uSP_getLineUSP_getSplitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getLineUSP_getSplitViewSource")));



            DataRowView drv = (DataRowView)uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.CurrentItem;
            int accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
            int accountingPeriod = Settings.Default.nAccountingPeriodID;  // this will be changed so value comes from settings
            int company = Settings.Default.nCompanyID;  // this will be changed so value comes from settings


            int lineCurrent = 0;
            int wasnull = 0;
            wasnull = (uSP_getLineViewSource1.View == null ? 1 : 0);
            if (wasnull == 1)
            {

                // MessageBox.Show("Warning: uSP_getLineViewSource is null", "CoolBlue");
                string message = "Warning: uSP_getLineViewSource1 is null";
                string caption = "CoolBlue";

                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult defaultResult = MessageBoxResult.OK;
                MessageBoxOptions options = MessageBoxOptions.RtlReading;
                // Show message box
                // MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

                // Displays the MessageBox.
                MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

                if (result == MessageBoxResult.OK)
                {

                    // Closes the parent form.

                    //this.Close();

                }
                return;
            }
            else
            {
                DataRowView drv1 = (DataRowView)uSP_getLineViewSource1.View.CurrentItem;
                lineCurrent = (drv1 == null ? 0 : DBNull.Value.Equals(drv1["ID"]) == true ? 0 : (int)drv1["ID"]);
            }





            SqlConnection conn = new SqlConnection() { ConnectionString = ProgramSettings.coolblueconnectionString };
            try
            {

                using (SqlCommand cmd3 = new SqlCommand() { Connection = conn, CommandType = CommandType.StoredProcedure })
                {
                    //cmd3.Transaction = trans1;
                    cmd3.Parameters.Clear();
                    cmd3.CommandText = "dbo.USP_deleteSplit";
                    cmd3.Parameters.AddWithValue("@nLine", lineCurrent);

                    //SqlParameter retval = cmd3.Parameters.Add("@transactIdentity", SqlDbType.Int);
                    //retval.Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    //TransactID1 = (int)cmd3.Parameters["@transactIdentity"].Value;
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



                //uSP_getLineDataGrid.

                //uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.MoveCurrentToPosition(0);

                //resetButtons();
                //LocateNewLine(TransactID1);
            }

            //write new records in dbo.split
            //int itwasnull = 0;
            //itwasnull = (uSP_getSplitDataGrid.)== null ? 1 : 0;
            //if (itwasnull == 0)


            //var selectedRow = uSP_getSplitDataGrid.GetRow(0);

            //var columnCell = uSP_getSplitDataGrid.GetCell(selectedRow, 0);

            //string content = (uSP_getSplitDataGrid.SelectedCells[0].Column.GetCellContent(0) as TextBlock).Text;
            //MessageBox.Show(content);
            //foreach (DataRowView dv in uSP_getSplitDataGrid.Items)
            //    {


            //            MessageBox.Show(dv[3].ToString());

            //    }
            // foreach (DataRowView drv3 in uSP_getLineUSP_getSplitViewSource.View)
            //{ 
            //int go = 0;

            // DataRowView drv3 = (DataRowView)uSP_getLineUSP_getSplitViewSource.View.CurrentItem;
            //int ID = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["ID"]) == true ? 0 : (int)drv3["ID"]);
            //for (int i=0; i<5; i++)

            //if (ID == 0)
            //{
            //    go = 1;
            //}

            //while (go ==0)
            if (uSP_getLineUSP_getSplitViewSource.View != null)

            {
                SqlConnection conn1 = new SqlConnection() { ConnectionString = ProgramSettings.coolblueconnectionString };
                uSP_getLineUSP_getSplitViewSource.View.MoveCurrentToFirst();

                for (int i = 0; i - 1 < i++; i++)
                {
                    DataRowView drv3 = (DataRowView)uSP_getLineUSP_getSplitViewSource.View.CurrentItem;
                    int ID = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["ID"]) == true ? 0 : (int)drv3["ID"]);
                    //MessageBox.Show(ID.ToString());

                    if (ID == 0)
                    {
                        break;
                    }


                    decimal nAmnt = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["nAmount"]) == true ? 0 : (decimal)drv3["nAmount"]);
                    // MessageBox.Show(nAmnt.ToString());

                    int nXferAccountID = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["nXferAccountID"]) == true ? 0 : (int)drv3["nXferAccountID"]);
                    Boolean bXfer = (drv3 == null ? false : DBNull.Value.Equals(drv3["bXfer"]) == true ? false : (bool)drv3["bXfer"]);

                    int nVendorsID = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["nVendorsID"]) == true ? 0 : (int)drv3["nVendorsID"]);
                    string cMemo = (DBNull.Value.Equals(drv3["cMemo"]) == true ? "" : (string)drv3["cMemo"]);
                    int nTagID = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["nTagID"]) == true ? 0 : (int)drv3["nTagID"]);
                    int nClassID = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["nClassID"]) == true ? 0 : (int)drv3["nClassID"]);
                    int nAccountID = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["nAccountID"]) == true ? 0 : (int)drv3["nAccountID"]);
                    decimal nOriginalAmount = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["nOriginalAmount"]) == true ? 0 : (decimal)drv3["nOriginalAmount"]);
                    int nCurrencyID = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["nCurrencyID"]) == true ? 0 : (int)drv3["nCurrencyID"]);
                    int nAccountID_C = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["nAccountID_C"]) == true ? 0 : (int)drv3["nAccountID_C"]);
                    int nAccountID_D = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["nAccountID_D"]) == true ? 0 : (int)drv3["nAccountID_D"]);
                    decimal nAmount_C = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["nAmount_C"]) == true ? 0 : (decimal)drv3["nAmount_C"]);
                    decimal nAmount_D = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["nAmount_D"]) == true ? 0 : (decimal)drv3["nAmount_D"]);

                    int nEntryCurrencyID = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["nEntryCurrencyID"]) == true ? 0 : (int)drv3["nEntryCurrencyID"]);
                    decimal nAmount_C_Native = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["nAmount_C_Native"]) == true ? 0 : (decimal)drv3["nAmount_C_Native"]);
                    decimal nAmount_D_Native = (drv3 == null ? 0 : DBNull.Value.Equals(drv3["nAmount_D_Native"]) == true ? 0 : (decimal)drv3["nAmount_D_Native"]);




                    /////write new record to dbo.split

                    //SqlConnection conn1 = new SqlConnection() { ConnectionString = ProgramSettings.coolblueconnectionString };
                    try
                    {

                        using (SqlCommand cmd3 = new SqlCommand() { Connection = conn1, CommandType = CommandType.StoredProcedure })
                        {
                            //cmd3.Transaction = trans1;
                            cmd3.Parameters.Clear();
                            cmd3.CommandText = "dbo.USP_insertSplit";
                            cmd3.Parameters.AddWithValue("@lineID", lineCurrent);
                            cmd3.Parameters.AddWithValue("@xferAccountID", nXferAccountID);
                            cmd3.Parameters.AddWithValue("@bXfer", bXfer);
                            cmd3.Parameters.AddWithValue("@amount", nAmnt);
                            cmd3.Parameters.AddWithValue("@vendorsID", nVendorsID);
                            cmd3.Parameters.AddWithValue("@memo", cMemo);
                            cmd3.Parameters.AddWithValue("@tagID", nTagID);
                            cmd3.Parameters.AddWithValue("@classID", nClassID);
                            cmd3.Parameters.AddWithValue("@accountID", accountCurrent);
                            cmd3.Parameters.AddWithValue("@originalAmount", nOriginalAmount);
                            cmd3.Parameters.AddWithValue("@currencyID", nCurrencyID);
                            cmd3.Parameters.AddWithValue("@nAccountID_C", nAccountID_C);
                            cmd3.Parameters.AddWithValue("@nAccountID_D", nAccountID_D);
                            cmd3.Parameters.AddWithValue("@nAmount_C", nAmount_C);
                            cmd3.Parameters.AddWithValue("@nAmount_D", nAmount_D);
                            cmd3.Parameters.AddWithValue("@nEntryCurrencyID", nEntryCurrencyID);
                            cmd3.Parameters.AddWithValue("@nAmount_C_Native", nAmount_C_Native);
                            cmd3.Parameters.AddWithValue("@nAmount_D_Native", nAmount_D_Native);



                            SqlParameter retval = cmd3.Parameters.Add("@transactIdentity", SqlDbType.Int);
                            retval.Direction = ParameterDirection.Output;
                            conn1.Open();
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
                        if (conn1.State == ConnectionState.Open) conn1.Close();

                        //registerDataSet.EnforceConstraints = false;

                        //registerDataSetUSP_getSplitTableAdapter.Fill(registerDataSet.USP_getSplit, accountCurrent);
                        //registerDataSetUSP_getLineTableAdapter.Fill(registerDataSet.USP_getLine, accountCurrent);
                        //registerDataSet.EnforceConstraints = true;

                        ////uSP_getLineDataGrid.

                        ////uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.MoveCurrentToPosition(0);

                        ////resetButtons();
                        //LocateNewLine(TransactID1);
                    }









                    uSP_getLineUSP_getSplitViewSource.View.MoveCurrentToNext();
                }
            }




            registerDataSet.EnforceConstraints = false;
            registerDataSetUSP_getSplitTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            registerDataSetUSP_getSplitTableAdapter.Fill(registerDataSet.USP_getSplit, accountCurrent, accountingPeriod, company);
            registerDataSetUSP_getLineTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            registerDataSetUSP_getLineTableAdapter.Fill(registerDataSet.USP_getLine, accountCurrent, accountingPeriod, company);
            //registerDataSet.EnforceConstraints = true;

            getTotals();

            //LineView.Focus();
            // Vendor.Focus();

            DataTable dt = registerDataSet.USP_getLine;
            DataRow foundRow = dt.Rows.Find(lineCurrent);


            int rowHandle = dt.Rows.IndexOf(foundRow);


            uSP_getLineDataGrid.View.FocusedRowHandle = rowHandle;


        }



        private DataRowView rowBeingEdited = null;

        private void uSP_getSplitDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataRowView rowView = e.Row.Item as DataRowView;
            rowBeingEdited = rowView;
        }

        private void uSP_getSplitDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (rowBeingEdited != null)
            {
                rowBeingEdited.EndEdit();
            }
        }



        private void BarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {




            PrintHelper.ShowPrintPreviewDialog(this, new coolBlue.reports.REPORT_TransactionbyTag());



            //reportViewer reportViewer1 = new reportViewer();

            //coolBlue.reports.REPORT_TransactionbyTag rpt = new coolBlue.reports.REPORT_TransactionbyTag();

            //reportViewer1.documentPreview1.DocumentSource = rpt;

            //reportViewer1.Show();
            //rpt.CreateDocument();

            //////////////////////////////////////////////////////////////////////////////////////////////////////


            //coolBlue.reports.REPORT_Transaction rpt = new coolBlue.reports.REPORT_Transaction();
            //Mouse.OverrideCursor = Cursors.Wait;
            //PrintHelper.ShowPrintPreview(this, rpt);

            //rpt.BringToFront();
            //Mouse.OverrideCursor = null;
        }

        private void barBtnSettings_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            bool bWasCompanyChanged = false;
            settings windowSettings = new settings();
            windowSettings.Title = "coolblue Settings";

            windowSettings.ShowDialog();
            bWasCompanyChanged = windowSettings.bWasCompanyChanged;

            //string server = Settings.Default.server;
            //string database = "coolblue";
            //string database1 = "works";
            //string username = Settings.Default.username;
            //string password = Settings.Default.password;

            if (bWasCompanyChanged == true)
            {
                barEditCompany.EditValue = 0;
                // barEditCompany_EditValueChanged();
                //openingroutine();
                //fillLinesAndSplits();

            }



        }







        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //string message = "Date Changed";
            //string caption = "CoolBlue";

            //MessageBoxButton buttons = MessageBoxButton.OK;
            //MessageBoxImage icon = MessageBoxImage.Information;
            //MessageBoxResult defaultResult = MessageBoxResult.OK;
            //MessageBoxOptions options = MessageBoxOptions.RtlReading;

            //MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);
        }
        private void SimpleButton_Click_2(object sender, RoutedEventArgs e)
        {
            updateLine();
        }
        private void updateLine()
        {
            //string message = "Date Changed";
            //string caption = "CoolBlue";

            //MessageBoxButton buttons = MessageBoxButton.OK;
            //MessageBoxImage icon = MessageBoxImage.Information;
            //MessageBoxResult defaultResult = MessageBoxResult.OK;
            //MessageBoxOptions options = MessageBoxOptions.RtlReading;

            //MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

            //int TransactID1 = 0;
            string notes = "";
            int nCatID = 0;
            string name = "";
            int lineID = 0;

            Nullable<DateTime> TransDate = null;
            System.Windows.Data.CollectionViewSource uSP_getLineViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getLineViewSource1")));

            coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));


            //int accountCurrent = 0;
            int wasnull = 0;
            wasnull = (uSP_getLineViewSource1.View == null ? 1 : 0);
            if (wasnull == 1)
            {

                // MessageBox.Show("Warning: uSP_getLineViewSource is null", "CoolBlue");
                string message = "Warning:uSP_getOneVendorViewSource is null";
                string caption = "CoolBlue";

                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult defaultResult = MessageBoxResult.OK;
                MessageBoxOptions options = MessageBoxOptions.RtlReading;
                // Show message box
                // MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

                // Displays the MessageBox.
                MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

                if (result == MessageBoxResult.OK)
                {

                    // Closes the parent form.

                    //this.Close();

                }
                return;
            }
            else
            {


                DataRowView drv = (DataRowView)uSP_getLineViewSource1.View.CurrentItem;
                //accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
                notes = (DBNull.Value.Equals(drv["cNote"]) == true ? "" : (string)drv["cNote"]);

                // name = (DBNull.Value.Equals(drv["cName"]) == true ? "" : (string)drv["cName"]);
                // notes = "";
                lineID = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);

                // nCatID = (int)LookupEditCat.EditValue;
                TransDate = (drv == null ? (Nullable<DateTime>)null : DBNull.Value.Equals(drv["dtTransDate"]) == true ? (Nullable<DateTime>)null :
             (DateTime)drv["dtTransDate"]);

            }






            SqlConnection conn = new SqlConnection() { ConnectionString = ProgramSettings.coolblueconnectionString };
            try
            {

                using (SqlCommand cmd3 = new SqlCommand() { Connection = conn, CommandType = CommandType.StoredProcedure })
                {
                    //cmd3.Transaction = trans1;
                    cmd3.Parameters.Clear();
                    cmd3.CommandText = "dbo.USP_updateLine";
                    cmd3.Parameters.AddWithValue("@ID", lineID);
                    cmd3.Parameters.AddWithValue("@notes", notes);
                    cmd3.Parameters.AddWithValue("@Transdate", TransDate);



                    //SqlParameter retval = cmd3.Parameters.Add("@transactIdentity", SqlDbType.Int);
                    //retval.Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    //TransactID1 = (int)cmd3.Parameters["@transactIdentity"].Value;
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

                //VendorDataSet.EnforceConstraints = false;

                //coolBlue.vendorDataSetTableAdapters.USP_getOneVendorTableAdapter vendorDataSetUSP_getOneVendorTableAdapter = new coolBlue.vendorDataSetTableAdapters.USP_getOneVendorTableAdapter();


                //vendorDataSetUSP_getOneVendorTableAdapter.Fill(VendorDataSet.USP_getOneVendor, nVendorID);

                //VendorDataSet.EnforceConstraints = true;

                //uSP_getLineDataGrid.

                //uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.MoveCurrentToPosition(0);

                //resetButtons();
                // LocateNewLine(TransactID1);
                // this.Close();

            }
        }

        private void TableView_OnCustomCellAppearance(object sender, CustomCellAppearanceEventArgs e)
        {
            if (e.RowSelectionState != SelectionState.None)
            {
                e.Result = e.ConditionalValue;
                e.Handled = true;
            }
        }

        private void GridControl_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            fillLinesAndSplits();

        }

        private void fillLinesAndSplits()
        {

            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));
            //System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesViewSource")));

            coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));

            // uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.MoveCurrentToFirst();

            //if (uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View ! = null)
            if (uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View != null)
            {


                DataRowView drv = (DataRowView)uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.CurrentItem;
                int accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
                int accountingPeriod = Settings.Default.nAccountingPeriodID;  // this will be changed so value comes from settings
                int company = Settings.Default.nCompanyID;  // this will be changed so value comes from settings


                //DataRowView drv1 = (DataRowView)uSP_getAllAccountTypesViewSource.View.CurrentItem;
                //int nAccountingTypeID = (drv1 == null ? 0 : DBNull.Value.Equals(drv1["nAccountingTypeID"]) == true ? 0 : (int)drv1["nAccountingTypeID"]);


                registerDataSet.EnforceConstraints = false;
                registerDataSetUSP_getSplitTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
                registerDataSetUSP_getSplitTableAdapter.Fill(registerDataSet.USP_getSplit, accountCurrent, accountingPeriod, company);
                registerDataSetUSP_getLineTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
                registerDataSetUSP_getLineTableAdapter.Fill(registerDataSet.USP_getLine, accountCurrent, accountingPeriod, company);
                //registerDataSet.EnforceConstraints = true;

                getTotals();


            }
        }

        private void getTotals()
        {
            coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesViewSource")));
            DataRowView drv1 = (DataRowView)uSP_getAllAccountTypesViewSource.View.CurrentItem;
            int nAccountingTypeID = (drv1 == null ? 0 : DBNull.Value.Equals(drv1["nAccountingTypeID"]) == true ? 0 : (int)drv1["nAccountingTypeID"]);

            decimal sumDr = 0;
            decimal sumDrNative = 0;
            foreach (DataRow dr in registerDataSet.USP_getLine.Rows)
            {

                sumDr += (decimal)dr["totalDr"];
                sumDrNative += (decimal)dr["totalDrNative"];

            }

            decimal sumCr = 0;
            decimal sumCrNative = 0;
            foreach (DataRow dr in registerDataSet.USP_getLine.Rows)
            {

                sumCr += (decimal)dr["totalCr"];
                sumCrNative += (decimal)dr["totalCrNative"];

            }
            decimal sumTotal = 0;
            decimal sumTotalNative = 0;
            switch (nAccountingTypeID)
            {
                case 1000://current asset - bank account

                    sumTotal = sumDr - sumCr;
                    sumTotalNative = sumDrNative - sumCrNative;
                    break;

                case 1001://curent liability - credit card

                    sumTotal = sumCr - sumDr;
                    sumTotalNative = sumCrNative - sumDrNative;
                    break;

                case 1003://expense

                    sumTotal = sumDr - sumCr;
                    sumTotalNative = sumDrNative - sumCrNative;
                    break;

                case 1002://revenue

                    sumTotal = sumCr - sumDr;
                    sumTotalNative = sumCrNative - sumDrNative;
                    break;

                default:
                    sumTotal = sumDr - sumCr;
                    sumTotalNative = sumDrNative - sumCrNative;
                    break;
            }



            TextEditTotalDr.EditValue = sumDr;
            TextEditTotalCr.EditValue = sumCr;
            TextEditBalance.EditValue = sumTotal;

            TextEditTotalDrNative.EditValue = sumDrNative;
            TextEditTotalCrNative.EditValue = sumCrNative;
            TextEditBalanceNative.EditValue = sumTotalNative;

            updateRunningTotals();


        }

        private void TableView_RowDoubleClick(object sender, RowDoubleClickEventArgs e)
        {
            goDetails();
        }

        private void goDetails()
        {

            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));

            DataRowView drv = (DataRowView)uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.CurrentItem;
            int accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);

            int nCompanyID = Settings.Default.nCompanyID;



            BindingListCollectionView dv = (BindingListCollectionView)uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View;
            int rowIndex = dv.IndexOf(drv);


            editAccount editAccoun1 = new editAccount(accountCurrent);

            editAccoun1.bNameChanged = false;
            editAccoun1.ShowDialog();
            if (editAccoun1.bNameChanged == true)
            {
                coolBlue.AccountsDataSet accountsDataSet = ((coolBlue.AccountsDataSet)(this.FindResource("accountsDataSet")));
                System.Windows.Data.CollectionViewSource uSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountsViewSource")));


                coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountsTableAdapter accountsDataSetUSP_getAllAccountsTableAdapter = new coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountsTableAdapter();


                accountsDataSet.EnforceConstraints = false;

                accountsDataSetUSP_getAllAccountsTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
                accountsDataSetUSP_getAllAccountsTableAdapter.Fill(accountsDataSet.USP_getAllAccounts, nCompanyID);
                accountsDataSet.EnforceConstraints = true;

                uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.MoveCurrentToPosition(rowIndex);

            }











            // uSP_getAllAccountTypesViewSource.View.MoveCurrentToFirst();


        }

        private void Properties_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            goDetails();
        }


        private void TableView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //updateLine();
        }

        private void TableView_ValidateRow(object sender, GridRowValidationEventArgs e)
        {
            updateLine();
        }

        private void Exit_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            //System.Windows.Application.Current.Shutdown();

            // (TableView)SplitsView.


            New.Focus(); //needed in case user was still typing in splitsview so validate runs

            if (((TableView)SplitsView).HasValidationError)
            {
                return;
            }

            this.Close();
            Application.Current.Shutdown();
        }

        private void SplitsView_ShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            e.Cancel = false;
        }



        private void SplitsView_ValidateRow(object sender, GridRowValidationEventArgs e)
        {
            //TROUBLE getting nCurrencyID of CR and Dr accounts/////////////////////////////
            int curRowHandle = e.RowHandle;
            int CrCurrencyID = 0;
            int DrCurrencyID = 0;


            int nAccountID_C = (uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAccountID_C") == null ? 0 : DBNull.Value.Equals(uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAccountID_C")) == true ? 0 : (int)uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAccountID_C"));
            string cAccountID = nAccountID_C.ToString();

            int nAccountID_D = (uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAccountID_D") == null ? 0 : DBNull.Value.Equals(uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAccountID_D")) == true ? 0 : (int)uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAccountID_D"));
            string dAccountID = nAccountID_D.ToString();

            coolBlue.AccountsDataSet accountsDataSet = ((coolBlue.AccountsDataSet)(this.FindResource("accountsDataSet")));
            //coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountsTableAdapter accountsDataSetUSP_getAllAccountsTableAdapter = new coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountsTableAdapter();
            //accountsDataSetUSP_getAllAccountsTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            //accountsDataSetUSP_getAllAccountsTableAdapter.Fill(accountsDataSet.USP_getAllAccounts);



            DataRow[] foundRowC = accountsDataSet.USP_getAllAccounts.Select("ID = " + cAccountID);
            if (foundRowC.Count() > 0)
            {
                CrCurrencyID = (int)foundRowC[0]["nCurrencyID"];


            }

            DataRow[] foundRowD = accountsDataSet.USP_getAllAccounts.Select("ID = " + dAccountID);
            if (foundRowD.Count() > 0)
            {
                DrCurrencyID = (int)foundRowD[0]["nCurrencyID"];


            }


            ///NEED THIS://////////////////////////////////////////////////////////////////////////////////////////
            uSP_getSplitDataGrid.SetCellValue(e.RowHandle, "nCrCurrencyID", CrCurrencyID);
            uSP_getSplitDataGrid.SetCellValue(e.RowHandle, "nDrCurrencyID", DrCurrencyID);
            ///////////////////////////////////////////////////////////////////////////////////////////////////

            decimal crAmount = (uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_C") == null ? 0 : DBNull.Value.Equals(uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_C")) == true ? 0 : (decimal)uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_C"));
            decimal drAmount = (uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_D") == null ? 0 : DBNull.Value.Equals(uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_D")) == true ? 0 : (decimal)uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_D"));
            int nEntryCurrencyID = (uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nEntryCurrencyID") == null ? 0 : DBNull.Value.Equals(uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nEntryCurrencyID")) == true ? 0 : (int)uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nEntryCurrencyID"));

            // int nDrCurrencyID = (uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nDrCurrencyID") == null ? 0 : DBNull.Value.Equals(uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nDrCurrencyID")) == true ? 0 : (int)uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nDrCurrencyID"));
            //int nCrCurrencyID = (uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nCrCurrencyID") == null ? 0 : DBNull.Value.Equals(uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nCrCurrencyID")) == true ? 0 : (int)uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nCrCurrencyID"));
            if (nAccountID_D == 0)
            {
                e.IsValid = false;
                e.ErrorType = ErrorType.Critical;
                e.ErrorContent = string.Format("Pleae specify DR account");
                return;
            }

            if (nAccountID_C == 0)
            {
                e.IsValid = false;
                e.ErrorType = ErrorType.Critical;
                e.ErrorContent = string.Format("Pleae specify CR account");
                return;
            }

            if (crAmount == 0 && drAmount == 0)


            {
                e.IsValid = false;
                e.ErrorType = ErrorType.Critical;
                e.ErrorContent = string.Format("Pleae specify Dr or CR amount");
                return;
            }




            if (nEntryCurrencyID == 0)


            {
                e.IsValid = false;
                e.ErrorType = ErrorType.Critical;
                e.ErrorContent = string.Format("Pleae specify transaction currency");
                return;
            }
            if (crAmount == 0)
            {
                uSP_getSplitDataGrid.SetCellValue(curRowHandle, "nAmount_C", drAmount);
            }

            if (drAmount == 0)
            {
                uSP_getSplitDataGrid.SetCellValue(curRowHandle, "nAmount_D", crAmount);
            }


            decimal nOldCNative = (uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_C_Native") == null ? 0 : DBNull.Value.Equals(uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_C_Native")) == true ? 0 : (decimal)uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_C_Native"));
            decimal nOldDNative = (uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_D_Native") == null ? 0 : DBNull.Value.Equals(uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_D_Native")) == true ? 0 : (decimal)uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_D_Native"));


            crAmount = (uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_C") == null ? 0 : DBNull.Value.Equals(uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_C")) == true ? 0 : (decimal)uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_C"));
            drAmount = (uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_D") == null ? 0 : DBNull.Value.Equals(uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_D")) == true ? 0 : (decimal)uSP_getSplitDataGrid.GetCellValue(e.RowHandle, "nAmount_D"));


            if (nOldCNative == 0m)
            {
                if (CrCurrencyID == nEntryCurrencyID)

                {

                    uSP_getSplitDataGrid.SetCellValue(curRowHandle, "nAmount_C_Native", crAmount);

                }
                else
                {
                    crAmount = getAdjustedCurrency(crAmount, nEntryCurrencyID, CrCurrencyID);


                    uSP_getSplitDataGrid.SetCellValue(curRowHandle, "nAmount_C_Native", crAmount);
                }

            }

            if (nOldDNative == 0m)
            {
                if (DrCurrencyID == nEntryCurrencyID)

                {

                    uSP_getSplitDataGrid.SetCellValue(curRowHandle, "nAmount_D_Native", drAmount);

                }
                else
                {
                    drAmount = getAdjustedCurrency(drAmount, nEntryCurrencyID, DrCurrencyID);

                    uSP_getSplitDataGrid.SetCellValue(curRowHandle, "nAmount_D_Native", drAmount);
                }

            }

            //if (drAmount == 0)
            //{
            //    e.IsValid = false;
            //    e.ErrorType = ErrorType.Critical;
            //    e.ErrorContent = string.Format("Pleae specify debit amount");
            //    return;
            //}

            //decimal drAmount = ((Task)e.Row).nAmount_D;
            //e.IsValid = crAmount > 0;
            ////decimal crAmount = e.n
            ///
            if (newVendorAdded > 0)
            {



                uSP_getSplitDataGrid.SetFocusedRowCellValue("nVendorsID", newVendorAdded);
                newVendorAdded = 0;
            }
            saveConfig();
        }


        private decimal getAdjustedCurrency(decimal nAmount, int nFromCurrencyID, int nToCurrencyID)
        {

            decimal newAmount = 999999;
            if (nToCurrencyID > 0)
            {

                string cFromCurrencyID = nFromCurrencyID.ToString();
                string cToCurrencyID = "n" + nToCurrencyID.ToString();
                coolBlue.currencyConversion currencyConversion = ((coolBlue.currencyConversion)(this.FindResource("currencyConversion")));
                DataRow[] foundRowC = currencyConversion.USP_getAllCurrencyConversion.Select("nFrom = " + cFromCurrencyID);
                if (foundRowC.Count() > 0)
                {
                    newAmount = (decimal)foundRowC[0][cToCurrencyID] * nAmount;


                }
            }
            else
            {
                newAmount = 0;

            }


            return newAmount;
        }

        private void SplitsView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            // e.ExceptionMode = ExceptionMode.NoAction;
            e.WindowCaption = "CoolBlue";
            // e.ErrorText = "Would you like to make a correction?";

        }

        private void SplitsView_ValidateCell(object sender, GridCellValidationEventArgs e)
        {
            //decimal crAmount = ((sender) sender.).nAmount_D;
        }
















        private void DXRibbonWindow_Closing(object sender, CancelEventArgs e)
        {
            New.Focus(); //needed in case user was still typing in splitsview so validate runs

            if (((TableView)SplitsView).HasValidationError)
            {
                e.Cancel = true;
            }

            Settings.Default.Save();
        }

        private void NewTrans_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            insertNewLine();
        }

        private void SplitsView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //this doesn't work because editform won't refresh  --by design - - will Devepspress addt his functionality?
            //if (e.Column.FieldName == "nAmount_D")


            //{
            //    int curRowHandle = SplitsView.FocusedRowHandle;

            //    decimal curValue = (decimal) uSP_getSplitDataGrid. GetCellValue(curRowHandle, "nAmount_C");
            //    if (  curValue == 0)
            //        {

            //        uSP_getSplitDataGrid.SetCellValue(curRowHandle, "nAmount_C", 20);
            //        }

            //}


        }

        private void BarButtonItemClass_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            Classes Classes1 = new Classes();
            Classes1.ShowDialog();

            coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));

            coolBlue.RegisterDataSetTableAdapters.USP_getAllClassTableAdapter registerDataSetUSP_getAllClassTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getAllClassTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllClassViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllClassViewSource")));

            registerDataSetUSP_getAllClassTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            registerDataSetUSP_getAllClassTableAdapter.Fill(registerDataSet.USP_getAllClass);






        }

        private void BarButtonItemCategory_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            categories categories1 = new categories();
            categories1.ShowDialog();

            //coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));

            //coolBlue.RegisterDataSetTableAdapters.USP_getSubCatsTableAdapter registerDataSetUSP_getSubCatsTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getSubCatsTableAdapter();
            //System.Windows.Data.CollectionViewSource uSP_getSubCatsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getSubCatsViewSource")));
            //registerDataSetUSP_getSubCatsTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            //registerDataSetUSP_getSubCatsTableAdapter.Fill(registerDataSet.USP_getSubCats);
        }

        private void BarButtonItemVendor_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            Vendors Vendors1 = new Vendors();


            //coolBlue.reports.REPORT_Transaction rpt = new coolBlue.reports.REPORT_Transaction();
            //Mouse.OverrideCursor = Cursors.Wait;
            //PrintHelper.ShowPrintPreview(this, rpt);
            // reportViewer1.documentPreview1.DocumentSource = rpt;

            //rpt.Parameters["@accountID"].Value = 1;


            Vendors1.ShowDialog();
            coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));

            coolBlue.RegisterDataSetTableAdapters.USP_getAllVendorsTableAdapter registerDataSetUSP_getAllVendorsTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getAllVendorsTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllVendorsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllVendorsViewSource")));
            registerDataSetUSP_getAllVendorsTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            registerDataSetUSP_getAllVendorsTableAdapter.Fill(registerDataSet.USP_getAllVendors);
        }

        private void BarButtonItemAccount_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            Accounts Accounts1 = new Accounts();
            Accounts1.ShowDialog();

            int nCompanyID = Settings.Default.nCompanyID;


            coolBlue.AccountsDataSet accountsDataSet = ((coolBlue.AccountsDataSet)(this.FindResource("accountsDataSet")));
            coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));


            //coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountTypesTableAdapter accountsDataSetUSP_getAllAccountTypesTableAdapter = new coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountTypesTableAdapter();
            //System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesViewSource")));

            coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountsTableAdapter accountsDataSetUSP_getAllAccountsTableAdapter = new coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountsTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountsViewSource")));


            coolBlue.RegisterDataSetTableAdapters.USP_getAllAccountsForSplitTableAdapter registerDataSetUSP_getAllAccountsForSplitTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getAllAccountsForSplitTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllAccountsForSplitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountsForSplitViewSource")));


            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));
            System.Windows.Data.CollectionViewSource uSP_getLineViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getLineViewSource1")));


            int uSP_getAllAccountTypesUSP_getAllAccountsViewSourceCurPos = uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.CurrentPosition;
            int uSP_getLineViewSource1CurPos = uSP_getLineViewSource1.View.CurrentPosition;

            accountsDataSet.EnforceConstraints = false;
            // accountsDataSetUSP_getAllAccountTypesTableAdapter.Fill(accountsDataSet.USP_getAllAccountTypes);
            accountsDataSetUSP_getAllAccountsTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            accountsDataSetUSP_getAllAccountsTableAdapter.Fill(accountsDataSet.USP_getAllAccounts, nCompanyID);
            accountsDataSet.EnforceConstraints = true;

            //registerDataSet.EnforceConstraints = false;
            registerDataSetUSP_getAllAccountsForSplitTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            registerDataSetUSP_getAllAccountsForSplitTableAdapter.Fill(registerDataSet.USP_getAllAccountsForSplit, nCompanyID);
            //registerDataSet.EnforceConstraints = true; //throws error


            //uSP_getAllAccountTypesViewSource.View.MoveCurrentToFirst();


            // uSP_getAllAccountsViewSource.View.MoveCurrentToFirst();
            uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.MoveCurrentToPosition(uSP_getAllAccountTypesUSP_getAllAccountsViewSourceCurPos);
            uSP_getLineViewSource1.View.MoveCurrentToPosition(uSP_getLineViewSource1CurPos);


            //System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));

        }

        private void BarButtonItemTag_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            Tags Tags1 = new Tags();
            Tags1.ShowDialog();

            coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));
            coolBlue.RegisterDataSetTableAdapters.USP_getAllTagsTableAdapter registerDataSetUSP_getAllTagsTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getAllTagsTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllTagsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllTagsViewSource")));
            registerDataSetUSP_getAllTagsTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            registerDataSetUSP_getAllTagsTableAdapter.Fill(registerDataSet.USP_getAllTags);


        }

        private void BarButtonItemCurrency_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            Currency Currency1 = new Currency();
            Currency1.ShowDialog();

            coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));

            coolBlue.RegisterDataSetTableAdapters.USP_getAllCurrencyTableAdapter registerDataSetUSP_getAllCurrencyTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getAllCurrencyTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllCurrencyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllCurrencyViewSource")));
            registerDataSetUSP_getAllCurrencyTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            registerDataSetUSP_getAllCurrencyTableAdapter.Fill(registerDataSet.USP_getAllCurrency);




        }



        private void SplitsView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesViewSource")));

            coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));


            DataRowView drv = (DataRowView)uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.CurrentItem;
            int accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
            int nCurrencyID = (drv == null ? 0 : DBNull.Value.Equals(drv["nCurrencyID"]) == true ? 0 : (int)drv["nCurrencyID"]);
            int accountingPeriod = Settings.Default.nAccountingPeriodID;  // this will be changed so value comes from settings
            int company = Settings.Default.nCompanyID;  // this will be changed so value comes from settings


            DataRowView drv1 = (DataRowView)uSP_getAllAccountTypesViewSource.View.CurrentItem;
            int accountingTypeCurrent = (drv1 == null ? 0 : DBNull.Value.Equals(drv1["nAccountingTypeID"]) == true ? 0 : (int)drv1["nAccountingTypeID"]);

            uSP_getSplitDataGrid.SetCellValue(e.RowHandle, "nEntryCurrencyID", nCurrencyID);

            uSP_getSplitDataGrid.SetCellValue(e.RowHandle, "nAmount_C", 0);
            uSP_getSplitDataGrid.SetCellValue(e.RowHandle, "nAmount_D", 0);
            uSP_getSplitDataGrid.SetCellValue(e.RowHandle, "nAmount_C_Native", 0);
            uSP_getSplitDataGrid.SetCellValue(e.RowHandle, "nAmount_D_Native", 0);
        }

        private void DeleteLine_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

            deleteTrans();

        }

        private void DeleteSplitRightClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

            deleteSplit();

        }




        private void deleteTrans()
        {
            System.Windows.Data.CollectionViewSource uSP_getLineViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getLineViewSource1")));
            DataRowView drv1 = (DataRowView)uSP_getLineViewSource1.View.CurrentItem;
            int lineCurrent = (drv1 == null ? 0 : DBNull.Value.Equals(drv1["ID"]) == true ? 0 : (int)drv1["ID"]);
            if (lineCurrent == 0)
            {
                string message5 = "Please select a transaction";
                string caption5 = "CoolBlue";

                MessageBoxButton buttons5 = MessageBoxButton.OK;
                MessageBoxImage icon5 = MessageBoxImage.Warning;
                MessageBoxResult defaultResult5 = MessageBoxResult.OK;
                MessageBoxOptions options5 = MessageBoxOptions.None;
                // Show message box
                // MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

                // Displays the MessageBox.
                MessageBoxResult result5 = MessageBox.Show(message5, caption5, buttons5, icon5, defaultResult5, options5);
                return;
            }



            string message = "Do you want to delete this entire transaction?";
            string caption = "CoolBlue";

            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult defaultResult = MessageBoxResult.No;
            MessageBoxOptions options = MessageBoxOptions.None;
            // Show message box
            // MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

            // Displays the MessageBox.
            MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

            if (result == MessageBoxResult.No)
            {

                // Closes the parent form.

                //this.Close();
                return;
            }


            else
            {
                coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));

                int TransactID1 = 0;
                //System.Windows.Data.CollectionViewSource uSP_getLineViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getLineViewSource1")));
                System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));
                System.Windows.Data.CollectionViewSource uSP_getLineUSP_getSplitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getLineUSP_getSplitViewSource")));



                DataRowView drv = (DataRowView)uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.CurrentItem;
                int accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
                int accountingPeriod = Settings.Default.nAccountingPeriodID;  // this will be changed so value comes from settings
                int company = Settings.Default.nCompanyID;  // this will be changed so value comes from settings

                //int lineCurrent = 0;
                int wasnull = 0;
                wasnull = (uSP_getLineViewSource1.View == null ? 1 : 0);
                if (wasnull == 1)
                {

                    // MessageBox.Show("Warning: uSP_getLineViewSource is null", "CoolBlue");
                    string message1 = "Warning: uSP_getLineViewSource1 is null";
                    string caption1 = "CoolBlue";

                    MessageBoxButton buttons1 = MessageBoxButton.OK;
                    MessageBoxImage icon1 = MessageBoxImage.Information;
                    MessageBoxResult defaultResult1 = MessageBoxResult.OK;
                    MessageBoxOptions options1 = MessageBoxOptions.RtlReading;
                    // Show message box
                    // MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

                    // Displays the MessageBox.
                    MessageBoxResult result1 = MessageBox.Show(message1, caption1, buttons1, icon1, defaultResult1, options1);

                    if (result1 == MessageBoxResult.OK)
                    {

                        // Closes the parent form.

                        //this.Close();

                    }
                    return;
                }
                else
                {
                    //DataRowView drv1 = (DataRowView)uSP_getLineViewSource1.View.CurrentItem;
                    //lineCurrent = (drv1 == null ? 0 : DBNull.Value.Equals(drv1["ID"]) == true ? 0 : (int)drv1["ID"]);
                }





                SqlConnection conn = new SqlConnection() { ConnectionString = ProgramSettings.coolblueconnectionString };
                try
                {

                    using (SqlCommand cmd3 = new SqlCommand() { Connection = conn, CommandType = CommandType.StoredProcedure })
                    {
                        //cmd3.Transaction = trans1;
                        cmd3.Parameters.Clear();
                        cmd3.CommandText = "dbo.USP_deleteSplit";
                        cmd3.Parameters.AddWithValue("@nLine", lineCurrent);

                        //SqlParameter retval = cmd3.Parameters.Add("@transactIdentity", SqlDbType.Int);
                        //retval.Direction = ParameterDirection.Output;
                        conn.Open();
                        cmd3.ExecuteNonQuery();
                        //TransactID1 = (int)cmd3.Parameters["@transactIdentity"].Value;
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



                    //uSP_getLineDataGrid.

                    //uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.MoveCurrentToPosition(0);

                    //resetButtons();
                    //LocateNewLine(TransactID1);
                }

                SqlConnection conn1 = new SqlConnection() { ConnectionString = ProgramSettings.coolblueconnectionString };
                try
                {

                    using (SqlCommand cmd3 = new SqlCommand() { Connection = conn1, CommandType = CommandType.StoredProcedure })
                    {
                        //cmd3.Transaction = trans1;
                        cmd3.Parameters.Clear();
                        cmd3.CommandText = "dbo.USP_deleteLine";
                        cmd3.Parameters.AddWithValue("@nLine", lineCurrent);

                        //SqlParameter retval = cmd3.Parameters.Add("@transactIdentity", SqlDbType.Int);
                        //retval.Direction = ParameterDirection.Output;
                        conn1.Open();
                        cmd3.ExecuteNonQuery();
                        //TransactID1 = (int)cmd3.Parameters["@transactIdentity"].Value;
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
                    if (conn1.State == ConnectionState.Open) conn1.Close();



                    registerDataSet.EnforceConstraints = false;
                    registerDataSetUSP_getSplitTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
                    registerDataSetUSP_getSplitTableAdapter.Fill(registerDataSet.USP_getSplit, accountCurrent, accountingPeriod, company);
                    registerDataSetUSP_getLineTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
                    registerDataSetUSP_getLineTableAdapter.Fill(registerDataSet.USP_getLine, accountCurrent, accountingPeriod, company);
                    //registerDataSet.EnforceConstraints = true;

                    getTotals();
                }
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            deleteTrans();
        }

        private void REPORT_ExpenseDetail_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            PrintHelper.ShowPrintPreviewDialog(this, new coolBlue.reports.REPORT_ExpensedDetail());


        }

        private void REPORT_Register_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            PrintHelper.ShowPrintPreviewDialog(this, new coolBlue.reports.REPORT_Register());

        }

        private void DeleteSplit_Click(object sender, RoutedEventArgs e)
        {
            deleteSplit();
        }
        private void deleteSplit()
        {

            System.Windows.Data.CollectionViewSource uSP_getLineViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getLineViewSource1")));
            DataRowView drv = (DataRowView)uSP_getLineViewSource1.View.CurrentItem;
            int lineCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);



            System.Windows.Data.CollectionViewSource uSP_getLineUSP_getSplitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getLineUSP_getSplitViewSource")));
            DataRowView drv1 = (DataRowView)uSP_getLineUSP_getSplitViewSource.View.CurrentItem;
            int nSplitID = (drv1 == null ? 0 : DBNull.Value.Equals(drv1["ID"]) == true ? 0 : (int)drv1["ID"]);
            if (nSplitID == 0)
            {
                string message5 = "Please select an entry";
                string caption5 = "CoolBlue";

                MessageBoxButton buttons5 = MessageBoxButton.OK;
                MessageBoxImage icon5 = MessageBoxImage.Warning;
                MessageBoxResult defaultResult5 = MessageBoxResult.OK;
                MessageBoxOptions options5 = MessageBoxOptions.None;
                // Show message box
                // MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

                // Displays the MessageBox.
                MessageBoxResult result5 = MessageBox.Show(message5, caption5, buttons5, icon5, defaultResult5, options5);
                return;
            }



            string message = "Do you want to delete this entry?";
            string caption = "CoolBlue";

            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult defaultResult = MessageBoxResult.No;
            MessageBoxOptions options = MessageBoxOptions.None;
            // Show message box
            // MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

            // Displays the MessageBox.
            MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

            if (result == MessageBoxResult.No)
            {

                // Closes the parent form.

                //this.Close();
                return;
            }


            else
            {
                //coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));

                //int TransactID1 = 0;
                ////System.Windows.Data.CollectionViewSource uSP_getLineUSP_getSplitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getLineUSP_getSplitViewSource")));
                //System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));



                //DataRowView drv = (DataRowView)uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.CurrentItem;
                //int accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
                //int accountingPeriod = 1000;  // this will be changed so value comes from settings

                ////int lineCurrent = 0;
                //int wasnull = 0;
                //wasnull = (uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View == null ? 1 : 0);
                //if (wasnull == 1)
                //{

                //    // MessageBox.Show("Warning: uSP_getLineViewSource is null", "CoolBlue");
                //    string message1 = "Warning: uSP_getAllAccountTypesUSP_getAllAccountsViewSource is null";
                //    string caption1 = "CoolBlue";

                //    MessageBoxButton buttons1 = MessageBoxButton.OK;
                //    MessageBoxImage icon1 = MessageBoxImage.Information;
                //    MessageBoxResult defaultResult1 = MessageBoxResult.OK;
                //    MessageBoxOptions options1 = MessageBoxOptions.RtlReading;
                //    // Show message box
                //    // MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

                //    // Displays the MessageBox.
                //    MessageBoxResult result1 = MessageBox.Show(message1, caption1, buttons1, icon1, defaultResult1, options1);

                //    if (result1 == MessageBoxResult.OK)
                //    {

                //        // Closes the parent form.

                //        //this.Close();

                //    }
                //    return;
                //}
                //else
                //{
                //    //DataRowView drv1 = (DataRowView)uSP_getLineViewSource1.View.CurrentItem;
                //    //lineCurrent = (drv1 == null ? 0 : DBNull.Value.Equals(drv1["ID"]) == true ? 0 : (int)drv1["ID"]);
                //}





                SqlConnection conn = new SqlConnection() { ConnectionString = ProgramSettings.coolblueconnectionString };
                try
                {

                    using (SqlCommand cmd3 = new SqlCommand() { Connection = conn, CommandType = CommandType.StoredProcedure })
                    {
                        //cmd3.Transaction = trans1;
                        cmd3.Parameters.Clear();
                        cmd3.CommandText = "dbo.USP_deleteOneSplit";
                        cmd3.Parameters.AddWithValue("@nSplitID", nSplitID);

                        //SqlParameter retval = cmd3.Parameters.Add("@transactIdentity", SqlDbType.Int);
                        //retval.Direction = ParameterDirection.Output;
                        conn.Open();
                        cmd3.ExecuteNonQuery();
                        //TransactID1 = (int)cmd3.Parameters["@transactIdentity"].Value;
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



                    //uSP_getLineDataGrid.

                    //uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.MoveCurrentToPosition(0);

                    //resetButtons();
                    //LocateNewLine(TransactID1);
                }

                coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));
                System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));
                //System.Windows.Data.CollectionViewSource uSP_getLineUSP_getSplitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getLineUSP_getSplitViewSource")));



                DataRowView drv2 = (DataRowView)uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.CurrentItem;
                int accountCurrent = (drv2 == null ? 0 : DBNull.Value.Equals(drv2["ID"]) == true ? 0 : (int)drv2["ID"]);
                int accountingPeriod = Settings.Default.nAccountingPeriodID;  // this will be changed so value comes from settings
                int company = Settings.Default.nCompanyID;  // this will be changed so value comes from settings

                registerDataSet.EnforceConstraints = false;
                registerDataSetUSP_getSplitTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
                registerDataSetUSP_getSplitTableAdapter.Fill(registerDataSet.USP_getSplit, accountCurrent, accountingPeriod, company);
                registerDataSetUSP_getLineTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
                registerDataSetUSP_getLineTableAdapter.Fill(registerDataSet.USP_getLine, accountCurrent, accountingPeriod, company);
                //registerDataSet.EnforceConstraints = true;

                getTotals();
                DataTable dt = registerDataSet.USP_getLine;
                DataRow foundRow = dt.Rows.Find(lineCurrent);


                int rowHandle = dt.Rows.IndexOf(foundRow);


                uSP_getLineDataGrid.View.FocusedRowHandle = rowHandle;
            }

        }

        private void grid_CustomUnboundColumnData(object sender, GridColumnDataEventArgs e)
        {

            if (sender is null)
            {
                return;
            }

            if (e.Column.FieldName == "nNetChange" && e.IsGetData)
            {
                GridControl grid = (GridControl)sender;

                int rowHandle = grid.GetRowHandleByListIndex(e.ListSourceRowIndex);




                //var sourceValue_nAccountingTypeID = e.GetListSourceFieldValue("nAccountingTypeID");
                var sourceValue_nAccountingTypeID = grid.GetCellValue(rowHandle, "nAccountingTypeID");
                //var sourceValue_isAll = grid.GetCellValue(rowHandle, "bIsAll");

                //var sourceValue_totalCrNative = e.GetListSourceFieldValue("totalCrNative");
                var sourceValue_totalCrNative = grid.GetCellValue(rowHandle, "totalCrNative");

                //var sourceValue_totalDrNative = e.GetListSourceFieldValue("totalDrNative");
                var sourceValue_totalDrNative = grid.GetCellValue(rowHandle, "totalDrNative");


                //bool bIsAll = sourceValue_isAll == null ? false : DBNull.Value.Equals(sourceValue_isAll) == true ? false : (bool)sourceValue_isAll;
                //if (bIsAll == true)
                //{
                //    return;
                //}



                int nAccountingTypeID = 0;
                //decimal prevTotalValue = 0m;

                int rowVisibleIndex = grid.GetRowVisibleIndexByHandle(rowHandle);

                //if (rowVisibleIndex == 0)
                //{
                //    nLastRunningTotal = 0m; //reset
                //}

                //int previousRowHandle = grid.GetRowHandleByVisibleIndex(rowVisibleIndex > 0 ? rowVisibleIndex - 1 : GridControl.InvalidRowHandle);

                //int previousRowHandle = grid.GetRowHandleByVisibleIndex(rowVisibleIndex > 0 ? rowVisibleIndex - 1 : -1);

                //prevTotalValue = previousRowHandle != GridControl.InvalidRowHandle ? (decimal)grid.GetCellValue(previousRowHandle, "Running Totals") : 0;

                //if (doCustomColumn)

                //{
                //    doCustomColumn = false;

                //    if (previousRowHandle != GridControl.InvalidRowHandle)
                //    //if (previousRowHandle > -1)
                //    {

                //        //prevTotalValue = (decimal)grid.GetCellValue(previousRowHandle, "Running Totals");//causes overflow error with many records, it's recursive (recalculates last running total) causes grid_CustomUnboundColumnData to trigger just when trying to getcellvalue
                //        //prevTotalValue = nLastRunningTotal;
                //        //if (runningBalance.ContainsKey(previousRowHandle))
                //        //{
                //        //    prevTotalValue = runningBalance[previousRowHandle];
                //        //}
                        


                //    }


                //}









                // prevTotalValue = (decimal)grid.GetCellValue(previousRowHandle, "Running Totals");

                decimal currentPrice = 0m;



                // decimal nTotalCrnative = grid.GetCellValue(rowHandle, "totalCrNative") == null ? 0m : DBNull.Value.Equals(grid.GetCellValue(rowHandle, "totalCrNative")) == true ? 0 : (decimal)grid.GetCellValue(rowHandle, "totalCrNative");
                // decimal nTotalCrnative = grid.GetCellValue(rowHandle, "totalCrNative") == null ? 0m :  (decimal)grid.GetCellValue(rowHandle, "totalCrNative");
                decimal nTotalCrnative = sourceValue_totalCrNative is null ? 0m : (decimal)sourceValue_totalCrNative;



                //decimal nTotalDrnative = grid.GetCellValue(rowHandle, "totalDrNative") == null ? 0m : DBNull.Value.Equals(grid.GetCellValue(rowHandle, "totalDrNative")) == true ? 0 : (decimal)grid.GetCellValue(rowHandle, "totalDrNative");
                // decimal nTotalDrnative = grid.GetCellValue(rowHandle, "totalDrNative") == null ? 0m :  (decimal)grid.GetCellValue(rowHandle, "totalDrNative");
                decimal nTotalDrnative = sourceValue_totalDrNative is null ? 0m : (decimal)sourceValue_totalDrNative;


                // int nAccountingTypeID = grid.GetCellValue(rowHandle, "nAccountingTypeID") == null ? 0 : DBNull.Value.Equals(grid.GetCellValue(rowHandle, "nAccountingTypeID")) == true ? 0 : (int)grid.GetCellValue(rowHandle, "nAccountingTypeID");
                //int nAccountingTypeID = grid.GetCellValue(rowHandle, "nAccountingTypeID") == null ? 0  : (int)grid.GetCellValue(rowHandle, "nAccountingTypeID");

                //var theType = sourceValue_nAccountingTypeID.GetType();

                //if (theType == typeof(Int32)) 
                //{

                if (sourceValue_nAccountingTypeID != null & DBNull.Value.Equals(sourceValue_nAccountingTypeID) == false)

                {

                    nAccountingTypeID = (int)sourceValue_nAccountingTypeID;

                }



                switch (nAccountingTypeID)
                {
                    case 1001://credit card


                        currentPrice = nTotalCrnative - nTotalDrnative;



                        break;

                    case 1003: //expense

                        currentPrice = nTotalDrnative - nTotalCrnative;

                        break;

                    case 1000: //chequing

                        currentPrice = nTotalDrnative - nTotalCrnative;

                        break;

                    case 1002: //income

                        currentPrice = nTotalCrnative - nTotalDrnative;

                        break;

                    default:

                        currentPrice = nTotalCrnative - nTotalDrnative;

                        break;
                }
                e.Value =  currentPrice;
                //runningBalance.Add(rowHandle, (decimal)e.Value);
               // doCustomColumn = true;

                //e.Value = currentPrice + nLastRunningTotal;
                //nLastRunningTotal = (decimal) e.Value;
                //nLastRunningTotal = nLastRunningTotal + currentPrice;


                //e.value = rh7 + saved rh 6

            }

        }

        private void NewSplit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesViewSource")));

            coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));


            int accountCurrent = 0;
            int accountingPeriod = 0;
            int company = 0;
            int accountingTypeCurrent = 0;
            int nCurrencyID = 0;


            DataRowView drv = (DataRowView)uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.CurrentItem;
            accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
            nCurrencyID = (drv == null ? 0 : DBNull.Value.Equals(drv["nCurrencyID"]) == true ? 0 : (int)drv["nCurrencyID"]);
            accountingPeriod = 1001;  // this will be changed so value comes from settings
            company = 1000;  // this will be changed so value comes from settings


            DataRowView drv1 = (DataRowView)uSP_getAllAccountTypesViewSource.View.CurrentItem;
            accountingTypeCurrent = (drv1 == null ? 0 : DBNull.Value.Equals(drv1["nAccountingTypeID"]) == true ? 0 : (int)drv1["nAccountingTypeID"]);






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

            System.Windows.Data.CollectionViewSource uSP_getLineViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getLineViewSource1")));
            DataRowView drv10 = (DataRowView)uSP_getLineViewSource1.View.CurrentItem;
            int lineCurrent = (drv10 == null ? 0 : DBNull.Value.Equals(drv10["ID"]) == true ? 0 : (int)drv10["ID"]);
            if (lineCurrent == 0)
            {
                string message5 = "Please select a transaction";
                string caption5 = "CoolBlue";

                MessageBoxButton buttons5 = MessageBoxButton.OK;
                MessageBoxImage icon5 = MessageBoxImage.Warning;
                MessageBoxResult defaultResult5 = MessageBoxResult.OK;
                MessageBoxOptions options5 = MessageBoxOptions.None;
                // Show message box
                // MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

                // Displays the MessageBox.
                MessageBoxResult result5 = MessageBox.Show(message5, caption5, buttons5, icon5, defaultResult5, options5);
                return;
            }



            //registerDataSet.EnforceConstraints = false;
            //registerDataSetUSP_getSplitTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            //registerDataSetUSP_getSplitTableAdapter.Fill(registerDataSet.USP_getSplit, accountCurrent, accountingPeriod);
            //registerDataSetUSP_getLineTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            //registerDataSetUSP_getLineTableAdapter.Fill(registerDataSet.USP_getLine, accountCurrent, accountingPeriod);

            //DataTable dt = registerDataSet.USP_getLine;
            //DataRow foundRow = dt.Rows.Find(TransactID1);
            //int rowHandle = dt.Rows.IndexOf(foundRow);
            //uSP_getLineDataGrid.View.FocusedRowHandle = rowHandle;

            SplitsView.AddNewRow();
            int newRowHandle = DataControlBase.NewItemRowHandle;

            switch (accountingTypeCurrent)
            {

                case 1000:

                    uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nAccountID_C", accountCurrent);
                    //uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nEntryCurrencyID", nCurrencyID);

                    break;

                case 1001:

                    uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nAccountID_C", accountCurrent);
                    //uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nEntryCurrencyID", nCurrencyID);

                    break;

                case 1003:

                    uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nAccountID_D", accountCurrent);
                    //uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nEntryCurrencyID", nCurrencyID);

                    break;

            }
            //these are done in SplitsView_InitNewRow:
            //uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nAmount_C", 0);
            //uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nAmount_D", 0);
            //uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nAmount_C_Native", 0);
            //uSP_getSplitDataGrid.SetCellValue(newRowHandle, "nAmount_D_Native", 0);


            SplitsView.Focus();
            Vendor.Focus();
            //System.Windows.Forms.SendKeys.SendWait("{ENTER}");

            //SplitsView.FocusedRowHandle = 0;
            Dispatcher.BeginInvoke(new Action(() =>
            {
                //SplitsView.ShowInlineEditForm();
                SplitsView.ShowEditForm();
            }), DispatcherPriority.Render);
            //Dispatcher.BeginInvoke((Action)SplitsView.ShowEditor, DispatcherPriority.Render);


            //LineView.Focus();
        }

        private void grdAccounts_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            uSP_getLineDataGrid.View.MoveLastRow();
        }

        private void ThemedWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void barBtnDatabase_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            DBConnection dbconnection = new DBConnection();

            dbconnection.ShowDialog();

            string server = Settings.Default.server;
            string database = "coolblue";
            string database1 = "works";
            string username = Settings.Default.username;
            string password = Settings.Default.password;


            openingroutine();
            fillLinesAndSplits();

            this.Title = "coolblue       " + server + ": " + username;
        }



        private void btnInfoNewVendor_Click(object sender, RoutedEventArgs e)
        {
            int TransactID1 = 0;
            System.Windows.Data.CollectionViewSource uSP_getLineUSP_getSplitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getLineUSP_getSplitViewSource")));

            System.Windows.Data.CollectionViewSource uSP_getAllVendorsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllVendorsViewSource")));


            //DataRowView drv = (DataRowView)uSP_getAllVendorsViewSource.View.CurrentItem;

            //Console.Write(drv[0] + "\table");

            //string tt= drv[0] + "\table";

            //int curRowHandle = Index(drv);
            ////int curRowHandle = uSP_getAllVendorsViewSource.View.CurrentItem;


            int wasnull = 0;

            if (wasnull == 1)
            {

                string message = "Warning: uSP_getAllAccountTypesUSP_getAllAccountsViewSource is null";
                string caption = "CoolBlue";

                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult defaultResult = MessageBoxResult.OK;
                MessageBoxOptions options = MessageBoxOptions.RtlReading;

                MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

                if (result == MessageBoxResult.OK)
                {

                    // Closes the parent form.

                    //this.Close();

                }
                return;
            }
            else
            {

            }


            SqlConnection conn = new SqlConnection() { ConnectionString = ProgramSettings.coolblueconnectionString };
            try
            {

                using (SqlCommand cmd3 = new SqlCommand() { Connection = conn, CommandType = CommandType.StoredProcedure })
                {
                    //cmd3.Transaction = trans1;
                    cmd3.Parameters.Clear();
                    cmd3.CommandText = "dbo.USP_insertVendor";
                    //cmd3.Parameters.AddWithValue("@nAccount", accountCurrent);

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



                int vendorCurrent = TransactID1;
                editVendor editVendor1 = new editVendor(vendorCurrent);
                editVendor1.ShowDialog();
                coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));

                coolBlue.RegisterDataSetTableAdapters.USP_getAllVendorsTableAdapter registerDataSetUSP_getAllVendorsTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getAllVendorsTableAdapter();
                // System.Windows.Data.CollectionViewSource uSP_getAllVendorsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllVendorsViewSource")));
                registerDataSetUSP_getAllVendorsTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
                registerDataSetUSP_getAllVendorsTableAdapter.Fill(registerDataSet.USP_getAllVendors);


                //string message5 = "New vendor will be added to this entry after closing edit form by clicking UPDATE.";
                // string caption5 = "CoolBlue";


                //var editForm = LayoutTreeHelper.GetVisualParents(this.AssociatedObject).OfType<EditFormControl>().FirstOrDefault();

                // var obj = LayoutTreeHelper.GetVisualChildren(uSP_getSplitDataGrid).OfType<Button>().FirstOrDefault(x => x.Name == "btnInfoNewVendor");

                var editForm = LayoutTreeHelper.GetVisualChildren(SplitsView).OfType<EditFormControl>().FirstOrDefault();


                var editor = LayoutTreeHelper.GetVisualChildren(editForm).OfType<EditFormEditor>().FirstOrDefault(elem => ((EditFormCellData)elem.DataContext).FieldName == "nVendorsID");


                // var editor = LayoutTreeHelper.GetVisualChildren(uSP_getSplitDataGrid).OfType<TableView>().FirstOrDefault(elem => ((EditForm CellData)elem.DataContext).FieldName == "cMemo");
                if (editor != null)
                {
                    var baseEditor = editor.Content as BaseEdit;
                    if (baseEditor != null)
                    {
                        baseEditor.EditValue = vendorCurrent;
                    }
                }


                //MessageBoxButton buttons5 = MessageBoxButton.OKCancel;
                //MessageBoxImage icon5 = MessageBoxImage.Exclamation;
                //MessageBoxResult defaultResult5 = MessageBoxResult.OK;
                //MessageBoxOptions options5 = MessageBoxOptions.None;

                //MessageBoxResult result5 = MessageBox.Show(message5, caption5, buttons5, icon5, defaultResult5, options5);
                //if (result5 == MessageBoxResult.OK)
                //{
                newVendorAdded = vendorCurrent;
                //}

                // uSP_getSplitDataGrid.SetFocusedRowCellValue("nVendorsID", vendorCurrent);
            }
        }

        private void barEditCompany_EditValueChanged(object sender, RoutedEventArgs e)
        {


            int nCompanyCheck = (barEditCompany.EditValue == null ? 0 : (int)barEditCompany.EditValue);


            bool bWasCompanyChanged = false;
            if (nCompanyCheck != Settings.Default.nCompanyID)
            {
                bWasCompanyChanged = true;
            }
            if (bWasCompanyChanged == true)
            {
                Settings.Default.nCompanyID = nCompanyCheck;

                openingroutine();
                fillLinesAndSplits();
            }
        }


        private void updateRunningTotals()
        {

            for (int i = 0; i < uSP_getLineDataGrid.VisibleRowCount; i++)
            {
                int rowHandle = uSP_getLineDataGrid.GetRowHandleByVisibleIndex(i);
                decimal nNewValue = 0;


                if (rowHandle > 0)
                {

                    nNewValue = (decimal)uSP_getLineDataGrid.GetCellValue(rowHandle - 1, "nRunningTotal") + (decimal)uSP_getLineDataGrid.GetCellValue(rowHandle, "nNetChange");
                }
                if (rowHandle == 0)
                {

                    nNewValue =  (decimal)uSP_getLineDataGrid.GetCellValue(rowHandle, "nNetChange");
                }




                uSP_getLineDataGrid.SetCellValue(rowHandle, "nRunningTotal", nNewValue);
            }


        }

        
    }
}
