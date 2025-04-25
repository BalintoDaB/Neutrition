using Neutrition.Resources;
using System;
using System.Collections.Generic;
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

namespace Neutrition.Pages.editpages
{
    /// <summary>
    /// Interaction logic for EditPerson.xaml
    /// </summary>
    public partial class EditPerson : Page
    {
        public Person PersonModelToChange { get; set; } // Objektum amit a user real time változtat
        public EditPerson()
        {
            InitializeComponent();
            Person p = new Person(); // Fájlból olvassa, hogy a memóriacímek ne befolyásolja a változók egymástól való függetlenségét
            p.LoadFromJson();
            PersonModelToChange = p;
            this.DataContext = this;
        }
    }
}
