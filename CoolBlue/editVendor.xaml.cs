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
    /// Interaction logic for editVendor.xaml
    /// </summary>
    public partial class editVendor : ThemedWindow
    {
        public int nVendorID;
        public editVendor(int VendorID)
        {
            InitializeComponent();
            nVendorID = VendorID;
        }

        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {

            coolBlue.vendorDataSet VendorDataSet = ((coolBlue.vendorDataSet)(this.FindResource("vendorDataSet")));
            coolBlue.vendorDataSetTableAdapters.USP_getOneVendorTableAdapter vendorDataSetUSP_getOneVendorTableAdapter = new coolBlue.vendorDataSetTableAdapters.USP_getOneVendorTableAdapter();





            //DataRowView drv = (DataRowView)uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.CurrentItem;
            // int vendorCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);

            VendorDataSet.EnforceConstraints = false;
            vendorDataSetUSP_getOneVendorTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;

            vendorDataSetUSP_getOneVendorTableAdapter.Fill(VendorDataSet.USP_getOneVendor, nVendorID);

            VendorDataSet.EnforceConstraints = true;



            


            System.Windows.Data.CollectionViewSource uSP_getOneVendorViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getOneVendorViewSource")));
            uSP_getOneVendorViewSource.View.MoveCurrentToFirst();
        }

        private void BarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            //int TransactID1 = 0;
            string notes = "";
            string account_no = "";
            string address1 = "";
            string address2 = "";
            string city = "";
            string state = "";
            string state_other = "";
            string zip = "";
            string country = "";
            string postal_code = "";
            string areacode = "";
            string phone = "";
            string email = "";
            string website = "";
            string rep = "";
            string name = "";
            System.Windows.Data.CollectionViewSource uSP_getOneVendorViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getOneVendorViewSource")));

            coolBlue.vendorDataSet VendorDataSet = ((coolBlue.vendorDataSet)(this.FindResource("vendorDataSet")));


            //int accountCurrent = 0;
            int wasnull = 0;
            wasnull = (uSP_getOneVendorViewSource.View == null ? 1 : 0);
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

                
                   DataRowView drv = (DataRowView)uSP_getOneVendorViewSource.View.CurrentItem;
                //accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
                 notes = (DBNull.Value.Equals(drv["notes"]) == true ? "" : (string)drv["notes"]);
                 account_no = (DBNull.Value.Equals(drv["account_no"]) == true ? "" : (string)drv["account_no"]);
                 address1 = (DBNull.Value.Equals(drv["address1"]) == true ? "" : (string)drv["address1"]);
                 address2 = (DBNull.Value.Equals(drv["address2"]) == true ? "" : (string)drv["address2"]);
                 city = (DBNull.Value.Equals(drv["city"]) == true ? "" : (string)drv["city"]);
                 state = (DBNull.Value.Equals(drv["state"]) == true ? "" : (string)drv["state"]);
                 state_other = (DBNull.Value.Equals(drv["state_other"]) == true ? "" : (string)drv["state_other"]);
                 zip = (DBNull.Value.Equals(drv["zip"]) == true ? "" : (string)drv["zip"]);
                 country = (DBNull.Value.Equals(drv["country"]) == true ? "" : (string)drv["country"]);
                 postal_code = (DBNull.Value.Equals(drv["postal_code"]) == true ? "" : (string)drv["postal_code"]);
                 areacode = (DBNull.Value.Equals(drv["areacode"]) == true ? "" : (string)drv["areacode"]);
                 phone = (DBNull.Value.Equals(drv["phone"]) == true ? "" : (string)drv["phone"]);
                 email = (DBNull.Value.Equals(drv["email"]) == true ? "" : (string)drv["email"]);
                 website = (DBNull.Value.Equals(drv["website"]) == true ? "" : (string)drv["website"]);
                 rep = (DBNull.Value.Equals(drv["rep"]) == true ? "" : (string)drv["rep"]);
                name = (DBNull.Value.Equals(drv["name"]) == true ? "" : (string)drv["name"]);

            }






            SqlConnection conn = new SqlConnection() { ConnectionString = ProgramSettings.coolblueconnectionString };
            try
            {

                using (SqlCommand cmd3 = new SqlCommand() { Connection = conn, CommandType = CommandType.StoredProcedure })
                {
                    //cmd3.Transaction = trans1;
                    cmd3.Parameters.Clear();
                    cmd3.CommandText = "dbo.USP_updateVendor";
                    cmd3.Parameters.AddWithValue("@ID", nVendorID);
                    cmd3.Parameters.AddWithValue("@notes", notes);
                    cmd3.Parameters.AddWithValue("@account_no", account_no);
                    cmd3.Parameters.AddWithValue("@address1", address1);
                    cmd3.Parameters.AddWithValue("@address2", address2);
                    cmd3.Parameters.AddWithValue("@city", city);
                    cmd3.Parameters.AddWithValue("@state", state);
                    cmd3.Parameters.AddWithValue("@state_other", state_other);
                    cmd3.Parameters.AddWithValue("@zip", zip);
                    cmd3.Parameters.AddWithValue("@country", country);
                    cmd3.Parameters.AddWithValue("@postal_code", postal_code);
                    cmd3.Parameters.AddWithValue("@areacode", areacode);
                    cmd3.Parameters.AddWithValue("@phone", phone);
                    cmd3.Parameters.AddWithValue("@email", email);
                    cmd3.Parameters.AddWithValue("@website", website);
                    cmd3.Parameters.AddWithValue("@rep", rep);
                    cmd3.Parameters.AddWithValue("@name", name);


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
                this.Close();
                
            }
        }
    }
}
