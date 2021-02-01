using coolBlue;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CoolBlue
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {

            //string message = "Start program?";
            //string caption = "CoolBlue";

            //MessageBoxButton buttons = MessageBoxButton.OKCancel;
            //MessageBoxImage icon = MessageBoxImage.Information;
            //MessageBoxResult defaultResult = MessageBoxResult.OK;
            //MessageBoxOptions options = MessageBoxOptions.None;
            
            //MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult, options);

            //if (result == MessageBoxResult.Cancel)
            //{

            //    // Closes the parent form.

            //    //this.Close();

            //    System.Windows.Application.Current.Shutdown();
            //    return;
            //}

            //else
            //{



            //}



                MainWindow window = new MainWindow();
                window.Show();
            
        }
    }
}
