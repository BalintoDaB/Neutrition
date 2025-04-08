using Neutrition.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Neutrition.Windows
{
    /// <summary>
    /// Interaction logic for NewPerson.xaml
    /// </summary>
    public partial class NewPerson : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Person createdPerson;

        public Person CreatedPerson
        {
            get { return createdPerson; }
            set { createdPerson = value; }
        }


        public NewPerson()
        {
            InitializeComponent();
            CreatedPerson = new Person();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnPropertyChanged("CreatedPerson");
            File.WriteAllText("Data/person.json", JsonSerializer.Serialize(CreatedPerson));
            this.Close();

        }
    }
}
