using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using coolBlue.Properties;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Drawing;
using System.IO;

namespace coolBlue.classes
{
    static class ProgramSettings
    {

        private static int _facilityID = 0;
        private static string _facilityName = "";
        private static string _address = "";
        private static string _city = "";
        private static string _state = "";
        private static string _country = "";
        private static string _phone = "";
        private static string _email = "";
        private static string _URL = "";
        private static string _domain = "";
        private static string _LDAPDomain = "";// used for active directory queries

        private static DataView _dvEntity = null;

        static string  database  = "coolblue" ;
        static  string server = "SAGER10\\SAGER2017";
        // string server2 = Settings.Default.server2;
        static string username = "sa";
        static string password = "Sq!lsp!a123";

        public static string connectionString = "";
        public static string worksConnectionString = "";


        public  static string coolblueconnectionString = 
            String.Format("data source='{0}';initial catalog={1};password={2};persist security info=True;user id={3};packet size=4096;Connection Timeout=90", server, database, password, username);
        public static string appName = "";
        public static string appVersion = "";
        public static string formTitle = "";
        public static string formTitleBase = "";
        public static string regKey = "SOFTWARE\\WORKSSOFTWARE\\GalleryWorks";
        public static string tempDir = "";// used for cache

        public static string docSheetDir = "";// used for word documents
        public static string priceListDir = "";// used for word documents
        public static string artistInfoDir = "";// used for word documents
        public static string templateDir = "";// used for word documents
        //public static string logoDir = "";// used for word documents

        public static DirectoryInfo tmpDirInfo = null;// created below and used for cache
        public static DirectoryInfo docSheetDirInfo = null;
       
        public static string GWSearchConnectionString = "";
        public static string WorksSearchConnectionString = "";


        //public static Size imgLargeSize = new Size(2000, 2000);
        //public static Size imgMedSize = new Size(600, 600);
        //public static Size imgThumbSize = new Size(100, 100);
        //public static Size imgIconSize = new Size(20, 20);

        //*** For encryption:
        //*** generate new keys here:
        //static AesManaged myAes = new AesManaged();
        //public static byte[] aesKey = myAes.Key;
        //public static byte[] aesIV = myAes.IV;

        //*** Use persistent keys :
        //*** NOTE: program could be decompiled and keys used to decrypt data.
        public static byte[] aesKey = Convert.FromBase64String("RbeJXQu08FKgfvktxARjwX4cK13TtMNdnA3Lir02qPI=");
        public static byte[] aesIV = Convert.FromBase64String("rnKPMryaWxANLXSkYnEjmg==");


        public static DataSet dsEntity = new DataSet();



        public enum imageSize { none = -1, medium = 0, large = 3, thumb = 1, icon = 2 };

        public enum transactionType { Invoice = 0, Shipment = 1, Consignment = 2, Offer = 3, Loan = 4, RTC = 5 };

