using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Neutrition.Pages.regpages
{
    /// <summary>
    /// Interaction logic for regpage3.xaml
    /// </summary>
    public partial class regpage3 : Page
    {
        public class KgConverter : IValueConverter
        {
            // Converts a numeric value to a string with " kg" appended.
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null)
                    return string.Empty;

                // Format as integer. Change format if you want decimal precision.
                return $"{System.Convert.ToInt32(value)} kg";
            }

            // ConvertBack is not needed for one-way binding, so just return Binding.DoNothing.
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return Binding.DoNothing;
            }
        }
        public regpage3()
        {
            InitializeComponent();
        }
    }
}
