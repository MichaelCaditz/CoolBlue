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


namespace coolBlue
{
    /// <summary>
    /// Interaction logic for editAccount.xaml
    /// </summary>
    public partial class editAccount : ThemedWindow
    {
        public int nAccountID;
        public bool bNameChanged = false;
        public string cOrigName;
        public editAccount(int AccountID)
        {
            InitializeComponent();
            nAccountID = AccountID;
        }

        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {

            coolBlue.AccountsDataSet accountsDataSet = ((coolBlue.AccountsDataSet)(this.FindResource("accountsDataSet")));
            coolBlue.CategoriesDataSet categoriesDataSet = ((coolBlue.CategoriesDataSet)(this.FindResource("categoriesDataSet")));
            coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));

            coolBlue.AccountsDataSetTableAdapters.USP_getOneAccountTableAdapter accountsDataSetUSP_getOneAccountTableAdapter = new coolBlue.AccountsDataSetTableAdapters.USP_getOneAccountTableAdapter();
            coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountTypesTableAdapter accountsDataSetUSP_getAllAccountTypesTableAdapter = new coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountTypesTableAdapter();
            coolBlue.CategoriesDataSetTableAdapters.USP_getAllCatsTableAdapter categoriesDataSetUSP_getAllCatsTableAdapter = new coolBlue.CategoriesDataSetTableAdapters.USP_getAllCatsTableAdapter();
            coolBlue.RegisterDataSetTableAdapters.USP_getAllCurrencyTableAdapter registerDataSetUSP_getAllCurrencyTableAdapter = new coolBlue.RegisterDataSetTableAdapters.USP_getAllCurrencyTableAdapter();

            accountsDataSet.EnforceConstraints = false;
            accountsDataSetUSP_getOneAccountTableAdapter.Fill(accountsDataSet.USP_getOneAccount, nAccountID);
            accountsDataSetUSP_getAllAccountTypesTableAdapter.Fill(accountsDataSet.USP_getAllAccountTypes);
            accountsDataSet.EnforceConstraints = true;


            categoriesDataSet.EnforceConstraints = false;
            categoriesDataSetUSP_getAllCatsTableAdapter.Fill(categoriesDataSet.USP_getAllCats);
            categoriesDataSet.EnforceConstraints = true;

            registerDataSet.EnforceConstraints = false;
            registerDataSetUSP_getAllCurrencyTableAdapter.Fill(registerDataSet.USP_getAllCurrency);
            registerDataSet.EnforceConstraints = true;


            System.Windows.Data.CollectionViewSource uSP_getOneAccountViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getOneAccountViewSource")));
            uSP_getOneAccountViewSource.View.MoveCurrentToFirst();
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesViewSource")));
            uSP_getAllAccountTypesViewSource.View.MoveCurrentToFirst();
            System.Windows.Data.CollectionViewSource uSP_getAllCatsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllCatsViewSource")));
            uSP_getAllCatsViewSource.View.MoveCurrentToFirst();
            System.Windows.Data.CollectionViewSource uSP_getAllCurrencyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllCurrencyViewSource")));
            uSP_getAllCurrencyViewSource.View.MoveCurrentToFirst();

            DataRowView drv = (DataRowView)uSP_getOneAccountViewSource.View.CurrentItem;
            int catID = (drv == null ? 0 : DBNull.Value.Equals(drv["nCatID"]) == true ? 0 : (int)drv["nCatID"]);
            LookupEditCat.EditValue = catID;
           
            int currencyID = (drv == null ? 0 : DBNull.Value.Equals(drv["nCurrencyID"]) == true ? 0 : (int)drv["nCurrencyID"]);
            LookupEditCurrency.EditValue = currencyID;


            int accountTypeID = (drv == null ? 0 : DBNull.Value.Equals(drv["nAccountTypeID"]) == true ? 0 : (int)drv["nAccountTypeID"]);
            LookupEditAccountType.EditValue = accountTypeID;

