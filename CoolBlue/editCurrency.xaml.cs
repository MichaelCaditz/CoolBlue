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
    /// Interaction logic for editCurrency.xaml
    /// </summary>
    public partial class editCurrency : ThemedWindow
    {
        public int nCurrencyID;
        public bool bNameChanged = false;
        public string cOrigName;
        public editCurrency(int currencyCurrent  )
        {
            InitializeComponent();
            nCurrencyID = currencyCurrent;
        }
        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {

            coolBlue.tagDataSet TagDataSet = (coolBlue.tagDataSet)(this.FindResource("tagDataSet"));
            // TODO: Add code here to load data into the table USP_getOneCat.
            // This code could not be generated, because the categoriesDataSetUSP_getOneCatTableAdapter.Fill method is missing, or has unrecognized parameters.
            coolBlue.tagDataSetTableAdapters.USP_getOneTagTableAdapter TagDataSetUSP_getOneTagTableAdapter = new coolBlue.tagDataSetTableAdapters.USP_getOneTagTableAdapter();


            TagDataSet.EnforceConstraints = false;

            TagDataSetUSP_getOneTagTableAdapter.Fill(TagDataSet.USP_getOneTag, nCurrencyID);

            TagDataSet.EnforceConstraints = true;

            System.Windows.Data.CollectionViewSource uSP_getOneTagViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getOneTagViewSource")));
            uSP_getOneTagViewSource.View.MoveCurrentToFirst();
        }

        private void BarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            System.Windows.Data.CollectionViewSource uSP_getAllTagsViewSource = (System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllTagsViewSource"));

            DataRowView drv = (DataRowView)uSP_getAllTagsViewSource.View.CurrentItem;
            int tagCurrent = (drv == null ? 0 : DBNull.Value.Equals(drv["ID"]) == true ? 0 : (int)drv["ID"]);
            editTag editTag1 = new editTag(tagCurrent);
            editTag1.ShowDialog();

            coolBlue.EditDataSet editDataSet = ((coolBlue.EditDataSet)(this.FindResource("editDataSet")));
            coolBlue.EditDataSetTableAdapters.USP_getAllTagsTableAdapter editDataSetUSP_getAllTagsTableAdapter = new coolBlue.EditDataSetTableAdapters.USP_getAllTagsTableAdapter();


            editDataSet.EnforceConstraints = false;
            editDataSetUSP_getAllTagsTableAdapter.Fill(editDataSet.USP_getAllTags);
            editDataSet.EnforceConstraints = true;


            uSP_getAllTagsViewSource.View.MoveCurrentToFirst();
        }

        private void BarButtonItem_ItemClick_1(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            int TransactID1 = 0;
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
                editDataSetUSP_getAllTagsTableAdapter.Fill(editDataSet.USP_getAllTags);
                editDataSet.EnforceConstraints = true;


                uSP_getAllTagsViewSource.View.MoveCurrentToFirst();
            }
        }
    }
}
