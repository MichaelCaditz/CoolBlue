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
    /// Interaction logic for TESTDXRibbonWindow1.xaml
    /// </summary>
    public partial class TESTDXRibbonWindow1 : ThemedWindow
    {
        public TESTDXRibbonWindow1()
        {
            InitializeComponent();
        }

        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {

            coolBlue.AccountsDataSet accountsDataSet = ((coolBlue.AccountsDataSet)(this.FindResource("accountsDataSet")));
            // TODO: Add code here to load data into the table USP_getAllAccountTypes.
            // This code could not be generated, because the accountsDataSetUSP_getAllAccountTypesTableAdapter.Fill method is missing, or has unrecognized parameters.
            coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountTypesTableAdapter accountsDataSetUSP_getAllAccountTypesTableAdapter = new coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountTypesTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesViewSource")));
            uSP_getAllAccountTypesViewSource.View.MoveCurrentToFirst();
            // TODO: Add code here to load data into the table USP_getAllAccounts.
            // This code could not be generated, because the accountsDataSetUSP_getAllAccountsTableAdapter.Fill method is missing, or has unrecognized parameters.
            coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountsTableAdapter accountsDataSetUSP_getAllAccountsTableAdapter = new coolBlue.AccountsDataSetTableAdapters.USP_getAllAccountsTableAdapter();
            System.Windows.Data.CollectionViewSource uSP_getAllAccountTypesUSP_getAllAccountsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllAccountTypesUSP_getAllAccountsViewSource")));
            uSP_getAllAccountTypesUSP_getAllAccountsViewSource.View.MoveCurrentToFirst();
        }
    }
}
