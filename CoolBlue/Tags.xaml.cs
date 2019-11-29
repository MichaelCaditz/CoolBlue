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
using DevExpress.Xpf.Core;


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

            coolBlue.EditDataSet editDataSet = ((coolBlue.EditDataSet)(this.FindResource("editDataSet")));
            
            coolBlue.EditDataSetTableAdapters.USP_getAllTagsTableAdapter editDataSetUSP_getAllTagsTableAdapter = new coolBlue.EditDataSetTableAdapters.USP_getAllTagsTableAdapter();

            editDataSetUSP_getAllTagsTableAdapter.Fill(editDataSet.USP_getAllTags);

            System.Windows.Data.CollectionViewSource uSP_getAllTagsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllTagsViewSource")));
            uSP_getAllTagsViewSource.View.MoveCurrentToFirst();
        }
    }
}
