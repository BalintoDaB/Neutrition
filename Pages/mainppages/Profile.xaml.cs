using Neutrition.Pages.editpages;
using Neutrition.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Neutrition.Pages.mainppages
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page, INotifyPropertyChanged
    {
        private Person personModel { get; set; }

        public Person PersonModel {
            get { return personModel; }
            set { 
                personModel = value;
                OnPropertyChanged(nameof(PersonModel));
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Profile()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Edit_BTN_Click(object sender, RoutedEventArgs e)
        {
            EditPerson EditPersonPage = new EditPerson(); // Editelős frame tartalma
            Register EditPersonFrame = new Register(EditPersonPage); //Editelős Frame
            EditPersonFrame.ShowDialog();
            if (EditPersonFrame.DialogResult == true)
            {
                PersonModel = EditPersonPage.PersonModelToChange;// Adatmentés ha a felhasználó akarja
                EditPersonPage.PersonModelToChange.SaveToJson(); 
            }
        }

    }
}
