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
    /// Interaction logic for editCat.xaml
    /// </summary>
    public partial class editCat : ThemedWindow
    {
        public int nCatID;
        public editCat(int catID)
        {
            InitializeComponent();
            nCatID = catID;
        }

        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {

            coolBlue.CategoriesDataSet categoriesDataSet = ((coolBlue.CategoriesDataSet)(this.FindResource("categoriesDataSet")));
            // TODO: Add code here to load data into the table USP_getOneCat.
            // This code could not be generated, because the categoriesDataSetUSP_getOneCatTableAdapter.Fill method is missing, or has unrecognized parameters.
            coolBlue.CategoriesDataSetTableAdapters.USP_getOneCatTableAdapter categoriesDataSetUSP_getOneCatTableAdapter = new coolBlue.CategoriesDataSetTableAdapters.USP_getOneCatTableAdapter();


            categoriesDataSet.EnforceConstraints = false;

            categoriesDataSetUSP_getOneCatTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;

            categoriesDataSetUSP_getOneCatTableAdapter.Fill(categoriesDataSet.USP_getOneCat, nCatID);

            categoriesDataSet.EnforceConstraints = true;




            System.Windows.Data.CollectionViewSource uSP_getOneCatViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getOneCatViewSource")));
            uSP_getOneCatViewSource.View.MoveCurrentToFirst();
        }

        private void BarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            //int TransactID1 = 0;
            string notes = "";
            
            string name = "";
            System.Windows.Data.CollectionViewSource uSP_getOneCatViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getOneCatViewSource")));

            coolBlue.CategoriesDataSet categoriesDataSet = ((coolBlue.CategoriesDataSet)(this.FindResource("categoriesDataSet")));


            //int accountCurrent = 0;
            int wasnull = 0;
            wasnull = (uSP_getOneCatViewSource.View == null ? 1 : 0);
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


                DataRowView drv = (DataRowView)uSP_getOneCatViewSource.View.CurrentItem;
                //accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
                notes = (DBNull.Value.Equals(drv["cNote"]) == true ? "" : (string)drv["cNote"]);
               
                name = (DBNull.Value.Equals(drv["cName"]) == true ? "" : (string)drv["cName"]);

            }






            SqlConnection conn = new SqlConnection() { ConnectionString = ProgramSettings.coolblueconnectionString };
            try
            {

                using (SqlCommand cmd3 = new SqlCommand() { Connection = conn, CommandType = CommandType.StoredProcedure })
                {
                    //cmd3.Transaction = trans1;
                    cmd3.Parameters.Clear();
                    cmd3.CommandText = "dbo.USP_updateCat";
                    cmd3.Parameters.AddWithValue("@ID", nCatID);
                    cmd3.Parameters.AddWithValue("@notes", notes);
                   
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
