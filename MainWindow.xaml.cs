using Neutrition.Pages;
using Neutrition.Pages.mainppages;
using Neutrition.Resources;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Profile ProfilPageView { get; set; } = new Profile();
        public MainPage MainPageView { get; set; } = new MainPage();

        private Person person;

        public Person Person
        {
            get { return person; }
            set { person = value; OnPropertyChanged(nameof(Person)); }
        }

        public MainWindow()
        {
            InitializeComponent();
            Person = new Person();
            Person.Init();
            DataContext = this;
            //ProfilPageView.DataContext = this;
            MainPageView.DataContext = this;
            MainContFrame.Navigate(MainPageView);



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Profile_BTN_Click(object sender, RoutedEventArgs e)
        {
            Person.LoadFromJson();
            ProfilPageView.PersonModel = Person;
            MainContFrame.Navigate(ProfilPageView);
        }

        private void Home_BTN_Click(object sender, RoutedEventArgs e)
        {

            Person.LoadFromJson();
            MainContFrame.Navigate(MainPageView);
        }
    }
}