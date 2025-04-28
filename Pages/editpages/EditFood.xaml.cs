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

namespace Neutrition.Pages.mainppages
{
    /// <summary>
    /// Interaction logic for EditFood.xaml
    /// </summary>
    public partial class EditFood : Page
    {
        public string MealName { get; set; }
        public string Calorie { get; set; }
        public string Fats { get; set; }
        public string Carbs { get; set; }
        public string Fiber { get; set; }
        public string Protein { get; set; }
        public EditFood()
        {
            InitializeComponent();
            MealName = "Meal's Name";
            this.DataContext = this;
            Save_BTN.Click += Save_BTN_Click;
        }

        private void Save_BTN_Click(object sender, RoutedEventArgs e)
        {
            Storage.Meals.Add(new Meal(Storage.Meals.Count() + 1, MealName, int.Parse(Calorie), int.Parse(Protein), int.Parse(Carbs), int.Parse(Fats), int.Parse(Fiber), DateTime.Now));
        }
    }
}
