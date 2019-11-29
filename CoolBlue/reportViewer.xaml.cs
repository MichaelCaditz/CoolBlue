﻿using System;
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
    /// Interaction logic for reportViewer.xaml
    /// </summary>
    public partial class reportViewer : Window
    {
        public reportViewer()
        {
            InitializeComponent();
        }

        private void SimpleButton_Click(object sender, RoutedEventArgs e)
        {
            //reportViewer reportViewer1 = new reportViewer();
            //reportViewer1.Show();

            coolBlue.reports.REPORT_Transaction rpt = new coolBlue.reports.REPORT_Transaction();
            //Mouse.OverrideCursor = Cursors.Wait;
            //PrintHelper.ShowPrintPreview(this, rpt);
            documentPreview1.DocumentSource = rpt;
            rpt.CreateDocument();
            //rpt.BringToFront();
           // Mouse.OverrideCursor = null;
        }
    }
}
