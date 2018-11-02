using System.Windows;
using System.Windows.Controls;

using static TipCalculator.Utilities;

namespace TipCalculator
{
    /// <summary>Rounding levels based on USD</summary>
    enum RoundMode
    {
        toCent,
        toQuarter,
        toDollar
    }

    /// <summary>Interaction logic for MainWindow.xaml</summary>
    public partial class MainWindow : Window
    {
        private RoundMode currentRoundMode = RoundMode.toQuarter;

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
                double exactTotalWithTip = (total + total * (percent / 100));

                switch (currentRoundMode)
                {
                    case RoundMode.toCent:
                        OutputWithTip.Text = RoundByUnit(exactTotalWithTip, 0.01).ToString("F");
                        break;
                    case RoundMode.toQuarter:
                        OutputWithTip.Text = RoundByUnit(exactTotalWithTip, 0.25).ToString("F");
                        break;
                    case RoundMode.toDollar:
                        OutputWithTip.Text = RoundByUnit(exactTotalWithTip, 1.00).ToString("F");
                        break;
                }
            }
            else
            {
                OutputWithTip.Text = "-";
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RoundingSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            currentRoundMode = (RoundMode)RoundingSlider.Value;
            RoundModeLabel.Text = "Payment Rounding: " + UnCamelCase(currentRoundMode.ToString());
            Calculate();
        }
    }
}