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

namespace wpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        public MainWindow()
        {
            //Start the Window
            InitializeComponent();
            clearAll.Click += ClearAll_Click;
            changeSign.Click += ChangeSign_Click;
            percentage.Click += Percentage_Click;
            calculate.Click += Calculate_Click;
        
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Percentage_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber /= 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void ChangeSign_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber *= -1;
                resultLabel.Content = lastNumber.ToString();
            }

        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            int selectedNumber = int.Parse(((ContentControl)sender).Content.ToString());         

            if(resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedNumber}";
            }
            else
            {
                resultLabel.Content += $"+{selectedNumber}";
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }
        }
        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            if(resultLabel.Content.ToString() != "0")
            {
                resultLabel.Content = "0";
            }
        }

    }
}