        public static int facilityID
        {
            get
            {
                return _facilityID;
            }
            set
            {
                if (_facilityID == value)
                    return;
                _facilityID = value;
            }
        }
        public static string facilityName
        {
            get
            {
                return _facilityName;
            }
            set
            {
                if (_facilityName == value)
                    return;
                _facilityName = value;
            }
        }
        public static string address
        {
            get
            {
                return _address;
            }
            set
            {
                if (_address == value)
                    return;
                _address = value;
            }
        }
        public static string city
        {
            get
            {
                return _city;
            }
            set
            {
                if (_city == value)
                    return;
                _city = value;
            }
        }
        public static string state
        {
            get
            {
                return _state;
            }
            set
            {
                if (_state == value)
                    return;
                _state = value;
            }
        }
        public static string country
        {
            get
            {
                return _country;
            }
            set
            {
                if (_country == value)
                    return;
                _country = value;
            }
        }
        public static string phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (_phone == value)
                    return;
                _phone = value;
            }
        }
        public static string email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email == value)
                    return;
                _email = value;
            }
        }
        public static string URL
        {
            get
            {
                return _URL;
            }
            set
            {
                if (_URL == value)
                    return;
                _URL = value;
            }
        }
        public static string domain
        {
            get
            {
                return _domain;
            }
            set
            {
                if (_domain == value)
                    return;
                _domain = value;
            }
        }
        public static string LDAPDomain
        {
            get
            {
                return _LDAPDomain;
            }
            set
            {
                if (_LDAPDomain == value)
                    return;
                _LDAPDomain = value;
            }
        }

        public static bool bAutoMinimizeDashboard = true;

        //TODO: NOT BEING USED?:
        //public static Dictionary<string, int> securityLevel = new Dictionary<string, int>();

        public static bool getSettings()
        {
            //*** These values come from Project->properties->assembly information:
            //appVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString();
            //use publish version is available (not available when run directly from Visual Studio)
            //if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            //{
            //    appVersion = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            //}
            //else
            //{
            //    appVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //}



            //domain = utilities.readAppConfig("domain");
            //LDAPDomain = utilities.readAppConfig("LDAPDomain");

            //formTitle = string.Format("{0}  v{1}", appName, appVersion);
            //formTitle = string.Format("{0}  v{1}  Server: {2}", "GalleryWorks", appVersion, utilities.readAppConfig("server"));
            formTitleBase = string.Format("{0}  v{1}  ", "Coolblue", appVersion);
            //formTitle = string.Format("{0}  Server: {1}", formTitleBase, utilities.readAppConfig("server"));
            formTitle = string.Format("{0}  Server: {1}", formTitleBase, Settings.Default.server);


            ////TODO: NOT BEING USED?:
            //// Set up security levels:
            //securityLevel.Add("user", 1); 
            //securityLevel.Add("editor", 4);
            //securityLevel.Add("admin", 13);
            //securityLevel.Add("su", 254);






            //imgLargeSize.Height = 400;
            //imgLargeSize.Width = 400;
            //imgThumbSize.Height = 50;
            //imgThumbSize.Width = 50;
            //imgIconSize.Height = 20;
            //imgIconSize.Width = 20;

            facilityID = 100; // should be read from database (see below), for now just set manually 
            facilityName = "Nanaimo"; // should be read from database (see below), for now just set manually 




            try
            {
                string dir = Directory.GetCurrentDirectory();
                tempDir = String.Format("{0}\\temp", dir);
                tmpDirInfo = new DirectoryInfo(tempDir);

                if (!tmpDirInfo.Exists)
                {
                    tmpDirInfo.Create();
                }
                //Debug.WriteLine(tmpDirInfo.FullName);

                //docSheetDir should be a share. Just set it to local directory if it is not set
                //docSheetDir = utilities.readAppConfig("documentDirectory");
                //docSheetDir = (Settings.Default.docSheetDir ?? "");
                //if (!Directory.Exists(docSheetDir)) docSheetDir = null;

                //artistInfoDir = (Settings.Default.artistInfoDir ?? "");
                //if (!Directory.Exists(artistInfoDir)) artistInfoDir = null;

                //priceListDir = (Settings.Default.priceListDir ?? "");
                //if (!Directory.Exists(priceListDir)) priceListDir = null;

                //templateDir = (Settings.Default.templateDir ?? "");
                //if (!Directory.Exists(templateDir)) templateDir = null;

                //bAutoMinimizeDashboard = Settings.Default.bAutoMinimizeDashboard;

                //docSheetDirInfo = new DirectoryInfo(docSheetDir);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            DBConnection dbconnection = new DBConnection();

            getConnectionString();
            while (string.IsNullOrWhiteSpace(connectionString))
            {
                string msg = string.Format("{0} could not connect to the specified database. Please verify your connection settings and try again.", "Coolblue");

             
                string caption5 = "CoolBlue";

                MessageBoxButton buttons5 = MessageBoxButton.OK;
                MessageBoxImage icon5 = MessageBoxImage.Warning;
                MessageBoxResult defaultResult5 = MessageBoxResult.OK;
                MessageBoxOptions options5 = MessageBoxOptions.None;
                // Show message box
                // MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

                // Displays the MessageBox.
                MessageBoxResult result5 = MessageBox.Show(msg, caption5, buttons5, icon5, defaultResult5, options5);
               
                
                dbconnection.ShowDialog();

                if (dbconnection.ShowDialog() == false)
                    {
                        string msg51 = string.Format("Database connection not found. {0} will now close.", "Coolblue");


                    string caption51 = "CoolBlue";

                    MessageBoxButton buttons51 = MessageBoxButton.OK;
                    MessageBoxImage icon51 = MessageBoxImage.Warning;
                    MessageBoxResult defaultResult51 = MessageBoxResult.OK;
                    MessageBoxOptions options51 = MessageBoxOptions.None;
                    // Show message box
                    // MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

                    // Displays the MessageBox.
                    MessageBoxResult result51 = MessageBox.Show(msg51, caption51, buttons51, icon51, defaultResult51, options51);
                    return false;
                    }
                
            }








            //if (string.IsNullOrEmpty(connectionString)) return false;

            //*** read settings from database

            //SqlConnection conn = new SqlConnection() { ConnectionString = connectionString };
            ////SqlConnection conn = new SqlConnection() { ConnectionString = Utilities.getConnectionString() };
            //SqlCommand cmd = new SqlCommand() { Connection = conn };
            //SqlDataReader dr = null;
            //cmd.CommandType = CommandType.Text;
            ////cmd.CommandText = "select * from ProgramSettings WHERE nEntityID = @entityID";
            //cmd.CommandText = "select * from entity WHERE ID = @entityID";
            //cmd.Parameters.AddWithValue("@entityID", GWContext.entityID);


            //try
            //{
            //    conn.Open();

            //    dr = cmd.ExecuteReader();

            //    if (dr.Read())
            //    {
            //        //facilityID = (int)dr["ID"];
            //        facilityName = (dr["cDescription"] ?? "").ToString();
            //        //address = (dr["cAddress"] ?? "").ToString();
            //        //city = (dr["cCity"] ?? "").ToString();
            //        //state = (dr["cState"] ?? "").ToString();
            //        //country = (dr["cCountry"] ?? "").ToString();
            //        //phone = (dr["cPhone"] ?? "").ToString();
            //        //email = (dr["cEmail"] ?? "").ToString();
            //        //domain = (dr["cDomain"] ?? "").ToString();
            //        //URL = (dr["cURL"] ?? "").ToString();
            //        //LDAPDomain = (dr["cLDAPDomain"] ?? "").ToString();
            //    }

            //    if (dr != null) dr.Close();

            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.Message);

            //}
            //finally
            //{
            //    if (conn.State == ConnectionState.Open) conn.Close();
            //}


            //using (SqlDataAdapter da = new SqlDataAdapter("EXEC USP_getEntity", ProgramSettings.connectionString))
            //{
            //    da.Fill(dsEntity, "entity");
            //}

            return true;

        }

        public static bool getConnectionString()
        {



            //Primary
            string database = "coolblue";
            string server = Settings.Default.server;
            
            string username = Settings.Default.username;
            string password = Settings.Default.password;

            //if (String.IsNullOrEmpty(server2)) server2 = server;

            //Primary GW
            connectionString = String.Format("data source='{0}';initial catalog={1};password={2};persist security info=True;user id={3};packet size=4096;Connection Timeout=90", server, database, password, username);
            //Secondary GW
           // GWSearchConnectionString = String.Format("data source='{0}';initial catalog={1};password={2};persist security info=True;user id={3};packet size=4096;Connection Timeout=90;ApplicationIntent=ReadOnly", server2, database, password, username);



            database = "Works";
            //Primary - works
            worksConnectionString = String.Format("data source='{0}';initial catalog={1};password={2};persist security info=True;user id={3};packet size=4096;Connection Timeout=90", server, database, password, username);
            //Secondary - works
            //WorksSearchConnectionString = String.Format("data source='{0}';initial catalog={1};password={2};persist security info=True;user id={3};packet size=4096;Connection Timeout=90;ApplicationIntent=ReadOnly", server2, database, password, username);



            //verify that servers are accessible:
            SqlConnection conn = new SqlConnection() { ConnectionString = connectionString };
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connectionString = "";
              
                worksConnectionString = "";
                
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }


            





            return !string.IsNullOrEmpty(connectionString);


        }


        // if (String.IsNullOrEmpty(server2)) server2 = server;

        //Primary GW
        // coolblueconnectionString = String.Format("data source='{0}';initial catalog={1};password={2};persist security info=True;user id={3};packet size=4096;Connection Timeout=90", server, database, password, username);

    }
}
