using DevExpress.Xpf.Core;
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
using System.Windows.Shapes;


namespace coolBlue
{
    /// <summary>
    /// Interaction logic for editTag.xaml
    /// </summary>
    public partial class editTag : ThemedWindow
    {
        public int nTagID;
        public editTag(int tagID)
        {
            InitializeComponent();
            nTagID = tagID;
        }
        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {

            coolBlue.tagDataSet TagDataSet = ((coolBlue.tagDataSet)(this.FindResource("TagDataSet")));
            // TODO: Add code here to load data into the table USP_getOneCat.
            // This code could not be generated, because the categoriesDataSetUSP_getOneCatTableAdapter.Fill method is missing, or has unrecognized parameters.
            coolBlue.tagDataSetTableAdapters.USP_getOneTagTableAdapter TagDataSetUSP_getOneTagTableAdapter = new coolBlue.tagDataSetTableAdapters.USP_getOneTagTableAdapter();


            TagDataSet.EnforceConstraints = false;

            TagDataSetUSP_getOneTagTableAdapter.Fill(TagDataSet.USP_getOneTag, nTagID);

            TagDataSet.EnforceConstraints = true;




            System.Windows.Data.CollectionViewSource uSP_getOneTagViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getOneTagViewSource")));
            uSP_getOneTagViewSource.View.MoveCurrentToFirst();
        }
    }
}
