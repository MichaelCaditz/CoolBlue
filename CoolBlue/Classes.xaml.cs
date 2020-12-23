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
    }
}
