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

namespace TipCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WarningTotal.Visibility = Visibility.Hidden;
            WarningPercent.Visibility = Visibility.Hidden;

            InputPercent.Text = "15";
            InputTotal.Text = "10.00";
        }

        private void InputTotal_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(InputTotal.Text, out double total))
            {
                WarningTotal.Visibility = Visibility.Hidden;
            }
            else
            {
                WarningTotal.Visibility = Visibility.Visible;
            }
            Calculate();
        }

        private void InputPercent_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(InputPercent.Text, out double total))
            {
                WarningPercent.Visibility = Visibility.Hidden;
            }
            else
            {
                WarningPercent.Visibility = Visibility.Visible;
            }
            Calculate();
        }

        private void Calculate()
        {
            if (double.TryParse(InputTotal.Text, out double total) && double.TryParse(InputPercent.Text, out double percent))
            {
                OutputWithTip.Text = (total + total * (percent / 100)).ToString("F");
            }
            else
            {
                OutputWithTip.Text = "-";
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
