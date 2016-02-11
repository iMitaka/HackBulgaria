using System;
using System.Collections.Generic;
using System.IO;
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

namespace StylishCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists("config.txt"))
            {
                var theme = File.ReadAllText(@"config.txt");
                ThemeChange(theme);
            }
            else 
            {
                ThemeChange("light");
            }
            
            this.resultBox.IsReadOnly = true;
            this.firstNumberBox.Focus();
        }



        private void ThemeChange(string theme)
        {
            if (theme.ToLower() == "blue")
            {
                this.manGrid.Background = Brushes.LightCyan;
                this.buttonPlus.Background = Brushes.Cyan;
                this.buttonPlus.Foreground = Brushes.Black;
                this.buttonMinus.Background = Brushes.Cyan;
                this.buttonMinus.Foreground = Brushes.Black;
                this.buttonPower.Background = Brushes.Cyan;
                this.buttonPower.Foreground = Brushes.Black;
                this.buttonDivide.Background = Brushes.Cyan;
                this.buttonDivide.Foreground = Brushes.Black;
                this.firstNumberSqrtButton.Background = Brushes.DarkCyan;
                this.firstNumberSqrtButton.Foreground = Brushes.White;
                this.firstNumberLog2Button.Background = Brushes.DarkCyan;
                this.firstNumberLog2Button.Foreground = Brushes.White;
                this.secondNumberLog2Button.Background = Brushes.DarkCyan;
                this.secondNumberLog2Button.Foreground = Brushes.White;
                this.secondNumberSqrtButton.Background = Brushes.DarkCyan;
                this.secondNumberSqrtButton.Foreground = Brushes.White;
            }
            else if (theme.ToLower() == "dark") 
            {
                this.manGrid.Background = Brushes.Gray;
                this.buttonPlus.Background = Brushes.Black;
                this.buttonPlus.Foreground = Brushes.White;
                this.buttonMinus.Background = Brushes.Black;
                this.buttonMinus.Foreground = Brushes.White;
                this.buttonPower.Background = Brushes.Black;
                this.buttonPower.Foreground = Brushes.White;
                this.buttonDivide.Background = Brushes.Black;
                this.buttonDivide.Foreground = Brushes.White;
                this.firstNumberSqrtButton.Background = Brushes.Black;
                this.firstNumberSqrtButton.Foreground = Brushes.White;
                this.firstNumberLog2Button.Background = Brushes.Black;
                this.firstNumberLog2Button.Foreground = Brushes.White;
                this.secondNumberLog2Button.Background = Brushes.Black;
                this.secondNumberLog2Button.Foreground = Brushes.White;
                this.secondNumberSqrtButton.Background = Brushes.Black;
                this.secondNumberSqrtButton.Foreground = Brushes.White;
            }
            else if (theme.ToLower() == "light")
            {
                this.manGrid.Background = Brushes.White;
                this.buttonPlus.Background = Brushes.LightCyan;
                this.buttonPlus.Foreground = Brushes.Black;
                this.buttonMinus.Background = Brushes.LightCyan;
                this.buttonMinus.Foreground = Brushes.Black;
                this.buttonPower.Background = Brushes.LightCyan;
                this.buttonPower.Foreground = Brushes.Black;
                this.buttonDivide.Background = Brushes.LightCyan;
                this.buttonDivide.Foreground = Brushes.Black;
                this.firstNumberSqrtButton.Background = Brushes.LightGray;
                this.firstNumberSqrtButton.Foreground = Brushes.Blue;
                this.firstNumberLog2Button.Background = Brushes.LightGray;
                this.firstNumberLog2Button.Foreground = Brushes.Blue;
                this.secondNumberSqrtButton.Background = Brushes.LightGray;
                this.secondNumberSqrtButton.Foreground = Brushes.Blue;
                this.secondNumberLog2Button.Background = Brushes.LightGray;
                this.secondNumberLog2Button.Foreground = Brushes.Blue;
            }
        }

        private void theme_Change(object sender, RoutedEventArgs e)
        {
            MenuItem mi = e.Source as MenuItem;

            File.WriteAllText("config.txt", mi.Name.ToLower());
            ThemeChange(mi.Name.ToLower());
        }

        private void firstNumberSqrtButton_Click(object sender, RoutedEventArgs e)
        {
            decimal number = 0m;

            try
            {
                number = decimal.Parse(this.firstNumberBox.Text);
            }
            catch (Exception)
            {

                this.firstNumberErrorLabel.Content = "Invalid number.";
                this.firstNumberBox.Text = "0";
                return;
            }
            this.firstNumberErrorLabel.Content = string.Empty;
            var sqrtOfNumber = Math.Sqrt((double)number);
            this.firstNumberBox.Text = sqrtOfNumber.ToString();
        }

        private void firstNumberLog2Button_Click(object sender, RoutedEventArgs e)
        {
            decimal number = 0m;

            try
            {
                number = decimal.Parse(this.firstNumberBox.Text);
            }
            catch (Exception)
            {

                this.firstNumberErrorLabel.Content = "Invalid number.";
                this.firstNumberBox.Text = "0";
                return;
            }
            this.firstNumberErrorLabel.Content = string.Empty;
            var sqrtOfNumber = Math.Log((double)number, 2);
            this.firstNumberBox.Text = sqrtOfNumber.ToString();
        }

        private void secondNumberSqrtButton_Click(object sender, RoutedEventArgs e)
        {
            decimal number = 0m;

            try
            {
                number = decimal.Parse(this.secondNumberBox.Text);
            }
            catch (Exception)
            {

                this.secondNumberErrorLabel.Content = "Invalid number.";
                this.secondNumberBox.Text = "0";
                return;
            }
            this.secondNumberErrorLabel.Content = string.Empty;
            var sqrtOfNumber = Math.Log((double)number, 2);
            this.secondNumberBox.Text = sqrtOfNumber.ToString();
        }

        private void secondNumberLog2Button_Click(object sender, RoutedEventArgs e)
        {
            decimal number = 0m;

            try
            {
                number = decimal.Parse(this.secondNumberBox.Text);
            }
            catch (Exception)
            {

                this.secondNumberErrorLabel.Content = "Invalid number.";
                this.secondNumberBox.Text = "0";
                return;
            }

            this.secondNumberErrorLabel.Content = string.Empty;
            var sqrtOfNumber = Math.Log((double)number, 2);
            this.secondNumberBox.Text = sqrtOfNumber.ToString();
        }

        private void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
            decimal firstNumber = 0m;
            decimal secondNumber = 0m;

            try
            {
                firstNumber = decimal.Parse(this.firstNumberBox.Text);
            }
            catch (Exception)
            {

                this.firstNumberErrorLabel.Content = "Invalid number.";
                this.firstNumberBox.Text = "0";
                return;
            }

            try
            {
                secondNumber = decimal.Parse(this.secondNumberBox.Text);
            }
            catch (Exception)
            {
                this.secondNumberErrorLabel.Content = "Invalid number.";
                this.secondNumberBox.Text = "0";
                return;
            }

            this.firstNumberErrorLabel.Content = string.Empty;
            this.secondNumberErrorLabel.Content = string.Empty;

            decimal result = firstNumber + secondNumber;

            this.resultBox.Text = result.ToString();
        }

        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {
            decimal firstNumber = 0m;
            decimal secondNumber = 0m;

            try
            {
                firstNumber = decimal.Parse(this.firstNumberBox.Text);
            }
            catch (Exception)
            {

                this.firstNumberErrorLabel.Content = "Invalid number.";
                this.firstNumberBox.Text = "0";
                return;
            }

            try
            {
                secondNumber = decimal.Parse(this.secondNumberBox.Text);
            }
            catch (Exception)
            {
                this.secondNumberErrorLabel.Content = "Invalid number.";
                this.secondNumberBox.Text = "0";
                return;
            }

            this.firstNumberErrorLabel.Content = string.Empty;
            this.secondNumberErrorLabel.Content = string.Empty;

            decimal result = firstNumber - secondNumber;

            this.resultBox.Text = result.ToString();
        }

        private void buttonPower_Click(object sender, RoutedEventArgs e)
        {
            decimal firstNumber = 0m;
            decimal secondNumber = 0m;

            try
            {
                firstNumber = decimal.Parse(this.firstNumberBox.Text);
            }
            catch (Exception)
            {

                this.firstNumberErrorLabel.Content = "Invalid number.";
                this.firstNumberBox.Text = "0";
                return;
            }

            try
            {
                secondNumber = decimal.Parse(this.secondNumberBox.Text);
            }
            catch (Exception)
            {
                this.secondNumberErrorLabel.Content = "Invalid number.";
                this.secondNumberBox.Text = "0";
                return;
            }

            this.firstNumberErrorLabel.Content = string.Empty;
            this.secondNumberErrorLabel.Content = string.Empty;

            decimal result = firstNumber * secondNumber;

            this.resultBox.Text = result.ToString();
        }

        private void buttonDivide_Click(object sender, RoutedEventArgs e)
        {
            decimal firstNumber = 0m;
            decimal secondNumber = 0m;

            try
            {
                firstNumber = decimal.Parse(this.firstNumberBox.Text);
            }
            catch (Exception)
            {

                this.firstNumberErrorLabel.Content = "Invalid number.";
                this.firstNumberBox.Text = "0";
                return;
            }

            try
            {
                secondNumber = decimal.Parse(this.secondNumberBox.Text);
            }
            catch (Exception)
            {
                this.secondNumberErrorLabel.Content = "Invalid number.";
                this.secondNumberBox.Text = "0";
                return;
            }

            this.firstNumberErrorLabel.Content = string.Empty;

            if (secondNumber == 0m)
            {
                this.secondNumberErrorLabel.Content = "Cannot divide by zero.";
                return;
            }
            else 
            {
                this.secondNumberErrorLabel.Content = string.Empty;

                decimal result = firstNumber / secondNumber;

                this.resultBox.Text = result.ToString();
            }
                             
        }
    }
}
