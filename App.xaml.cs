using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace Neutrition
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            //MessageBox.Show(Current.MainWindow.ToString());
            var app = new App();
            app.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/Style/Colors.xaml")
            });
            app.Resources.Add("RobotoFont", new FontFamily("pack://application:,,,/Fonts/#Roboto"));
            var mainWindow = new MainWindow();
            app.MainWindow = mainWindow;
            app.Run(mainWindow);
        }
    }

}
