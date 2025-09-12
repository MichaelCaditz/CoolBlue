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
    /// Interaction logic for Tags.xaml
    /// </summary>
    public partial class Tags : ThemedWindow
    {
        public Tags()
        {
            InitializeComponent();
        }

        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {
            int nCompanyID = Settings.Default.nCompanyID;
            coolBlue.EditDataSet editDataSet = ((coolBlue.EditDataSet)(this.FindResource("editDataSet")));
            
            coolBlue.EditDataSetTableAdapters.USP_getAllTagsTableAdapter editDataSetUSP_getAllTagsTableAdapter = new coolBlue.EditDataSetTableAdapters.USP_getAllTagsTableAdapter();
            editDataSetUSP_getAllTagsTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;

            editDataSetUSP_getAllTagsTableAdapter.Fill(editDataSet.USP_getAllTags,nCompanyID);

            System.Windows.Data.CollectionViewSource uSP_getAllTagsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllTagsViewSource")));
            uSP_getAllTagsViewSource.View.MoveCurrentToFirst();
        }

        private void BarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            goDetails(); 
        }

        private void goDetails()
        {
            System.Windows.Data.CollectionViewSource uSP_getAllTagsViewSource = (System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllTagsViewSource"));
            int nCompanyID = Settings.Default.nCompanyID;

            DataRowView drv = (DataRowView)uSP_getAllTagsViewSource.View.CurrentItem;
            int tagCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
            editTag editTag1 = new editTag(tagCurrent);
            editTag1.ShowDialog();

            coolBlue.EditDataSet editDataSet = ((coolBlue.EditDataSet)(this.FindResource("editDataSet")));
            coolBlue.EditDataSetTableAdapters.USP_getAllTagsTableAdapter editDataSetUSP_getAllTagsTableAdapter = new coolBlue.EditDataSetTableAdapters.USP_getAllTagsTableAdapter();


            editDataSet.EnforceConstraints = false;
            editDataSetUSP_getAllTagsTableAdapter.Fill(editDataSet.USP_getAllTags,nCompanyID);
            editDataSet.EnforceConstraints = true;


            uSP_getAllTagsViewSource.View.MoveCurrentToFirst();
        }

            private void BarButtonItem_ItemClick_1(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            int TransactID1 = 0;
            int nCompanyID = Settings.Default.nCompanyID;

            System.Windows.Data.CollectionViewSource uSP_getAllTagsViewSource = (System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllTagsViewSource"));

            //coolBlue.RegisterDataSet registerDataSet = ((coolBlue.RegisterDataSet)(this.FindResource("registerDataSet")));


            // int accountCurrent = 0;
            int wasnull = 0;
            // wasnull = (uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View == null ? 1 : 0);
            if (wasnull == 1)
            {

                // MessageBox.Show("Warning: uSP_getLineViewSource is null", "CoolBlue");
                string message = "Warning: uSP_getAllTagsViewSource is null";
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
                    cmd3.CommandText = "dbo.USP_insertTag";
                    //cmd3.Parameters.AddWithValue("@nAccount", accountCurrent);
                    cmd3.Parameters.AddWithValue("@nCompanyID", nCompanyID);
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

                
                int tagCurrent = TransactID1;
                editTag editTag1 = new editTag(tagCurrent);
                editTag1.ShowDialog();

                coolBlue.EditDataSet editDataSet = ((coolBlue.EditDataSet)(this.FindResource("editDataSet")));
                coolBlue.EditDataSetTableAdapters.USP_getAllTagsTableAdapter editDataSetUSP_getAllTagsTableAdapter = new coolBlue.EditDataSetTableAdapters.USP_getAllTagsTableAdapter();


                editDataSet.EnforceConstraints = false;
                editDataSetUSP_getAllTagsTableAdapter.Fill(editDataSet.USP_getAllTags,nCompanyID);
                editDataSet.EnforceConstraints = true;


                uSP_getAllTagsViewSource.View.MoveCurrentToFirst();
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

        private void printTags_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            reportViewer reportViewer1 = new reportViewer();


            coolBlue.reports.REPORT_tags rpt = new coolBlue.reports.REPORT_tags();
            //Mouse.OverrideCursor = Cursors.Wait;
            //PrintHelper.ShowPrintPreview(this, rpt);
            reportViewer1.documentPreview1.DocumentSource = rpt;

            //rpt.Parameters["@accountID"].Value = 1;


            reportViewer1.Show();
            rpt.CreateDocument();

        }
    }
}
