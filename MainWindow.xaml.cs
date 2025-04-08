using Neutrition.Resources;
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
            Person = new Person();
            Person.Init();
            DataContext = this;
            

        }
    }
}