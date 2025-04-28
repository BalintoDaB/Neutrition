using Neutrition.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DailyMealList.xaml
    /// </summary>
    public partial class DailyMealList : Page
    {
        public ObservableCollection<Meal> Meals { get; set; } = Storage.Meals;
        public string Ratio { get; set; } = "1";
        public Meal SelectedMeal { get; set; }
        public DailyMealList()
        {
            InitializeComponent();
            Meals.Add(new Meal(0, "sad", 1,2,3,4,5, DateTime.Now));
            this.DataContext = this;
        }

        private void AddMealButton_Click(object sender, RoutedEventArgs e)
        {
            Meal m = new Meal();

            int ratio = int.Parse(Ratio);
            m.Id = Storage.Meals.Count() + 1;
            m.Name = SelectedMeal.Name;
            m.EatDate = DateTime.Now;
            m.Calories = SelectedMeal.Calories * ratio;
            m.Protein = SelectedMeal.Protein * ratio;
            m.Carbs = SelectedMeal.Carbs * ratio;
            m.Fats = SelectedMeal.Fats * ratio;
            m.Fiber = SelectedMeal.Fiber * ratio;

            StackPanel stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(60, 12, 0, 0);
            stackPanel.Orientation = Orientation.Horizontal;
            Rectangle rect = new Rectangle();

            rect.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#60675B");
            rect.RadiusX = 10;
            rect.RadiusY = 10;
            rect.Margin = new Thickness(0,10,0,0);
            rect.Width = 400;
            rect.Height = 40;
            rect.VerticalAlignment = VerticalAlignment.Top;

            Label foodName = new Label();
            foodName.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#83927B");
            foodName.FontWeight = FontWeights.Bold;
            foodName.FontSize = 22;
            foodName.Margin = new Thickness(50, 0, 0, 0);
            foodName.Content = SelectedMeal.Name;

            Label ratioName = new Label();
            ratioName.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#83927B");
            ratioName.FontWeight = FontWeights.Bold;
            ratioName.FontSize = 22;
            ratioName.Margin = new Thickness(50, 0, 0, 0);
            ratioName.Content = $"{DateTime.Now:HH:mm}-kor";

            ScrollRowGrid.Children.Add(rect);
            stackPanel.Children.Add(foodName);
            stackPanel.Children.Add(ratioName);
            Grid.SetRow(stackPanel, int.Parse(backRect.GetValue(Grid.RowProperty).ToString()));
            ScrollRowGrid.Children.Add(stackPanel);
            Grid.SetRow(rect, int.Parse(backRect.GetValue(Grid.RowProperty).ToString()));


            RowDefinition rd = new RowDefinition();
            rd.Height = ScrollRowGrid.RowDefinitions[0].Height;
            ScrollRowGrid.RowDefinitions.Add(rd);
            Grid.SetRow(backRect, int.Parse(backRect.GetValue(Grid.RowProperty).ToString()) + 1);
            Grid.SetRow(AddPanel, int.Parse(AddPanel.GetValue(Grid.RowProperty).ToString()) + 1);

            Storage.AllMeal.Add(m);


        }

        private void Add_BTN_Click(object sender, RoutedEventArgs e)
        {
            EditFood editFoodPage = new EditFood();
            Register regWindow = new Register(editFoodPage);
            regWindow.ShowDialog();
        }
    }
}
