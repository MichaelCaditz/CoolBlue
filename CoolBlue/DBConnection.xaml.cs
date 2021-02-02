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
    /// Interaction logic for DBConnection.xaml
    /// </summary>
    public partial class DBConnection : ThemedWindow
    {
        public DBConnection()
        {
            InitializeComponent();
        }

        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {
            getDBSettings();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //Cursor. = Cursors.WaitCursor;

            //*** validate textboxes:
            if (txtEditServer.Text.Trim().Length == 0)
            {
                //errorProvider1.SetError(tbServer, "Please enter a server name or IP address.");
                return;
            }
            else
            {
                //errorProvider1.SetError(tbServer, String.Empty);
            }


            //if (tbDatabase.Text.Trim().Length == 0)
            //{
            //    errorProvider1.SetError(tbDatabase, "Please enter a database name.");
            //}
            //else
            //{
            //    errorProvider1.SetError(tbDatabase, String.Empty);
            //}

            if (txtEditUsername.Text.Trim().Length == 0)
            {
                //errorProvider1.SetError(tbUsername, "Please enter a database username.");
                return;
            }
            else
            {
                //errorProvider1.SetError(tbUsername, String.Empty);
            }


            if (txtEditPassword.Text.Trim().Length == 0)
            {
                //errorProvider1.SetError(tbPassword, "Please enter a database password.");
                return;
            }
            else
            {
                //errorProvider1.SetError(tbPassword, String.Empty);
            }


            //if (errorProvider1.GetError(tbServer) != String.Empty ||
            //    errorProvider1.GetError(tbUsername) != String.Empty ||
            //    errorProvider1.GetError(tbPassword) != String.Empty
            //    )
            //{
            //    return;
            //}



            //*** test connectionString:

            string connString = "";
            string server = txtEditServer.Text;
           
            string database = "coolblue";
            string username = txtEditUsername.Text;
            string password = txtEditPassword.Text;


            connString = String.Format("data source={0};initial catalog={1};password={2};persist security info=True;user id={3};packet size=4096;Connection Timeout=30", server, database, password, username);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString;

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }


            }
            catch (Exception ex)
            {
                //Debug.WriteLine(ex.Message);
                //errorProvider1.SetError(tbServer, "Invalid credentials.");
                //Cursor.Current = Cursors.Default;
                return;
            }

            //connString = String.Format("data source={0};initial catalog={1};password={2};persist security info=True;user id={3};packet size=4096;Connection Timeout=30", server2, database, password, username);
            //SqlConnection conn2 = new SqlConnection();
            //conn2.ConnectionString = connString;

            //try
            //{
            //    conn2.Open();
            //    if (conn2.State == ConnectionState.Open)
            //    {
            //        conn2.Close();
            //    }


            //}
            //catch (Exception ex)
            //{
            //    //Debug.WriteLine(ex.Message);
            //    //errorProvider1.SetError(tbServer2, "Invalid credentials.");
            //    //Cursor.Current = Cursors.Default;
            //    return;
            //}


            //*** save settings and close form:
            saveDBSettings();
            ProgramSettings.getConnectionString();

            //Cursor.Current = Cursors.Default;


            this.DialogResult = true;

        }


        private void getDBSettings()
        {
            try
            {
                //tbServer.Text = utilities.readAppConfig("server");
                ////tbDatabase.Text = utilities.readAppConfig("database");
                //tbUsername.Text = utilities.readAppConfig("username");
                //tbPassword.Text = utilities.readAppConfig("password");

                txtEditServer.Text = Settings.Default.server;

                txtEditUsername.Text = Settings.Default.username;
                txtEditPassword.Text = Settings.Default.password;
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(ex.Message);
            }
        }
        private void saveDBSettings()
        {
            // utilities.writeAppConfig("server", tbServer.Text);
            //// utilities.writeAppConfig("database",tbDatabase.Text);
            // utilities.writeAppConfig("username",tbUsername.Text);
            // utilities.writeAppConfig("password", tbPassword.Text);


            Settings.Default.server = txtEditServer.Text;

            Settings.Default.username = txtEditUsername.Text;
            Settings.Default.password = txtEditPassword.Text;
            Settings.Default.Save();
        }
    }
}
       