            cOrigName = (drv == null ? "" : DBNull.Value.Equals(drv["cName"]) == true ? "" : (string)drv["cName"]);
        }

        private void BarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            //int TransactID1 = 0;
            string cNote = "";
            string cName = "";
            string cDesc = "";
            string cComment = "";
            string cDecryptedPIN = "";
            string cDecryptedCV = "";
            string cExpiry = "";
            string cAcctNum = "";
            int nCatID = 0;
            int nAccountTypeID = 0;
            int nCurrencyID = 0;
            decimal nCreditLimit = 0m;
            string cUsername = "";
            string cCardNum = "";
            string cPassword = "";
            string cInstitutionNum = "";
            string cTransitNum = "";

            string cSwiftCode = "";

            string cContactName = "";
            string cURL = "";
            string cContactEmail = "";
            string cContactPhone = "";

            System.Windows.Data.CollectionViewSource uSP_getOneAccountViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getOneAccountViewSource")));

            coolBlue.AccountsDataSet accountsDataSet = ((coolBlue.AccountsDataSet)(this.FindResource("accountsDataSet")));

            //int accountCurrent = 0;
            int wasnull = 0;
            wasnull = (uSP_getOneAccountViewSource.View == null ? 1 : 0);
            if (wasnull == 1)
            {

                // MessageBox.Show("Warning: uSP_getLineViewSource is null", "CoolBlue");
                string message = "Warning:uSP_getOneAccountViewSource is null";
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


                DataRowView drv = (DataRowView)uSP_getOneAccountViewSource.View.CurrentItem;
                //accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
                cNote = (DBNull.Value.Equals(drv["cNote"]) == true ? "" : (string)drv["cNote"]);
                cName = (DBNull.Value.Equals(drv["cName"]) == true ? "" : (string)drv["cName"]);
                cDesc = (DBNull.Value.Equals(drv["cDesc"]) == true ? "" : (string)drv["cDesc"]);
                cComment = (DBNull.Value.Equals(drv["cComment"]) == true ? "" : (string)drv["cComment"]);
                cDecryptedPIN = (DBNull.Value.Equals(drv["cDecryptedPIN"]) == true ? "" : (string)drv["cDecryptedPIN"]);
                cDecryptedCV = (DBNull.Value.Equals(drv["cDecryptedCV"]) == true ? "" : (string)drv["cDecryptedCV"]);
                cExpiry = (DBNull.Value.Equals(drv["cDecryptedExpiry"]) == true ? "" : (string)drv["cDecryptedExpiry"]);
                cAcctNum = (DBNull.Value.Equals(drv["cDecryptedAcctNum"]) == true ? "" : (string)drv["cDecryptedAcctNum"]);
                nCreditLimit = (DBNull.Value.Equals(drv["nCreditLimit"]) == true ? 0m : (decimal)drv["nCreditLimit"]);
                cUsername = (DBNull.Value.Equals(drv["cDecryptedUsername"]) == true ? "" : (string)drv["cDecryptedUsername"]);
                cCardNum = (DBNull.Value.Equals(drv["cDecryptedCardNum"]) == true ? "" : (string)drv["cDecryptedCardNum"]);
                cPassword = (DBNull.Value.Equals(drv["cDecryptedPassword"]) == true ? "" : (string)drv["cDecryptedPassword"]);
                cDecryptedCV = (DBNull.Value.Equals(drv["cDecryptedCV"]) == true ? "" : (string)drv["cDecryptedCV"]);

                cInstitutionNum = (DBNull.Value.Equals(drv["cInstitutionNum"]) == true ? "" : (string)drv["cInstitutionNum"]);

                cTransitNum = (DBNull.Value.Equals(drv["cTransitNum"]) == true ? "" : (string)drv["cTransitNum"]);

                cSwiftCode = (DBNull.Value.Equals(drv["cSwiftCode"]) == true ? "" : (string)drv["cSwiftCode"]);

                cContactName = (DBNull.Value.Equals(drv["cContactName"]) == true ? "" : (string)drv["cContactName"]);

                cURL = (DBNull.Value.Equals(drv["cURL"]) == true ? "" : (string)drv["cURL"]);

                cContactEmail = (DBNull.Value.Equals(drv["cContactEmail"]) == true ? "" : (string)drv["cContactEmail"]);

                cContactPhone = (DBNull.Value.Equals(drv["cContactPhone"]) == true ? "" : (string)drv["cContactPhone"]);


               



                // nAccountTypeID = (int)LookupEditAccountType.EditValue;
                //nAccountTypeID = (DBNull.Value.Equals(LookupEditAccountType.EditValue) == true ? 0 : (int)LookupEditAccountType.EditValue);
                //nCatID = (int)LookupEditCat.EditValue;
                //nCatID = (DBNull.Value.Equals(LookupEditCat.EditValue) == true ? 0 : (int)LookupEditCat.EditValue);
                //nCurrencyID = (int)LookupEditCurrency.EditValue;
                //nCurrencyID = (DBNull.Value.Equals(LookupEditCurrency.EditValue) == true ? 0 : (int)LookupEditCurrency.EditValue);

                nAccountTypeID = (LookupEditAccountType.EditValue == null ? 0 : DBNull.Value.Equals(LookupEditAccountType.EditValue) == true ? 0 : (int)LookupEditAccountType.EditValue);
                nCatID = (LookupEditCat.EditValue == null ? 0 : DBNull.Value.Equals(LookupEditCat.EditValue) == true ? 0 : (int)LookupEditCat.EditValue);

                nCurrencyID = (LookupEditCurrency.EditValue == null ? 0 : DBNull.Value.Equals(LookupEditCurrency.EditValue) == true ? 0 : (int)LookupEditCurrency.EditValue);


            }






            SqlConnection conn = new SqlConnection() { ConnectionString = ProgramSettings.coolblueconnectionString };
            try
            {

                using (SqlCommand cmd3 = new SqlCommand() { Connection = conn, CommandType = CommandType.StoredProcedure })
                {
                    //cmd3.Transaction = trans1;
                    cmd3.Parameters.Clear();
                    cmd3.CommandText = "dbo.USP_updateAccount";
                    cmd3.Parameters.AddWithValue("@ID", nAccountID);
                    cmd3.Parameters.AddWithValue("@cNote", cNote);
                    cmd3.Parameters.AddWithValue("@cName", cName);
                    cmd3.Parameters.AddWithValue("@cDesc", cDesc);
                    cmd3.Parameters.AddWithValue("@cComment", cComment);
                    cmd3.Parameters.AddWithValue("@cDecryptedPIN", cDecryptedPIN);
                    cmd3.Parameters.AddWithValue("@cDecryptedCV", cDecryptedCV);
                    cmd3.Parameters.AddWithValue("@nAccountTypeID", nAccountTypeID);
                    cmd3.Parameters.AddWithValue("@nCatID", nCatID);
                    cmd3.Parameters.AddWithValue("@nCurrencyID", nCurrencyID);
                    cmd3.Parameters.AddWithValue("@cExpiry", cExpiry);
                    cmd3.Parameters.AddWithValue("@cAcctNum", cAcctNum);
                    cmd3.Parameters.AddWithValue("@cCardNum", cCardNum);
                    cmd3.Parameters.AddWithValue("@cInstitutionNum", cInstitutionNum);
                    cmd3.Parameters.AddWithValue("@cTransitNum", cTransitNum);
                    cmd3.Parameters.AddWithValue("@cUsername", cUsername);
                    cmd3.Parameters.AddWithValue("@cPassword", cPassword);
                    cmd3.Parameters.AddWithValue("@cSwiftCode", cSwiftCode);
                    cmd3.Parameters.AddWithValue("@nCreditLimit", nCreditLimit);
                    cmd3.Parameters.AddWithValue("@cContactName", cContactName);
                    cmd3.Parameters.AddWithValue("@cURL", cURL);
                    cmd3.Parameters.AddWithValue("@cContactEmail", cContactEmail);
                    cmd3.Parameters.AddWithValue("@cContactPhone", cContactPhone);


                    


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
                if (cOrigName == cName)
                {
                    this.bNameChanged = false;
                }
                else
                { this.bNameChanged = true;
                }
                //VendorDataSet.EnforceConstraints = false;

                //coolBlue.vendorDataSetTableAdapters.USP_getOneVendorTableAdapter vendorDataSetUSP_getOneVendorTableAdapter = new coolBlue.vendorDataSetTableAdapters.USP_getOneVendorTableAdapter();


                //vendorDataSetUSP_getOneVendorTableAdapter.Fill(VendorDataSet.USP_getOneVendor, nVendorID);

                //VendorDataSet.EnforceConstraints = true;

                //uSP_getLineDataGrid.

                //uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.MoveCurrentToPosition(0);

                //resetButtons();
                // LocateNewLine(TransactID1);
                this.Close();

            }
        }
    }
}
