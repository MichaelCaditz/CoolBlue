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
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Drawing;
using System.IO;
using coolBlue.Properties;
using coolBlue.classes;


namespace coolBlue
{
    /// <summary>
    /// Interaction logic for settings.xaml
    /// </summary>
    public partial class settings : ThemedWindow
    {
        public settings()
        {
            InitializeComponent();
        }


        public bool bWasCompanyChanged=false;

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //this is too complicated in conjunction with company dropdown oon main page
            //if ((int) combDBCompany.EditValue != Settings.Default.nCompanyID)
            //{
            //    bWasCompanyChanged = true;


            //}








            //if (bWasCompanyChanged == true)

            //{
            //    Settings.Default.nCompanyID = (int) combDBCompany.EditValue;
            //}
            this.Close();
        }

        private void combDBCompany_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
           
        }

        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //int nCompanyID = Settings.Default.nCompanyID;
            //coolBlue.SettingsDataSet settingsDataSet = ((coolBlue.SettingsDataSet)(this.FindResource("settingsDataSet")));
            //// TODO: Add code here to load data into the table USP_getAllCompany.
            //// This code could not be generated, because the settingsDataSetUSP_getAllCompanyTableAdapter.Fill method is missing, or has unrecognized parameters.
            //coolBlue.SettingsDataSetTableAdapters.USP_getAllCompanyTableAdapter settingsDataSetUSP_getAllCompanyTableAdapter = new coolBlue.SettingsDataSetTableAdapters.USP_getAllCompanyTableAdapter();
            //System.Windows.Data.CollectionViewSource uSP_getAllCompanyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSP_getAllCompanyViewSource")));

            //settingsDataSetUSP_getAllCompanyTableAdapter.Connection.ConnectionString = ProgramSettings.coolblueconnectionString;
            //settingsDataSetUSP_getAllCompanyTableAdapter.Fill(settingsDataSet.USP_getAllCompany);

            //uSP_getAllCompanyViewSource.View.MoveCurrentToFirst();
            //combDBCompany.EditValue = nCompanyID;


        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            bWasCompanyChanged = false;
        }
    }
}
