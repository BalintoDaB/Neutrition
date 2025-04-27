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
        private int caloriesLeftToday;

        public Person Person
        {
            get { return person; }
            set { person = value; OnPropertyChanged(nameof(Person)); }
        }

        public int CaloriesLeftToday
        {
            get { return (int)(Person.DailyCalorieToGoal - Storage.Meals.Sum(x => x.Calories)); }
        }

        public int Fats
        {
            get { return Storage.fats; }
        }
        public int Carbs
        {
            get { return Storage.carbs; }
        }
        public int Fibers
        {
            get { return Storage.fiber; }
        }
        public int Proteins
        {
            get { return Storage.protein; }
        }

        public MainWindow()
        {
            InitializeComponent();
            Person = new Person();
            Person.Init();
            DataContext = this;
            //ProfilPageView.DataContext = this;
            MainPageView.DataContext = this;
            Storage.LoadFoods();
            Storage.LoadMeals();
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