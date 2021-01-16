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
    /// Interaction logic for Classes.xaml
    /// </summary>
    public partial class Classes : ThemedWindow
    {
        public Classes()
        {
            InitializeComponent();
        }

        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {

            coolBlue.EditDataSet editDataSet = ((coolBlue.EditDataSet)(this.FindResource("editDataSet")));
           
            coolBlue.EditDataSetTableAdapters.USP_getAllClassTableAdapter editDataSetUSP_getAllClassTableAdapter = new coolBlue.EditDataSetTableAdapters.USP_getAllClassTableAdapter();

            editDataSetUSP_getAllClassTableAdapter.Fill(editDataSet.USP_getAllClass);


            System.Windows.Data.CollectionViewSource uSP_getAllClassViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllClassViewSource")));
            uSP_getAllClassViewSource.View.MoveCurrentToFirst();
        }

        private void BarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            goDetails();
        }

        private void goDetails()
        {
            System.Windows.Data.CollectionViewSource uSP_getAllClassViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllClassViewSource")));

            DataRowView drv = (DataRowView)uSP_getAllClassViewSource.View.CurrentItem;
            int classCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
            editClass editClass1 = new editClass(classCurrent);
            editClass1.ShowDialog();

            coolBlue.EditDataSet editDataSet = ((coolBlue.EditDataSet)(this.FindResource("editDataSet")));
            coolBlue.EditDataSetTableAdapters.USP_getAllClassTableAdapter editDataSetUSP_getAllClassTableAdapter = new coolBlue.EditDataSetTableAdapters.USP_getAllClassTableAdapter();


            editDataSet.EnforceConstraints = false;
            editDataSetUSP_getAllClassTableAdapter.Fill(editDataSet.USP_getAllClass);
            editDataSet.EnforceConstraints = true;


            uSP_getAllClassViewSource.View.MoveCurrentToFirst();
        }


            private void BarButtonItem_ItemClick_1(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            
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

        private void BarButtomItemNewClass_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            int TransactID1 = 0;
            System.Windows.Data.CollectionViewSource uSP_getAllClassViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllClassViewSource")));

            //coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));


            // int accountCurrent = 0;
            int wasnull = 0;
            // wasnull = (uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View == null ? 1 : 0);
            if (wasnull == 1)
            {

                // MessageBox.Show("Warning: uSP_getLineViewSource is null", "CoolBlue");
                string message = "Warning: uSP_getAllCurrencyViewSource is null";
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
                    cmd3.CommandText = "dbo.USP_insertClass";
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


                int classCurrent = TransactID1;
                editClass editClass1 = new editClass(classCurrent);
                editClass1.ShowDialog();


                coolBlue.EditDataSet editDataSet = ((coolBlue.EditDataSet)(this.FindResource("editDataSet")));

                coolBlue.EditDataSetTableAdapters.USP_getAllClassTableAdapter editDataSetUSP_getAllClassTableAdapter = new coolBlue.EditDataSetTableAdapters.USP_getAllClassTableAdapter();
                editDataSet.EnforceConstraints = false;

                editDataSetUSP_getAllClassTableAdapter.Fill(editDataSet.USP_getAllClass);

                editDataSet.EnforceConstraints = true;

                //System.Windows.Data.CollectionViewSource uSP_getAllClassViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllClassViewSource")));
                uSP_getAllClassViewSource.View.MoveCurrentToFirst();

            }
        }
    }
}
