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
    /// Interaction logic for editSubCat.xaml
    /// </summary>
    public partial class editSubCat : ThemedWindow
    {
        public int nSubCatID;
        public editSubCat(int subcatID)
        {
            InitializeComponent();
            nSubCatID = subcatID;
        }

        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {

            coolBlue.CategoriesDataSet categoriesDataSet = ((coolBlue.CategoriesDataSet)(this.FindResource("categoriesDataSet")));
            // TODO: Add code here to load data into the table USP_getOneCat.
            // This code could not be generated, because the categoriesDataSetUSP_getOneCatTableAdapter.Fill method is missing, or has unrecognized parameters.
            coolBlue.CategoriesDataSetTableAdapters.USP_getOneSubCatTableAdapter categoriesDataSetUSP_getOneSubCatTableAdapter = new coolBlue.CategoriesDataSetTableAdapters.USP_getOneSubCatTableAdapter();
            coolBlue.CategoriesDataSetTableAdapters.USP_getAllCatsTableAdapter categoriesDataSetUSP_getAllCatsTableAdapter = new coolBlue.CategoriesDataSetTableAdapters.USP_getAllCatsTableAdapter();


            categoriesDataSet.EnforceConstraints = false;
            categoriesDataSetUSP_getOneSubCatTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;

            categoriesDataSetUSP_getOneSubCatTableAdapter.Fill(categoriesDataSet.USP_getOneSubCat, nSubCatID);
            categoriesDataSetUSP_getAllCatsTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;

            categoriesDataSetUSP_getAllCatsTableAdapter.Fill(categoriesDataSet.USP_getAllCats);
            categoriesDataSet.EnforceConstraints = true;

            



            System.Windows.Data.CollectionViewSource uSP_getOneSubCatViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getOneSubCatViewSource")));
            uSP_getOneSubCatViewSource.View.MoveCurrentToFirst();
            // TODO: Add code here to load data into the table USP_getAllCats.
            // This code could not be generated, because the categoriesDataSetUSP_getAllCatsTableAdapter.Fill method is missing, or has unrecognized parameters.
           // coolBlue.CategoriesDataSetTableAdapters.USP_getAllCatsTableAdapter categoriesDataSetUSP_getAllCatsTableAdapter = new coolBlue.CategoriesDataSetTableAdapters.USP_getAllCatsTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllCatsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllCatsViewSource")));
            uSP_getAllCatsViewSource.View.MoveCurrentToFirst();

            DataRowView drv = (DataRowView)uSP_getOneSubCatViewSource.View.CurrentItem;
            int catID = (drv == null ? 0 : DBNull.Value.Equals(drv["nCatID"]) == true ? 0 : (int)drv["nCatID"]);
            LookupEditCat.EditValue = catID;
        }

        private void BarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            //int TransactID1 = 0;
            string notes = "";
            int nCatID = 0;
            string name = "";
            System.Windows.Data.CollectionViewSource uSP_getOneSubCatViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getOneSubCatViewSource")));

            coolBlue.CategoriesDataSet categoriesDataSet = ((coolBlue.CategoriesDataSet)(this.FindResource("categoriesDataSet")));


            //int accountCurrent = 0;
            int wasnull = 0;
            wasnull = (uSP_getOneSubCatViewSource.View == null ? 1 : 0);
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


                DataRowView drv = (DataRowView)uSP_getOneSubCatViewSource.View.CurrentItem;
                //accountCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
                notes = (DBNull.Value.Equals(drv["cNotes"]) == true ? "" : (string)drv["cNotes"]);

                name = (DBNull.Value.Equals(drv["cName"]) == true ? "" : (string)drv["cName"]);

                nCatID = (int) LookupEditCat.EditValue;

            }






            SqlConnection conn = new SqlConnection() { ConnectionString = ProgramSettings.coolblueconnectionString };
            try
            {

                using (SqlCommand cmd3 = new SqlCommand() { Connection = conn, CommandType = CommandType.StoredProcedure })
                {
                    //cmd3.Transaction = trans1;
                    cmd3.Parameters.Clear();
                    cmd3.CommandText = "dbo.USP_updateSubCat";
                    cmd3.Parameters.AddWithValue("@ID", nSubCatID);
                    cmd3.Parameters.AddWithValue("@notes", notes);
                    cmd3.Parameters.AddWithValue("@nCatID", nCatID);
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
