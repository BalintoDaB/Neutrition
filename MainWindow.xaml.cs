using Neutrition.Pages;
using Neutrition.Resources;
using System.Collections.ObjectModel;
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

namespace Neutrition
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private Person person;

        public Person Person
        {
            get { return person; }
            set { person = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            
            //MessageBox.Show("Welcome " + Person.Name + " to Neutrition");
            Person = new Person();
            Person.Init();
            DataContext = this;
            MainPage mainPage = new MainPage();
            mainPage.DataContext = this;
            MainContFrame.Navigate(mainPage);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}