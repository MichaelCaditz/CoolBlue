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
    /// Interaction logic for categories.xaml
    /// </summary>
    public partial class categories : ThemedWindow
    {
        public categories()
        {
            InitializeComponent();
        }

        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {

            coolBlue.CategoriesDataSet categoriesDataSet = ((coolBlue.CategoriesDataSet)(this.FindResource("categoriesDataSet")));
            coolBlue.CategoriesDataSetTableAdapters.USP_getAllCatsTableAdapter categoriesDataSetUSP_getAllCatsTableAdapter = new coolBlue.CategoriesDataSetTableAdapters.USP_getAllCatsTableAdapter();
            coolBlue.CategoriesDataSetTableAdapters.USP_getAllSubCatsTableAdapter categoriesDataSetUSP_getAllSubCatsTableAdapter = new coolBlue.CategoriesDataSetTableAdapters.USP_getAllSubCatsTableAdapter();

            categoriesDataSetUSP_getAllCatsTableAdapter.Fill(categoriesDataSet.USP_getAllCats);
            categoriesDataSetUSP_getAllSubCatsTableAdapter.Fill(categoriesDataSet.USP_getAllSubCats);
            
            System.Windows.Data.CollectionViewSource uSP_getAllCatsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllCatsViewSource")));
            System.Windows.Data.CollectionViewSource uSP_getAllCatsUSP_getAllSubCatsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllCatsUSP_getAllSubCatsViewSource")));
            

            uSP_getAllCatsViewSource.View.MoveCurrentToFirst();
            uSP_getAllCatsUSP_getAllSubCatsViewSource.View.MoveCurrentToFirst();
        }

        private void BarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            int TransactID1 = 0;
            System.Windows.Data.CollectionViewSource uSP_getAllCatsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllCatsViewSource")));

            //coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));


            // int accountCurrent = 0;
            int wasnull = 0;
            // wasnull = (uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View == null ? 1 : 0);
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
                    cmd3.CommandText = "dbo.USP_insertCat";
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

                //registerDataSet.EnforceConstraints = false;

                //registerDataSetUSP_getSplitTableAdapter.Fill(registerDataSet.USP_getSplit, accountCurrent);
                //registerDataSetUSP_getLineTableAdapter.Fill(registerDataSet.USP_getLine, accountCurrent);
                // registerDataSet.EnforceConstraints = true;

                //uSP_getLineDataGrid.

                //uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.MoveCurrentToPosition(0);

                //resetButtons();
                //LocateNewLine(TransactID1);

                int catCurrent = TransactID1;
                editCat editCat1 = new editCat(catCurrent);
                editCat1.ShowDialog();
            }
        }

        private void BarButtonItem_ItemClick_1(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            goDetails();
        }

        private void goDetails()
        {

            System.Windows.Data.CollectionViewSource uSP_getAllCatsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllCatsViewSource")));

            DataRowView drv = (DataRowView)uSP_getAllCatsViewSource.View.CurrentItem;
            int catCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
            editCat editCat1 = new editCat(catCurrent);
            editCat1.ShowDialog();

            coolBlue.CategoriesDataSet categoriesDataSet = ((coolBlue.CategoriesDataSet)(this.FindResource("categoriesDataSet")));
            coolBlue.CategoriesDataSetTableAdapters.USP_getAllCatsTableAdapter categoriesDataSetUSP_getAllCatsTableAdapter = new coolBlue.CategoriesDataSetTableAdapters.USP_getAllCatsTableAdapter();


            categoriesDataSet.EnforceConstraints = false;
            categoriesDataSetUSP_getAllCatsTableAdapter.Fill(categoriesDataSet.USP_getAllCats);
            categoriesDataSet.EnforceConstraints = true;

            uSP_getAllCatsViewSource.View.MoveCurrentToFirst();

        }

            private void BarButtonItem_ItemClick_2(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            System.Windows.Data.CollectionViewSource uSP_getAllCatsUSP_getAllSubCatsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllCatsUSP_getAllSubCatsViewSource")));

            DataRowView drv = (DataRowView)uSP_getAllCatsUSP_getAllSubCatsViewSource.View.CurrentItem;
            int SubcatCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
            editSubCat editSubCat1 = new editSubCat(SubcatCurrent);
            editSubCat1.ShowDialog();

            coolBlue.CategoriesDataSet categoriesDataSet = ((coolBlue.CategoriesDataSet)(this.FindResource("categoriesDataSet")));
            coolBlue.CategoriesDataSetTableAdapters.USP_getAllSubCatsTableAdapter categoriesDataSetUSP_getAllSubCatsTableAdapter = new coolBlue.CategoriesDataSetTableAdapters.USP_getAllSubCatsTableAdapter();
            categoriesDataSet.EnforceConstraints = false;

            categoriesDataSetUSP_getAllSubCatsTableAdapter.Fill(categoriesDataSet.USP_getAllSubCats);
            categoriesDataSet.EnforceConstraints = true;


            uSP_getAllCatsUSP_getAllSubCatsViewSource.View.MoveCurrentToFirst();
        }

        private void BarButtonItem_ItemClick_3(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            int TransactID1 = 0;
            System.Windows.Data.CollectionViewSource uSP_getAllCatsUSP_getAllSubCatsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllCatsUSP_getAllSubCatsViewSource")));

            //coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));
            //coolBlue.CategoriesDataSet categoriesDataSet = ((coolBlue.CategoriesDataSet)(this.FindResource("categoriesDataSet")));
            System.Windows.Data.CollectionViewSource uSP_getAllCatsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllCatsViewSource")));


            int catCurrent = 0;
            int wasnull = 0;
            wasnull = (uSP_getAllCatsViewSource.View == null ? 1 : 0);
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
                DataRowView drv = (DataRowView)uSP_getAllCatsViewSource.View.CurrentItem;
                catCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
            }






            SqlConnection conn = new SqlConnection() { ConnectionString = ProgramSettings.coolblueconnectionString };
            try
            {

                using (SqlCommand cmd3 = new SqlCommand() { Connection = conn, CommandType = CommandType.StoredProcedure })
                {
                    //cmd3.Transaction = trans1;
                    cmd3.Parameters.Clear();
                    cmd3.CommandText = "dbo.USP_insertSubCat";
                    cmd3.Parameters.AddWithValue("@nCat", catCurrent);

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

                int subcatCurrent = TransactID1;
                editSubCat editSubCat1 = new editSubCat(subcatCurrent);
                editSubCat1.ShowDialog();
               // System.Windows.Data.CollectionViewSource uSP_getAllCatsUSP_getAllSubCatsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllCatsUSP_getAllSubCatsViewSource")));

                coolBlue.CategoriesDataSet categoriesDataSet = ((coolBlue.CategoriesDataSet)(this.FindResource("categoriesDataSet")));
                coolBlue.CategoriesDataSetTableAdapters.USP_getAllSubCatsTableAdapter categoriesDataSetUSP_getAllSubCatsTableAdapter = new coolBlue.CategoriesDataSetTableAdapters.USP_getAllSubCatsTableAdapter();
                categoriesDataSet.EnforceConstraints = false;

                categoriesDataSetUSP_getAllSubCatsTableAdapter.Fill(categoriesDataSet.USP_getAllSubCats);
                categoriesDataSet.EnforceConstraints = true;


                uSP_getAllCatsUSP_getAllSubCatsViewSource.View.MoveCurrentToFirst();
            }
        }

        private void TableView_CustomCellAppearance(object sender, CustomCellAppearanceEventArgs e)
        {
            if (e.RowSelectionState != SelectionState.None)
            {
                e.Result = e.ConditionalValue;
                e.Handled = true;
            }
        }

        private void TableView_RowDoubleClick(object sender, RowDoubleClickEventArgs e)
        {
            goDetails();
        }
    }
    
}
