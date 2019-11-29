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
    }
}
