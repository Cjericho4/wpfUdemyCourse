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
        SelectedOperator selectedOperator;
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
            if (double.TryParse(resultLabel.Content.ToString(), out double newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtract(lastNumber, newNumber);
                        break;
                }
                resultLabel.Content = result.ToString();
            }
        }

        private void Percentage_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double tempNum))
            {
                tempNum /= 100;
                if (lastNumber != 0)
                {
                    tempNum *= lastNumber;
                }
                resultLabel.Content = tempNum.ToString();
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
            int selectedNumber = int.Parse((sender as Button).Content.ToString());         

            if(resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedNumber}";
            }
            else
            {
                resultLabel.Content += $"{selectedNumber}";
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }
            if (sender == multiply)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == subtract)
                selectedOperator = SelectedOperator.Subtraction;
            if (sender == add)
                selectedOperator = SelectedOperator.Addition;
            if (sender == divide)
                selectedOperator = SelectedOperator.Division;
        }

        private void Period_Click(object sender, RoutedEventArgs e)
        {
            if( !resultLabel.Content.ToString().Contains("."))
                resultLabel.Content = $"{resultLabel.Content}.";
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            if(resultLabel.Content.ToString() != "0")
            {
                resultLabel.Content = "0";
                result = 0;
                lastNumber = 0;
            }
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Divide(double n1, double n2)
        {
            if(n2 == 0)
            {
                MessageBox.Show("Cannot divide by zero", "Error ilegal operation",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            else
                return n1 / n2;
        }
        public static double Subtract(double n1, double n3)
        {
            return n1 - n3;
        }
    }
}
